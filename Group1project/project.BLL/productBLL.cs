using Group1project.Model;
using Group1project.project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Group1project.project.BLL
{
    public class ProductBLL
    {
        private readonly ProductDAL _productDal = new ProductDAL();

        public List<ProductModel> GetAllProducts()
        {
            return _productDal.GetAllProductsWithStock();
        }

        public List<ProductModel> SearchBySKUName(List<ProductModel> products, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return products;
            }

            string normalized = keyword.Trim();
            return products
                .Where(p => !string.IsNullOrWhiteSpace(p.SKUname)
                         && p.SKUname.Contains(normalized, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public int AddProduct(ProductModel product)
        {
            product.creative_time = DateTime.Now;
            product.edit_time = DateTime.Now;
            return _productDal.AddProduct(product);
        }

        public int UpdateProduct(ProductModel product, DateTime createTime, string originalSkuCode)
        {
            product.creative_time = createTime;
            product.edit_time = DateTime.Now;
            return _productDal.UpdateProduct(product, originalSkuCode);
        }
    }
}
