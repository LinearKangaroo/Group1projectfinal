using System;
using System.Collections.Generic;
using System.Linq;
using Group1project.project.DAL;

namespace Group1project.project.BLL
{
    public class ProductService
    {
        private readonly ProductRepository _repo = new ProductRepository();

        public int GetTotalStock() => _repo.GetTotalStock();

        public IEnumerable<(int Id, int Stock)> GetProductStocks() => _repo.GetProductStocks();

        public string GetProductName(int id) => _repo.GetProductName(id);
    }
}
