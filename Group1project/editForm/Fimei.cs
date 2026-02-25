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
        private DataGridView? _skuGrid;
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
            DataTable table = new DataTable();
            table.Columns.Add("SKUcode", typeof(string));
            table.Columns.Add("SKUname", typeof(string));
            foreach (ProductModel sku in _skuOptions)
            {
                table.Rows.Add(sku.SKUcode, sku.SKUname);
            }

            _skuGrid = GetSkuGrid();
            if (_skuGrid != null)
            {
                _skuGrid.AutoGenerateColumns = false;
                _skuGrid.ReadOnly = true;
                _skuGrid.MultiSelect = false;
                _skuGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                _skuGrid.Columns.Clear();
                _skuGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SKUcode", HeaderText = "SKUcode", Width = 140, MinimumWidth = 120 });
                _skuGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SKUname", HeaderText = "SKUname", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth = 300 });
                _skuGrid.DataSource = table;
                _skuGrid.CellClick -= SkuGrid_CellClick;
                _skuGrid.CellClick += SkuGrid_CellClick;
            }

            SetComboMemberIfExists("DataSource", table);
            SetComboMemberIfExists("DisplayMember", "SKUcode");
            SetComboMemberIfExists("ValueMember", "SKUcode");
            SetComboMemberIfExists("DropDownWidth", 520);
            SetComboMemberIfExists("DropDownStyle", UIDropDownStyle.DropDownList);
        }

        private DataGridView? GetSkuGrid()
        {
            var gridProperty = cboskucode.GetType().GetProperty("DataGridView");
            return gridProperty?.GetValue(cboskucode) as DataGridView;
        }

        private void SkuGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (_skuGrid?.CurrentRow?.Cells.Count < 1)
            {
                return;
            }

            string skuCode = _skuGrid.CurrentRow.Cells[0].Value?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(skuCode))
            {
                return;
            }

            cboskucode.Text = skuCode;
            SetComboMemberIfExists("SelectedValue", skuCode);
        }

        private void SetComboMemberIfExists(string propertyName, object value)
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
                SetComboMemberIfExists("SelectedValue", model.SKUcode);
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

            if (_skuGrid?.CurrentRow?.Cells.Count > 0 && _skuGrid.CurrentRow.Cells[0].Value is string skuCode && !string.IsNullOrWhiteSpace(skuCode))
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
