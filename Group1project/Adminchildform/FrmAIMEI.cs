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
    public partial class FrmAIMEI : UIPage
    {
        private readonly ImeiBLL _imeiBll = new ImeiBLL();
        private List<imeiModel> _allImei = new List<imeiModel>();
        private List<imeiModel> _filteredImei = new List<imeiModel>();
        private List<ProductModel> _skuOptions = new List<ProductModel>();
        private const int PageSize = 20;
        private bool _isPagerUpdating;
        private UILabel? _footerLabel;
        private bool _isStatusUpdating;

        public FrmAIMEI()
        {
            InitializeComponent();

            Load += FrmAIMEI_Load;
            btnSearch.Click += BtnSearch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnimport.Click += Btnimport_Click;
            btnexport.Click += BtnExport_Click;
            txtimei.ButtonClick += Txtimei_ButtonClick;
            txtimei.TextChanged += Txtimei_TextChanged;
            txtimei.DoEnter += BtnSearch_Click;
            uiPagination1.PageChanged += UiPagination1_PageChanged;
        }

        private void FrmAIMEI_Load(object? sender, EventArgs e)
        {
            InitFooter();
            InitStatusFilter();
            _skuOptions = _imeiBll.GetSkuOptions();
            LoadImei();
        }

        private void InitStatusFilter()
        {
            SetControlProperty(cbotvstatus, "CheckBoxes", true);
            SetControlProperty(cbotvstatus, "ShowButtons", true);
            SetControlProperty(cbotvstatus, "ShowCheckAll", false);

            TreeNodeCollection? nodes = GetStatusNodeCollection();
            if (nodes == null)
            {
                return;
            }

            nodes.Clear();
            nodes.Add(new TreeNode("sold") { Checked = true });
            nodes.Add(new TreeNode("instock") { Checked = true });

            TreeView? tree = GetStatusTreeView();
            if (tree != null)
            {
                tree.CheckBoxes = true;
                tree.AfterCheck -= Cbotvstatus_AfterCheck;
                tree.AfterCheck += Cbotvstatus_AfterCheck;
            }

            cbotvstatus.Text = "sold,instock";
        }

        private static void SetControlProperty(object target, string propertyName, object value)
        {
            PropertyInfo? propertyInfo = target.GetType().GetProperty(propertyName);
            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(target, value);
            }
        }

        private TreeNodeCollection? GetStatusNodeCollection()
        {
            PropertyInfo? nodesProp = cbotvstatus.GetType().GetProperty("Nodes");
            if (nodesProp?.GetValue(cbotvstatus) is TreeNodeCollection nodes)
            {
                return nodes;
            }

            TreeView? tree = GetStatusTreeView();
            return tree?.Nodes;
        }

        private TreeView? GetStatusTreeView()
        {
            PropertyInfo? treeProp = cbotvstatus.GetType().GetProperty("TreeView");
            return treeProp?.GetValue(cbotvstatus) as TreeView;
        }

        private void Cbotvstatus_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (_isStatusUpdating || sender is not TreeView || e.Node == null)
            {
                return;
            }

            UpdateStatusFilterText();
            ApplyFilters(true);
        }

        private List<string> GetSelectedStatuses()
        {
            TreeNodeCollection? nodes = GetStatusNodeCollection();
            if (nodes == null)
            {
                return new List<string> { "sold", "instock" };
            }

            return nodes.Cast<TreeNode>()
                .Where(n => n.Checked)
                .Select(n => n.Text.Trim().ToLowerInvariant())
                .Where(x => x == "sold" || x == "instock")
                .Distinct()
                .ToList();
        }

        private void EnsureStatusSelection()
        {
            if (GetSelectedStatuses().Count > 0)
            {
                return;
            }

            TreeNodeCollection? nodes = GetStatusNodeCollection();
            if (nodes == null)
            {
                return;
            }

            _isStatusUpdating = true;
            try
            {
                foreach (TreeNode node in nodes)
                {
                    node.Checked = true;
                }
            }
            finally
            {
                _isStatusUpdating = false;
            }
        }

        private void UpdateStatusFilterText()
        {
            EnsureStatusSelection();
            List<string> selected = GetSelectedStatuses();
            cbotvstatus.Text = selected.Count == 2 ? "sold,instock" : string.Join(",", selected);
        }

        private void InitFooter()
        {
            uiDataGridViewFooter1.DataGridView = dgvimei;

            if (_footerLabel != null)
            {
                return;
            }

            _footerLabel = new UILabel
            {
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Font = uiDataGridViewFooter1.Font
            };

            uiDataGridViewFooter1.Controls.Add(_footerLabel);
        }

        private void LoadImei()
        {
            _allImei = _imeiBll.GetAllImei();
            ApplyFilters(false);
        }

        private void ApplyFilters(bool showTip)
        {
            EnsureStatusSelection();
            string keyword = txtimei.Text?.Trim() ?? string.Empty;
            HashSet<string> selectedStatuses = GetSelectedStatuses().ToHashSet(StringComparer.OrdinalIgnoreCase);

            IEnumerable<imeiModel> query = _allImei;
            query = query.Where(x => selectedStatuses.Contains((x.status ?? string.Empty).Trim()));

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => !string.IsNullOrWhiteSpace(x.imei)
                    && x.imei.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            _filteredImei = query.ToList();
            BindPage(1);
            RefreshFooter(_filteredImei);
        }

        private void BindPage(int page, bool syncPager = true)
        {
            if (page < 1)
            {
                page = 1;
            }

            int totalCount = _filteredImei.Count;
            int pageCount = (int)Math.Ceiling(totalCount / (double)PageSize);
            if (pageCount <= 0)
            {
                pageCount = 1;
            }

            if (page > pageCount)
            {
                page = pageCount;
            }

            List<imeiModel> pageData = _filteredImei
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            dgvimei.AutoGenerateColumns = true;
            dgvimei.DataSource = null;
            dgvimei.DataSource = pageData;
            dgvimei.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (syncPager)
            {
                UpdatePager(totalCount, page);
            }
        }


        private void UpdatePager(int totalCount, int page)
        {
            _isPagerUpdating = true;
            try
            {
                uiPagination1.PageSize = PageSize;
                uiPagination1.TotalCount = totalCount;
                if (uiPagination1.ActivePage != page)
                {
                    uiPagination1.ActivePage = page;
                }
            }
            finally
            {
                _isPagerUpdating = false;
            }
        }

        private void RefreshFooter(List<imeiModel> source)
        {
            int total = source.Count;
            int sold = _imeiBll.CountSold(source);
            int instock = _imeiBll.CountInStock(source);
            string footerText = $"Total: {total}    sold: {sold}    instock: {instock}";
            uiDataGridViewFooter1.Text = footerText;
            if (_footerLabel != null)
            {
                _footerLabel.Text = footerText;
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            UpdateStatusFilterText();
            ApplyFilters(true);
        }

        private void Txtimei_ButtonClick(object? sender, EventArgs e)
        {
            txtimei.Text = string.Empty;
            BtnSearch_Click(sender, e);
        }

        private void Txtimei_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtimei.Text))
            {
                ApplyFilters(false);
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var editForm = new Fimei(_skuOptions);
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (_imeiBll.ExistsImei(editForm.ImeiData.imei))
            {
                UIMessageBox.ShowWarning("IMEI already exists. Please enter a unique IMEI.");
                return;
            }

            int rows = _imeiBll.AddImei(editForm.ImeiData);
            if (rows > 0)
            {
                UIMessageTip.ShowOk("IMEI added successfully.");
                LoadImei();
                UpdateStatusFilterText();
                return;
            }

            UIMessageBox.ShowError("Failed to add IMEI.");
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvimei.CurrentRow?.DataBoundItem is not imeiModel selected)
            {
                UIMessageTip.ShowWarning("Please select one IMEI record.");
                return;
            }

            var editForm = new Fimei(selected, _skuOptions);
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            int rows = _imeiBll.UpdateImei(editForm.ImeiData, selected.imei);
            if (rows > 0)
            {
                UIMessageTip.ShowOk("IMEI updated successfully.");
                LoadImei();
                UpdateStatusFilterText();
                return;
            }

            UIMessageBox.ShowError("Failed to update IMEI.");
        }

        private void Btnimport_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*",
                Title = "Import IMEI"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var result = _imeiBll.Import(ofd.FileName);
            UIMessageTip.ShowOk($"Import completed. {result.insertedCount} row(s) inserted, {result.duplicateCount} duplicate row(s) skipped.");
            LoadImei();
            UpdateStatusFilterText();
        }

        private void BtnExport_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"tblimei_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                Title = "Export IMEI"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<imeiModel> exportData = _filteredImei.ToList();
            if (exportData.Count == 0)
            {
                UIMessageTip.ShowWarning("No IMEI data to export.");
                return;
            }

            MiniExcel.SaveAs(sfd.FileName, exportData.Select(x => new
            {
                x.imei,
                x.status,
                x.SKUcode,
                x.SPUcode,
                x.SPUname,
                x.brand,
                x.SKUspec,
                x.SKUname
            }).ToList());
            UIMessageTip.ShowOk("Export completed.");
        }

        private void UiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            if (_isPagerUpdating)
            {
                return;
            }

            BindPage(pageIndex, false);
        }
    }
}
