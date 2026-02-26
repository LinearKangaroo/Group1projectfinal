using Group1project.editForm;
using Group1project.Model;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Group1project.Adminchildform
{
    public partial class FrmAsale : UIPage
    {
        private readonly SaleBLL _saleBll = new SaleBLL();
        private List<SalehistoryModel> _filteredSales = new List<SalehistoryModel>();
        private const int PageSize = 20;
        private bool _isPagerUpdating;

        public FrmAsale()
        {
            InitializeComponent();

            Load += FrmAsale_Load;
            btnSearch.Click += BtnSearch_Click;
            btnclear.Click += Btnclear_Click;
            btnAdd.Click += BtnAdd_Click;
            uiPagination1.PageChanged += UiPagination1_PageChanged;
            dgvsale.CellDoubleClick += Dgvsale_CellDoubleClick;
            txtinvoice.ButtonClick += Txtinvoice_ButtonClick;
            txtuser.ButtonClick += Txtuser_ButtonClick;
        }

        private void FrmAsale_Load(object? sender, EventArgs e)
        {
            SetDefaultDateRange();
            LoadSales();
        }

        private void SetDefaultDateRange()
        {
            uiDatePicker2.Value = DateTime.Today;
            uiDatePicker1.Value = DateTime.Today.AddDays(-6);
        }

        private void LoadSales()
        {
            DateTime startDate = uiDatePicker1.Value.Date;
            DateTime endDate = uiDatePicker2.Value.Date;
            if (startDate > endDate)
            {
                (startDate, endDate) = (endDate, startDate);
                uiDatePicker1.Value = startDate;
                uiDatePicker2.Value = endDate;
            }

            string invoiceKeyword = txtinvoice.Text?.Trim() ?? string.Empty;
            string username = txtuser.Text?.Trim() ?? string.Empty;

            _filteredSales = _saleBll.GetSaleHistory(startDate, endDate, invoiceKeyword, username);
            BindPage(1);
        }

        private void BindPage(int page, bool syncPager = true)
        {
            if (page < 1)
            {
                page = 1;
            }

            int totalCount = _filteredSales.Count;
            int pageCount = (int)Math.Ceiling(totalCount / (double)PageSize);
            if (pageCount <= 0)
            {
                pageCount = 1;
            }
            if (page > pageCount)
            {
                page = pageCount;
            }

            List<SalehistoryModel> pageData = _filteredSales
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            dgvsale.AutoGenerateColumns = true;
            dgvsale.DataSource = null;
            dgvsale.DataSource = pageData;

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

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadSales();
            UIMessageTip.Show($"Found {_filteredSales.Count} sale record(s).");
        }

        private void Btnclear_Click(object? sender, EventArgs e)
        {
            txtinvoice.Text = string.Empty;
            txtuser.Text = string.Empty;
            SetDefaultDateRange();
            LoadSales();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var form = new Fsaleadd();
            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadSales();
        }

        private void Dgvsale_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvsale.Rows[e.RowIndex].DataBoundItem is not SalehistoryModel selected)
            {
                return;
            }

            var detailForm = new Fsaleadd(selected.invoice_id, true);
            detailForm.ShowDialog();
        }

        private void UiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            if (_isPagerUpdating)
            {
                return;
            }

            BindPage(pageIndex, false);
        }

        private void Txtinvoice_ButtonClick(object? sender, EventArgs e)
        {
            txtinvoice.Text = string.Empty;
        }

        private void Txtuser_ButtonClick(object? sender, EventArgs e)
        {
            txtuser.Text = string.Empty;
        }
    }
}
