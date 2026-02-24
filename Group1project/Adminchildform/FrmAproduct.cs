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
    public partial class FrmAproduct : UIPage
    {
        private readonly ProductBLL _productBll = new ProductBLL();
        private List<ProductModel> _allProducts = new List<ProductModel>();
        public FrmAproduct()
        {
            InitializeComponent();

            Load += FrmAproduct_Load;
            btnSearch.Click += BtnSearch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            txtproduct.ButtonClick += Txtproduct_ButtonClick;
            txtproduct.TextChanged += Txtproduct_TextChanged;
        }

        private void FrmAproduct_Load(object? sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            _allProducts = _productBll.GetAllProducts();
            BindGrid(_allProducts);
        }

        private void BindGrid(List<ProductModel> products)
        {
            dgvproduct.AutoGenerateColumns = true;
            dgvproduct.DataSource = null;
            dgvproduct.DataSource = products;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchProducts();
        }

        private void Txtproduct_ButtonClick(object? sender, EventArgs e)
        {
            txtproduct.Text = string.Empty;
            btnSearch.PerformClick();
        }

        private void Txtproduct_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproduct.Text))
            {
                LoadProducts();
            }
        }

        private void SearchProducts()
        {
            string keyword = txtproduct.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadProducts();
                return;
            }

            _allProducts = _productBll.GetAllProducts();
            List<ProductModel> filteredProducts = _productBll.SearchBySKUName(_allProducts, keyword);
            BindGrid(filteredProducts);
            UIMessageTip.Show($"Found {filteredProducts.Count} product(s).");
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var editForm = new Fproductedit();
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!UIMessageBox.ShowAsk("Confirm adding this product?"))
            {
                return;
            }

            int rows = _productBll.AddProduct(editForm.ProductData);
            if (rows > 0)
            {
                UIMessageTip.ShowOk("Product added successfully.");
                LoadProducts();
                return;
            }

            UIMessageBox.ShowError("Failed to add product.");
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvproduct.CurrentRow?.DataBoundItem is not ProductModel selectedProduct)
            {
                UIMessageTip.ShowWarning("Please select a product to edit.");
                return;
            }

            var editForm = new Fproductedit(selectedProduct);
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!UIMessageBox.ShowAsk("Confirm updating this product?"))
            {
                return;
            }

            ProductModel updatedProduct = editForm.ProductData;
            int rows = _productBll.UpdateProduct(updatedProduct, selectedProduct.creative_time, selectedProduct.SKUcode);
            if (rows > 0)
            {
                UIMessageTip.ShowOk("Product updated successfully.");
                LoadProducts();
                return;
            }

            UIMessageBox.ShowError("Failed to update product.");
        }
    }
}
