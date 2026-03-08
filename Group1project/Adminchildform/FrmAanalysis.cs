using Group1project.editForm;
using Group1project.Model;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Group1project.Adminchildform
{
    public partial class FrmAanalysis : UIPage
    {
        private const string AllBrandsText = "All Brands";
        private readonly AnalysisBLL _analysisBll = new AnalysisBLL();

        public FrmAanalysis()
        {
            InitializeComponent();

            Load += FrmAanalysis_Load;
            btnSearch.Click += BtnSearch_Click;
            btnclear.Click += Btnclear_Click;
            btnweek.Click += Btnweek_Click;
            btnmonth.Click += Btnmonth_Click;
            btnyear.Click += Btnyear_Click;
        }

        private void FrmAanalysis_Load(object? sender, EventArgs e)
        {
            InitFilters();
            LoadBrands();
            LoadAnalysisGrid();
        }

        private void InitFilters()
        {
            DateTime today = DateTime.Today;
            uiDatePicker1.Value = new DateTime(today.Year, today.Month, 1);
            uiDatePicker2.Value = today;

            cboview.Items.Clear();
            cboview.Items.Add("SKU");
            cboview.Items.Add("SPU");
            cboview.SelectedIndex = 0;

            cbosort.Items.Clear();
            cbosort.Items.Add("Sellout");
            cbosort.Items.Add("Stock");
            cbosort.Items.Add("DOS");
            cbosort.Items.Add("Demand Stock");
            cbosort.SelectedIndex = 0;

            cboorder.Items.Clear();
            cboorder.Items.Add("Descending");
            cboorder.Items.Add("Ascending");
            cboorder.SelectedIndex = 0;

            dgvanal.AutoGenerateColumns = true;
            dgvanal.ReadOnly = true;
            dgvanal.AllowUserToAddRows = false;
            dgvanal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            uiDataGridViewFooter1.DataGridView = dgvanal;
        }

        private void LoadBrands()
        {
            TreeView? tree = GetBrandTreeView();
            if (tree == null)
            {
                return;
            }

            tree.Nodes.Clear();
            tree.CheckBoxes = true;

            TreeNode allNode = new TreeNode(AllBrandsText) { Checked = true };
            tree.Nodes.Add(allNode);

            foreach (string brand in _analysisBll.GetBrands())
            {
                tree.Nodes.Add(new TreeNode(brand) { Checked = true });
            }

            tree.AfterCheck -= Cbotvbrand_AfterCheck;
            tree.AfterCheck += Cbotvbrand_AfterCheck;
            cbotvbrand.Text = AllBrandsText;
        }

        private TreeView? GetBrandTreeView()
        {
            var treeProp = cbotvbrand.GetType().GetProperty("TreeView");
            if (treeProp?.GetValue(cbotvbrand) is TreeView tv)
            {
                return tv;
            }

            return null;
        }

        private void Cbotvbrand_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (sender is not TreeView tree || e.Node == null)
            {
                return;
            }

            tree.AfterCheck -= Cbotvbrand_AfterCheck;

            if (string.Equals(e.Node.Text, AllBrandsText, StringComparison.OrdinalIgnoreCase))
            {
                foreach (TreeNode node in tree.Nodes)
                {
                    if (!ReferenceEquals(node, e.Node))
                    {
                        node.Checked = e.Node.Checked;
                    }
                }
            }
            else
            {
                TreeNode? allNode = tree.Nodes.Cast<TreeNode>().FirstOrDefault(n => string.Equals(n.Text, AllBrandsText, StringComparison.OrdinalIgnoreCase));
                if (allNode != null)
                {
                    bool allChecked = tree.Nodes.Cast<TreeNode>().Where(n => !ReferenceEquals(n, allNode)).All(n => n.Checked);
                    allNode.Checked = allChecked;
                }
            }

            tree.AfterCheck += Cbotvbrand_AfterCheck;
            List<string> selected = GetSelectedBrands();
            cbotvbrand.Text = selected.Count == 0 ? AllBrandsText : string.Join(",", selected);
        }

        private List<string> GetSelectedBrands()
        {
            TreeView? tree = GetBrandTreeView();
            if (tree == null || tree.Nodes.Count == 0)
            {
                return new List<string>();
            }

            TreeNode? allNode = tree.Nodes.Cast<TreeNode>().FirstOrDefault(n => string.Equals(n.Text, AllBrandsText, StringComparison.OrdinalIgnoreCase));
            if (allNode != null && allNode.Checked)
            {
                return new List<string>();
            }

            return tree.Nodes.Cast<TreeNode>()
                .Where(n => !string.Equals(n.Text, AllBrandsText, StringComparison.OrdinalIgnoreCase) && n.Checked)
                .Select(n => n.Text)
                .ToList();
        }

        private void BtnSearch_Click(object? sender, EventArgs e) => LoadAnalysisGrid();

        private void Btnclear_Click(object? sender, EventArgs e)
        {
            InitFilters();
            LoadBrands();
            LoadAnalysisGrid();
        }

        private void LoadAnalysisGrid()
        {
            DateTime start = uiDatePicker1.Value.Date;
            DateTime end = uiDatePicker2.Value.Date;
            if (start > end)
            {
                UIMessageTip.ShowWarning("Start date cannot be greater than end date.");
                return;
            }

            AnalysisViewType viewType = cboview.Text == "SPU" ? AnalysisViewType.SPU : AnalysisViewType.SKU;
            AnalysisSortType sortType = cbosort.Text switch
            {
                "Stock" => AnalysisSortType.Stock,
                "DOS" => AnalysisSortType.DOS,
                "Demand Stock" => AnalysisSortType.DemandStock,
                _ => AnalysisSortType.Sellout
            };
            bool ascending = cboorder.Text == "Ascending";

            List<AnalysisRowModel> rows = _analysisBll.GetAnalysisRows(start, end, viewType, GetSelectedBrands(), sortType, ascending);
            dgvanal.DataSource = null;
            dgvanal.DataSource = rows;

            if (dgvanal.Columns.Contains(nameof(AnalysisRowModel.Name)))
            {
                dgvanal.Columns[nameof(AnalysisRowModel.Name)].HeaderText = viewType == AnalysisViewType.SKU ? "SKUname" : "SPUname";
            }
        }

        private void Btnweek_Click(object? sender, EventArgs e) => ShowTrendChart(TrendRange.Week);
        private void Btnmonth_Click(object? sender, EventArgs e) => ShowTrendChart(TrendRange.Month);
        private void Btnyear_Click(object? sender, EventArgs e) => ShowTrendChart(TrendRange.Year);

        private void ShowTrendChart(TrendRange range)
        {
            List<SalesTrendPointModel> points = _analysisBll.GetTrendData(range, GetSelectedBrands());
            var chart = new Fchart();
            chart.BindSalesTrend(points, range);
            chart.ShowDialog();
        }
    }
}
