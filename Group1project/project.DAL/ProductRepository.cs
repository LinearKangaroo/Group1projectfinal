using System.Data;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace Group1project.project.DAL
{
    public class ProductRepository
    {
        public int GetTotalStock()
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();
            var sql = "SELECT SUM(stockQTY) FROM QstockQTY";
            var res = conn.ExecuteScalar(sql);
            return res == null || res == System.DBNull.Value ? 0 : System.Convert.ToInt32(res);
        }

        public IEnumerable<(int Id, int Stock)> GetProductStocks()
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();
            // Return product SKUcode as Id (string) and stock count per SKU
            var sql = "SELECT P.SKUcode, P.SKUname, COUNT(I.imei) AS StockCount FROM tblproduct P LEFT JOIN tblimei I ON I.statusSKUcode = P.SKUcode AND Nz(I.[status],0)=0 GROUP BY P.SKUcode, P.SKUname";
            var rows = conn.Query(sql);
            foreach (var r in rows)
            {
                yield return (0, Convert.ToInt32(r.StockCount));
            }
        }

        public string GetProductName(int id)
        {
            return string.Empty; // not used in current implementation
        }
    }
}
