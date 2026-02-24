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
    public partial class FrmAIMEI : UIPage
    {
        private readonly ImeiBLL _imeiBll = new ImeiBLL();
        private List<imeiModel> _allImei = new List<imeiModel>();
        private List<imeiModel> _filteredImei = new List<imeiModel>();
        private List<ProductModel> _skuOptions = new List<ProductModel>();
        private const int PageSize = 20;
        private bool _isPagerUpdating;

        public FrmAIMEI()
        {
            InitializeComponent();

            Load += FrmAIMEI_Load;
            btnSearch.Click += BtnSearch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnimport.Click += Btnimport_Click;
            uiSymbolButton2.Click += BtnExport_Click;
            txtimei.ButtonClick += Txtimei_ButtonClick;
            txtimei.TextChanged += Txtimei_TextChanged;
            uiPagination1.PageChanged += UiPagination1_PageChanged;
        }

        private void FrmAIMEI_Load(object? sender, EventArgs e)
        {
            _skuOptions = _imeiBll.GetSkuOptions();
            LoadImei();
        }

        private void LoadImei()
        {
            _allImei = _imeiBll.GetAllImei();
            _filteredImei = _allImei;
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
            uiDataGridViewFooter1.Text = $"信息总计: {total}    sold总计: {sold}    instock总计: {instock}";
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string keyword = txtimei.Text?.Trim() ?? string.Empty;
            _filteredImei = _imeiBll.SearchByImei(_allImei, keyword);
            BindPage(1);
            RefreshFooter(_filteredImei);
            UIMessageTip.Show($"Found {_filteredImei.Count} IMEI record(s).");
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
                _filteredImei = _allImei;
                BindPage(1);
                RefreshFooter(_filteredImei);
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var editForm = new Fimei(_skuOptions);
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            int rows = _imeiBll.AddImei(editForm.ImeiData);
            if (rows > 0)
            {
                UIMessageTip.ShowOk("IMEI added successfully.");
                LoadImei();
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

            int count = _imeiBll.Import(ofd.FileName);
            UIMessageTip.ShowOk($"Import completed. {count} row(s) inserted.");
            LoadImei();
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

            _imeiBll.Export(sfd.FileName);
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
