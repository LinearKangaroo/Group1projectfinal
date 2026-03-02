using Group1project.Model;
using Group1project.project.DAL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Group1project.editForm
{
    
    public partial class Fproductedit : UIEditForm
    {
        private readonly bool _isEditMode;
        public ProductModel ProductData { get; private set; } = new ProductModel();
        public Fproductedit()
        {
            InitializeComponent();
            _isEditMode = false;
            InitInputHints();
            InitForAddMode();
            BindAutoSkuNameEvents();
            btnOK.Click += BtnOK_Click;
        }

        public Fproductedit(ProductModel product) : this()
        {
            _isEditMode = true;
            LoadProduct(product);
            txtskucode.ReadOnly = true;
        }

        private void InitInputHints()
        {
            txtskucode.Watermark = "Auto Number";
            txtspucode.Watermark = "Please input Standard Product Unit Code";
            txtspuname.Watermark = "Standard Product Unit Name";
            txtbrand.Watermark = "Brand Name";
            txtskuspec.Watermark = "Product Specification";
            txtskuname.Watermark = "Stock Keeping Unit Name";
            txtpprice.Watermark = "Enter Number";
            txtrprice.Watermark = "Enter Number";
        }

        private void BindAutoSkuNameEvents()
        {
            txtbrand.TextChanged += AutoBuildSkuName;
            txtspuname.TextChanged += AutoBuildSkuName;
            txtskuspec.TextChanged += AutoBuildSkuName;
        }

        private void InitForAddMode()
        {
            txtskucode.Text = "Auto Generate";
            txtskucode.ReadOnly = true;
            txtskuname.ReadOnly = true;
        }

        private void LoadProduct(ProductModel product)
        {
            txtskucode.Text = product.SKUcode;
            txtspucode.Text = product.SPUcode;
            txtspuname.Text = product.SPUname;
            txtbrand.Text = product.brand;
            txtskuspec.Text = product.SKUspec;
            txtskuname.Text = product.SKUname;
            txtpprice.Text = product.purchase_price.ToString(CultureInfo.InvariantCulture);
            txtrprice.Text = product.retail_price.ToString(CultureInfo.InvariantCulture);

            txtskuname.ReadOnly = false;
        }

        private void AutoBuildSkuName(object? sender, EventArgs e)
        {
            if (_isEditMode)
            {
                return;
            }

            string brand = txtbrand.Text?.Trim() ?? string.Empty;
            string spuName = txtspuname.Text?.Trim() ?? string.Empty;
            string skuSpec = txtskuspec.Text?.Trim() ?? string.Empty;

            txtskuname.Text = $"{brand}{spuName}{skuSpec}";
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            if (_isEditMode && string.IsNullOrWhiteSpace(txtskucode.Text))
            {
                UIMessageTip.ShowWarning("In the editing mode, the SKU code cannot be left blank.");
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtskuname.Text))
            {
                UIMessageTip.ShowWarning("SKUname cannot be left blank.");
                DialogResult = DialogResult.None;
                return;
            }

            if (!decimal.TryParse(txtpprice.Text?.Trim(), out decimal purchasePrice))
            {
                UIMessageTip.ShowWarning("Purchase Price format is incorrect.");
                DialogResult = DialogResult.None;
                return;
            }

            if (!decimal.TryParse(txtrprice.Text?.Trim(), out decimal retailPrice))
            {
                UIMessageTip.ShowWarning("Retail Price format is incorrect.");
                DialogResult = DialogResult.None;
                return;
            }

            ProductData = new ProductModel
            {
                SKUcode = _isEditMode ? txtskucode.Text.Trim() : string.Empty,
                SPUcode = txtspucode.Text.Trim(),
                SPUname = txtspuname.Text.Trim(),
                brand = txtbrand.Text.Trim(),
                SKUspec = txtskuspec.Text.Trim(),
                SKUname = txtskuname.Text.Trim(),
                purchase_price = purchasePrice,
                retail_price = retailPrice
            };
        }
        
    }
}
