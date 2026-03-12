using Group1project.Model;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Group1project.editForm
{
    public partial class Fsaleadd : UIEditForm
    {
        private readonly SaleBLL _saleBll = new SaleBLL();
        private readonly List<SaleInvoiceModel> _invoiceItems = new List<SaleInvoiceModel>();
        private readonly bool _readOnlyMode;
        private readonly int? _viewInvoiceId;
        private readonly Dictionary<int, string> _userMap = new Dictionary<int, string>();
        private UILabel? _footerLabel;
        private readonly PrintDocument _invoicePrintDocument = new PrintDocument();
        private int _printItemIndex;

        public Fsaleadd()
        {
            InitializeComponent();
            _readOnlyMode = false;
            BindEvents();
        }

        public Fsaleadd(int invoiceId, bool readOnlyMode)
        {
            InitializeComponent();
            _readOnlyMode = readOnlyMode;
            _viewInvoiceId = invoiceId;
            BindEvents();
        }

        private void BindEvents()
        {
            Load += Fsaleadd_Load;
            btnAdd.Click += BtnAdd_Click;
            btnclear.Click += Btnclear_Click;
            txtimei.KeyDown += Txtimei_KeyDown;
            btnOK.Click += BtnOK_Click;
            _invoicePrintDocument.PrintPage += InvoicePrintDocument_PrintPage;
        }

        private void Fsaleadd_Load(object? sender, EventArgs e)
        {
            InitStaticData();
            InitFooter();
            InitGrid();

            if (_readOnlyMode && _viewInvoiceId.HasValue)
            {
                LoadReadOnlyInvoice(_viewInvoiceId.Value);
                ApplyReadOnlyMode();
                return;
            }

            txtinvoice.Text = _saleBll.GetNextInvoiceId().ToString();
            txtinvoice.ReadOnly = true;
            uiDatePicker1.Value = DateTime.Today;
        }


        private void InitFooter()
        {
            uiDataGridViewFooter1.DataGridView = dgvinvoice;

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

        private void InitStaticData()
        {
            cbopayment.Items.Clear();
            cbopayment.Items.Add("Cash");
            cbopayment.Items.Add("Credit");
            cbopayment.Items.Add("Card");
            cbopayment.Items.Add("Transfer");
            cbopayment.SelectedIndex = 0;

            cbouserid.Items.Clear();
            List<UserModel> users = _saleBll.GetActiveUsers();
            _userMap.Clear();
            foreach (UserModel user in users)
            {
                _userMap[user.userId] = user.username;
                cbouserid.Items.Add($"{user.userId} - {user.username}");
            }

            SelectDefaultLoginUser();
        }

        private void SelectDefaultLoginUser()
        {
            if (cbouserid.Items.Count == 0)
            {
                return;
            }

            if (CurrentUserContext.IsLoggedIn)
            {
                for (int i = 0; i < cbouserid.Items.Count; i++)
                {
                    if (cbouserid.Items[i].ToString()?.StartsWith($"{CurrentUserContext.UserId} ") == true)
                    {
                        cbouserid.SelectedIndex = i;
                        return;
                    }
                }
            }

            cbouserid.SelectedIndex = 0;
        }

        private void InitGrid()
        {
            dgvinvoice.AutoGenerateColumns = true;
            dgvinvoice.DataSource = null;
            dgvinvoice.DataSource = _invoiceItems;
            dgvinvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            RefreshFooter();
        }

        private void RefreshGrid()
        {
            dgvinvoice.DataSource = null;
            dgvinvoice.DataSource = _invoiceItems.ToList();
            dgvinvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            RefreshFooter();
        }

        private void RefreshFooter()
        {
            int totalItems = _invoiceItems.Count;
            decimal amount = _saleBll.SumAmount(_invoiceItems);
            //string footerText = $"Items: {totalItems}    Amount: {amount:C2}";
            string footerText = $"Items: {totalItems}    Amount: {amount:N2}Ks";
            uiDataGridViewFooter1.Text = footerText;
            if (_footerLabel != null)
            {
                _footerLabel.Text = footerText;
            }
        }

        private void Txtimei_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddImeiToInvoice();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            AddImeiToInvoice();
        }

        private void AddImeiToInvoice()
        {
            string imei = txtimei.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(imei))
            {
                UIMessageTip.ShowWarning("Please input IMEI.");
                return;
            }

            if (_invoiceItems.Any(x => string.Equals(x.imei, imei, StringComparison.OrdinalIgnoreCase)))
            {
                UIMessageTip.ShowWarning("This IMEI is already in the invoice list.");
                return;
            }

            if (!_saleBll.IsImeiInStock(imei))
            {
                UIMessageBox.ShowWarning("IMEI is not in instock status, cannot add.");
                return;
            }

            SaleInvoiceModel? item = _saleBll.GetInvoiceItemByImei(imei);
            if (item == null)
            {
                UIMessageBox.ShowWarning("IMEI exists but related SKU/product info is missing.");
                return;
            }

            _invoiceItems.Add(item);
            RefreshGrid();
            txtimei.Text = string.Empty;
            txtimei.Focus();
        }

        private void Btnclear_Click(object? sender, EventArgs e)
        {
            if (_readOnlyMode)
            {
                return;
            }

            if (dgvinvoice.CurrentRow?.DataBoundItem is not SaleInvoiceModel selected)
            {
                return;
            }

            _invoiceItems.RemoveAll(x => string.Equals(x.imei, selected.imei, StringComparison.OrdinalIgnoreCase));
            RefreshGrid();
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            if (_readOnlyMode)
            {
                return;
            }

            if (!int.TryParse(txtinvoice.Text, out int invoiceId))
            {
                UIMessageBox.ShowWarning("Invoice id is invalid.");
                return;
            }

            int userId = ParseUserIdFromCombo(cbouserid.Text);
            if (userId <= 0)
            {
                UIMessageBox.ShowWarning("Please select user.");
                return;
            }

            string paymentType = cbopayment.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(paymentType))
            {
                UIMessageBox.ShowWarning("Please select payment type.");
                return;
            }

            //string customer = txtcustomer.Text?.Trim() ?? string.Empty;
            //string address = txtaddress.Text?.Trim() ?? string.Empty;

            if (_invoiceItems.Count == 0)
            {
                UIMessageBox.ShowWarning("Please add at least one invoice item.");
                return;
            }

            bool ok = _saleBll.SaveSale(
                invoiceId,
                uiDatePicker1.Value,
                userId,
                paymentType,
                txtcustomer.Text?.Trim() ?? string.Empty,
                txtaddress.Text?.Trim() ?? string.Empty,
                _invoiceItems);
            if (!ok)
            {
                UIMessageBox.ShowError("Failed to save sale.");
                return;
            }

            try
            {
                PrintInvoice();
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowWarning($"Sale saved, but print failed: {ex.Message}");
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void PrintInvoice()
        {
            _printItemIndex = 0;
            _invoicePrintDocument.DocumentName = $"Invoice-{txtinvoice.Text}";
            _invoicePrintDocument.Print();
        }

        private void InvoicePrintDocument_PrintPage(object? sender, PrintPageEventArgs e)
        {
            using Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            using Font bodyFont = new Font("Arial", 10, FontStyle.Regular);
            float y = e.MarginBounds.Top;
            float left = e.MarginBounds.Left;
            float right = e.MarginBounds.Right;
            float lineHeight = bodyFont.GetHeight(e.Graphics) + 6;

            e.Graphics.DrawString("SALES INVOICE", titleFont, Brushes.Black, left, y);
            y += lineHeight + 10;
            e.Graphics.DrawString($"Invoice: {txtinvoice.Text}", bodyFont, Brushes.Black, left, y);
            y += lineHeight;
            e.Graphics.DrawString($"Date: {uiDatePicker1.Value:yyyy-MM-dd}", bodyFont, Brushes.Black, left, y);
            y += lineHeight;
            e.Graphics.DrawString($"Sales: {cbouserid.Text}", bodyFont, Brushes.Black, left, y);
            y += lineHeight;
            e.Graphics.DrawString($"Payment: {cbopayment.Text}", bodyFont, Brushes.Black, left, y);
            y += lineHeight;
            e.Graphics.DrawString($"Customer: {txtcustomer.Text}", bodyFont, Brushes.Black, left, y);
            y += lineHeight;
            e.Graphics.DrawString($"Address: {txtaddress.Text}", bodyFont, Brushes.Black, left, y);
            y += lineHeight + 8;

            e.Graphics.DrawString("IMEI", bodyFont, Brushes.Black, left, y);
            e.Graphics.DrawString("Product", bodyFont, Brushes.Black, left + 190, y);
            e.Graphics.DrawString("Price", bodyFont, Brushes.Black, right - 120, y);
            y += lineHeight;
            e.Graphics.DrawLine(Pens.Black, left, y, right, y);
            y += 6;

            while (_printItemIndex < _invoiceItems.Count)
            {
                SaleInvoiceModel item = _invoiceItems[_printItemIndex];

                if (y + lineHeight > e.MarginBounds.Bottom - 40)
                {
                    e.HasMorePages = true;
                    return;
                }

                e.Graphics.DrawString(item.imei ?? string.Empty, bodyFont, Brushes.Black, left, y);
                e.Graphics.DrawString(item.SKUname ?? string.Empty, bodyFont, Brushes.Black, left + 190, y);
                e.Graphics.DrawString(item.unit_price.ToString("0.00"), bodyFont, Brushes.Black, right - 120, y);

                y += lineHeight;
                _printItemIndex++;
            }

            y += 10;
            e.Graphics.DrawLine(Pens.Black, left, y, right, y);
            y += lineHeight;
            decimal totalAmount = _saleBll.SumAmount(_invoiceItems);
            e.Graphics.DrawString($"Total items: {_invoiceItems.Count}", bodyFont, Brushes.Black, left, y);
            e.Graphics.DrawString($"Total amount: {totalAmount:0.00}", bodyFont, Brushes.Black, right - 180, y);

            e.HasMorePages = false;
        }

        private void LoadReadOnlyInvoice(int invoiceId)
        {
            List<SaleInvoiceModel> details = _saleBll.GetInvoiceDetails(invoiceId);
            _invoiceItems.Clear();
            _invoiceItems.AddRange(details);
            txtinvoice.Text = invoiceId.ToString();
            txtinvoice.ReadOnly = true;

            SalehistoryModel? header = _saleBll
                .GetSaleHistory(DateTime.Today.AddYears(-20), DateTime.Today.AddYears(20), invoiceId.ToString(), string.Empty)
                .FirstOrDefault();
            if (header != null)
            {
                uiDatePicker1.Value = header.sell_date;
                cbopayment.Text = header.payment_type;
                cbouserid.Text = $"{header.userId} - {header.username}";
                txtcustomer.Text = header.customer;
                txtaddress.Text = header.address;
            }

            RefreshGrid();
        }

        private void ApplyReadOnlyMode()
        {
            Text = "Sale Detail";
            txtimei.ReadOnly = true;
            cbouserid.Enabled = false;
            cbopayment.Enabled = false;
            uiDatePicker1.Enabled = false;
            txtcustomer.ReadOnly = true;
            txtaddress.ReadOnly = true;
            btnAdd.Visible = false;
            btnclear.Visible = false;
            btnOK.Visible = false;
        }

        private static int ParseUserIdFromCombo(string comboText)
        {
            if (string.IsNullOrWhiteSpace(comboText))
            {
                return 0;
            }

            string[] parts = comboText.Split('-', 2, StringSplitOptions.TrimEntries);
            return parts.Length > 0 && int.TryParse(parts[0], out int userId) ? userId : 0;
        }
    }
}
