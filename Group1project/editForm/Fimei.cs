using Group1project.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Group1project.editForm
{
    public partial class Fimei : UIEditForm
    {
        private readonly List<ProductModel> _skuOptions;

        public imeiModel ImeiData { get; private set; } = new imeiModel();

        public Fimei(List<ProductModel> skuOptions)
        {
            InitializeComponent();
            _skuOptions = skuOptions ?? new List<ProductModel>();
            InitControls();
            btnOK.Click += BtnOK_Click;
        }

        public Fimei(imeiModel model, List<ProductModel> skuOptions) : this(skuOptions)
        {
            LoadModel(model);
            txtimei.ReadOnly = true;
        }

        private void InitControls()
        {
            cbostatus.Items.Clear();
            cbostatus.Items.Add("instock");
            cbostatus.Items.Add("sold");
            cbostatus.SelectedItem = "instock";
            cbostatus.DropDownStyle = UIDropDownStyle.DropDownList;

            ConfigureSkuDropdownColumns();
        }


        private void ConfigureSkuDropdownColumns()
        {
            var gridProperty = cboskucode.GetType().GetProperty("DataGridView");
            DataGridView? grid = gridProperty?.GetValue(cboskucode) as DataGridView;
            if (grid == null)
            {
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("SKUcode", typeof(string));
            table.Columns.Add("SKUname", typeof(string));
            foreach (ProductModel sku in _skuOptions)
            {
                table.Rows.Add(sku.SKUcode, sku.SKUname);
            }

            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SKUcode", HeaderText = "SKUcode", Width = 140 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SKUname", HeaderText = "SKUname", Width = 220 });
            grid.DataSource = table;

            SetComboMemberIfExists("DisplayMember", "SKUcode");
            SetComboMemberIfExists("ValueMember", "SKUcode");
        }

        private void SetComboMemberIfExists(string propertyName, string value)
        {
            PropertyInfo? property = cboskucode.GetType().GetProperty(propertyName);
            if (property?.CanWrite == true)
            {
                property.SetValue(cboskucode, value);
            }
        }

        private void LoadModel(imeiModel model)
        {
            txtimei.Text = model.imei;
            cbostatus.SelectedItem = string.Equals(model.status, "sold", StringComparison.OrdinalIgnoreCase) ? "sold" : "instock";

            if (!string.IsNullOrWhiteSpace(model.SKUcode) && _skuOptions.Any(x => x.SKUcode == model.SKUcode))
            {
                cboskucode.Text = model.SKUcode;
            }
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtimei.Text))
            {
                UIMessageTip.ShowWarning("IMEI 不能为空。");
                DialogResult = DialogResult.None;
                return;
            }

            string selectedSkuCode = GetSelectedSkuCode();
            if (string.IsNullOrWhiteSpace(selectedSkuCode))
            {
                UIMessageTip.ShowWarning("请选择 SKUcode。");
                DialogResult = DialogResult.None;
                return;
            }

            ImeiData = new imeiModel
            {
                imei = txtimei.Text.Trim(),
                status = string.Equals(cbostatus.Text, "sold", StringComparison.OrdinalIgnoreCase) ? "sold" : "instock",
                SKUcode = selectedSkuCode
            };
        }

        private string GetSelectedSkuCode()
        {
            string? reflectedValue = GetReflectedMemberValue("SelectedValue")
                ?? GetReflectedMemberValue("Value")
                ?? GetReflectedMemberValue("SelectedItem");

            if (!string.IsNullOrWhiteSpace(reflectedValue))
            {
                return reflectedValue;
            }

            string textValue = cboskucode.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(textValue))
            {
                return textValue;
            }

            var gridProperty = cboskucode.GetType().GetProperty("DataGridView");
            DataGridView? grid = gridProperty?.GetValue(cboskucode) as DataGridView;
            if (grid?.CurrentRow?.Cells.Count > 0 && grid.CurrentRow.Cells[0].Value is string skuCode && !string.IsNullOrWhiteSpace(skuCode))
            {
                return skuCode.Trim();
            }

            return string.Empty;
        }

        private string? GetReflectedMemberValue(string propertyName)
        {
            PropertyInfo? property = cboskucode.GetType().GetProperty(propertyName);
            object? value = property?.GetValue(cboskucode);
            return value?.ToString()?.Trim();
        }
    }
}
