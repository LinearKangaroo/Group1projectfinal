using Group1project.Model;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
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
        }

        private void Fsaleadd_Load(object? sender, EventArgs e)
        {
            InitStaticData();
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

        private void InitStaticData()
        {
            cbopayment.Items.Clear();
            cbopayment.Items.Add("Cash");
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
            RefreshFooter();
        }

        private void RefreshGrid()
        {
            dgvinvoice.DataSource = null;
            dgvinvoice.DataSource = _invoiceItems.ToList();
            RefreshFooter();
        }

        private void RefreshFooter()
        {
            int totalItems = _invoiceItems.Count;
            decimal amount = _saleBll.SumAmount(_invoiceItems);
            uiDataGridViewFooter1.Text = $"Items: {totalItems}    Amount: {amount:C2}";
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

            if (_invoiceItems.Count == 0)
            {
                UIMessageBox.ShowWarning("Please add at least one invoice item.");
                return;
            }

            bool ok = _saleBll.SaveSale(invoiceId, uiDatePicker1.Value, userId, paymentType, _invoiceItems);
            if (!ok)
            {
                UIMessageBox.ShowError("Failed to save sale.");
                return;
            }

            UIMessageTip.ShowOk("Sale saved successfully.");
            DialogResult = DialogResult.OK;
            Close();
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
            btnAdd.Enabled = false;
            btnclear.Enabled = false;
            btnOK.Enabled = false;
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
