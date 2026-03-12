using Group1project.editForm;
using Group1project.Model;
using Group1project.project.BLL;
using MiniExcelLibs;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
namespace Group1project.Adminchildform
{
    public partial class FrmAanalysis : UIPage
    {
        private const string AllSelectedText = "All Selected";
        private readonly AnalysisBLL _analysisBll = new AnalysisBLL();
        private UILabel? _footerLabel;


        public FrmAanalysis()
        {
            InitializeComponent();

            Load += FrmAanalysis_Load;
            btnSearch.Click += BtnSearch_Click;
            btnclear.Click += Btnclear_Click;
            btnweek.Click += Btnweek_Click;
            btnmonth.Click += Btnmonth_Click;
            btnyear.Click += Btnyear_Click;
            btnexport.Click += Btnexport_Click;
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
            cbosort.Items.Add("Profit");
            cbosort.SelectedIndex = 0;

            cboorder.Items.Clear();
            cboorder.Items.Add("Descending");
            cboorder.Items.Add("Ascending");
            cboorder.SelectedIndex = 0;

            dgvanal.AutoGenerateColumns = true;
            dgvanal.ReadOnly = true;
            dgvanal.AllowUserToAddRows = false;
            dgvanal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvanal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            uiDataGridViewFooter1.DataGridView = dgvanal;

            EnsureFooterLabel();

            SetControlProperty(cbotvbrand, "CheckBoxes", true);
            SetControlProperty(cbotvbrand, "ShowCheckAll", true);
            SetControlProperty(cbotvbrand, "ShowButtons", true);
        }

        private void EnsureFooterLabel()
        {
            if (_footerLabel != null)
            {
                return;
            }

            _footerLabel = new UILabel
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = uiDataGridViewFooter1.Font
            };

            uiDataGridViewFooter1.Controls.Add(_footerLabel);
        }

        private static void SetControlProperty(object target, string propertyName, object value)
        {
            PropertyInfo? propertyInfo = target.GetType().GetProperty(propertyName);
            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(target, value);
            }
        }

        private void LoadBrands()
        {
            TreeNodeCollection? nodes = GetBrandNodeCollection();
            if (nodes == null)
            {
                return;
            }

            nodes.Clear();
            foreach (string brand in _analysisBll.GetBrands())
            {
                nodes.Add(new TreeNode(brand) { Checked = true });
            }

            TreeView? tree = GetBrandTreeView();
            if (tree != null)
            {
                tree.CheckBoxes = true;
                tree.AfterCheck -= Cbotvbrand_AfterCheck;
                tree.AfterCheck += Cbotvbrand_AfterCheck;
            }

            cbotvbrand.Text = AllSelectedText;
            UpdateFooterSummary(new List<AnalysisRowModel>());
        }

        private TreeNodeCollection? GetBrandNodeCollection()
        {
            PropertyInfo? nodesProp = cbotvbrand.GetType().GetProperty("Nodes");
            if (nodesProp?.GetValue(cbotvbrand) is TreeNodeCollection nodes)
            {
                return nodes;
            }

            TreeView? tree = GetBrandTreeView();
            return tree?.Nodes;
        }

        private TreeView? GetBrandTreeView()
        {
            PropertyInfo? treeProp = cbotvbrand.GetType().GetProperty("TreeView");
            if (treeProp?.GetValue(cbotvbrand) is TreeView tv)
            {
                return tv;
            }

            return null;
        }

        private void Cbotvbrand_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            List<string> selected = GetSelectedBrands();
            TreeNodeCollection? nodes = GetBrandNodeCollection();
            int total = nodes?.Count ?? 0;
            cbotvbrand.Text = total > 0 && selected.Count == total ? AllSelectedText : string.Join(",", selected);
        }

        private List<string> GetSelectedBrands()
        {
            TreeNodeCollection? nodes = GetBrandNodeCollection();
            if (nodes == null || nodes.Count == 0)
            {
                return new List<string>();
            }


            return nodes.Cast<TreeNode>()
                .Where(n => n.Checked)
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
                "Profit" => AnalysisSortType.Profit,
                _ => AnalysisSortType.Sellout
            };
            bool ascending = cboorder.Text == "Ascending";

            List<AnalysisRowModel> rows = _analysisBll.GetAnalysisRows(start, end, viewType, GetSelectedBrands(), sortType, ascending);
            dgvanal.DataSource = null;
            dgvanal.DataSource = rows;

            if (dgvanal.Columns.Contains(nameof(AnalysisRowModel.Name)))
            {
                dgvanal.Columns[nameof(AnalysisRowModel.Name)].HeaderText = viewType == AnalysisViewType.SKU ? "SKUname" : "SPUname";
                dgvanal.Columns[nameof(AnalysisRowModel.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvanal.Columns.Contains(nameof(AnalysisRowModel.Profit)))
            {
                dgvanal.Columns[nameof(AnalysisRowModel.Profit)].DefaultCellStyle.Format = "N2";
            }

            UpdateFooterSummary(rows);
        }


        private void UpdateFooterSummary(List<AnalysisRowModel> rows)
        {
            EnsureFooterLabel();

            int itemCount = rows.Count;
            int selloutTotal = rows.Sum(x => x.Sellout);
            int stockTotal = rows.Sum(x => x.Stock);
            decimal profitTotal = rows.Sum(x => x.Profit);

            decimal avgDaily = selloutTotal / 7m;
            decimal totalDos = avgDaily > 0 ? Math.Round(stockTotal / avgDaily, 2) : 0m;
            decimal totalDemand = Math.Round(avgDaily * 20m - stockTotal, 2);

            string text = $"Items: {itemCount}    Sellout: {selloutTotal}    Stock: {stockTotal}    DOS: {totalDos:0.##}    Demand: {totalDemand:0.##}    Profit: {profitTotal:0.00}";
            uiDataGridViewFooter1.Text = text;
            if (_footerLabel != null)
            {
                _footerLabel.Text = text;
            }
        }

        private void Btnexport_Click(object? sender, EventArgs e)
        {
            if (dgvanal.Rows.Count == 0)
            {
                UIMessageTip.ShowWarning("No data to export.");
                return;
            }

            using SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"Analysis_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<Dictionary<string, object?>> exportRows = new List<Dictionary<string, object?>>();
            List<DataGridViewColumn> columns = dgvanal.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            foreach (DataGridViewRow row in dgvanal.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                var data = new Dictionary<string, object?>();
                foreach (DataGridViewColumn col in columns)
                {
                    string header = string.IsNullOrWhiteSpace(col.HeaderText) ? col.Name : col.HeaderText;
                    data[header] = row.Cells[col.Index].Value;
                }

                exportRows.Add(data);
            }

            MiniExcel.SaveAs(saveDialog.FileName, exportRows);
            UIMessageTip.ShowOk($"Exported successfully: {saveDialog.FileName}");
        }

        private void Btnweek_Click(object? sender, EventArgs e) => ShowTrendChart(TrendRange.Week);
        private void Btnmonth_Click(object? sender, EventArgs e) => ShowTrendChart(TrendRange.Month);
        private void Btnyear_Click(object? sender, EventArgs e) => ShowTrendChart(TrendRange.Year);

        private void ShowTrendChart(TrendRange range)
        {
            var chart = new Fchart(GetSelectedBrands(), range);
            chart.ShowDialog();
        }
    }
}
