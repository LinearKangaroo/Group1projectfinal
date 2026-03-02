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
    public partial class FrmUproduct : UIPage
    {
        private const string AllBrandText = "All Brand";
        private readonly ProductBLL _productBll = new ProductBLL();
        private List<ProductModel> _allProducts = new List<ProductModel>();
        private UIComboBox? _brandCombo;
        public FrmUproduct()
        {
            InitializeComponent();
            Load += FrmUproduct_Load;
            btnSearch.Click += BtnSearch_Click;
            txtproduct.ButtonClick += Txtproduct_ButtonClick;
            txtproduct.TextChanged += Txtproduct_TextChanged;
        }
        private void FrmUproduct_Load(object? sender, EventArgs e)
        {
            EnsureBrandComboBox();
            LoadProducts();
        }

        private void EnsureBrandComboBox()
        {
            _brandCombo = Controls.Find("cbobrand", true).FirstOrDefault() as UIComboBox;
            if (_brandCombo == null)
            {
                _brandCombo = new UIComboBox
                {
                    Name = "cbobrand",
                    Font = txtproduct.Font,
                    Location = new System.Drawing.Point(19, 373),
                    Size = new System.Drawing.Size(180, 34),
                    DropDownStyle = UIDropDownStyle.DropDownList
                };

                Controls.Add(_brandCombo);
                Controls.SetChildIndex(_brandCombo, 0);
            }

            _brandCombo.SelectedIndexChanged -= Cbobrand_SelectedIndexChanged;
            _brandCombo.SelectedIndexChanged += Cbobrand_SelectedIndexChanged;
        }

        private void LoadProducts()
        {
            _allProducts = _productBll.GetAllProducts();
            ApplyFilters();
            BindGrid(_allProducts);
            PopulateBrandFilter();
        }

        private void PopulateBrandFilter()
        {
            if (_brandCombo == null)
            {
                return;
            }

            string selected = _brandCombo.Text?.Trim() ?? string.Empty;
            List<string> brands = _allProducts
                .Select(p => p.brand?.Trim())
                .Where(b => !string.IsNullOrWhiteSpace(b))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(b => b)
                .Cast<string>()
                .ToList();

            _brandCombo.Items.Clear();
            _brandCombo.Items.Add(AllBrandText);
            foreach (string brand in brands)
            {
                _brandCombo.Items.Add(brand);
            }

            int index = 0;
            if (!string.IsNullOrWhiteSpace(selected) && !string.Equals(selected, AllBrandText, StringComparison.OrdinalIgnoreCase))
            {
                int found = brands.FindIndex(b => string.Equals(b, selected, StringComparison.OrdinalIgnoreCase));
                if (found >= 0)
                {
                    index = found + 1;
                }
            }

            _brandCombo.SelectedIndex = index;
        }
        private void Cbobrand_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BindGrid(List<ProductModel> products)
        {
            dgvproduct.AutoGenerateColumns = true;
            dgvproduct.DataSource = null;
            dgvproduct.DataSource = products;
            dgvproduct.Columns["purchase_price"].Visible = false;
            dgvproduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchProducts();
        }

        private void Txtproduct_ButtonClick(object? sender, EventArgs e)
        {
            txtproduct.Text = string.Empty;
            if (_brandCombo != null)
            {
                _brandCombo.SelectedIndex = 0;
            }
            ApplyFilters();
        }

        private void Txtproduct_TextChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void SearchProducts()
        {
            ApplyFilters(showTip: true);
        }

        private void ApplyFilters(bool showTip = false)
        {
            IEnumerable<ProductModel> filtered = _allProducts;

            string keyword = txtproduct.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filtered = filtered.Where(p => !string.IsNullOrWhiteSpace(p.SKUname)
                                            && p.SKUname.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            string selectedBrand = _brandCombo?.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(selectedBrand)
                && !string.Equals(selectedBrand, AllBrandText, StringComparison.OrdinalIgnoreCase))
            {
                filtered = filtered.Where(p => string.Equals(p.brand?.Trim(), selectedBrand, StringComparison.OrdinalIgnoreCase));
            }

            List<ProductModel> result = filtered.ToList();
            BindGrid(result);

            if (showTip)
            {
                UIMessageTip.Show($"Found {result.Count} product(s).");
            }
        }
    }
}
