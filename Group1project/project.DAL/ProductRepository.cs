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
            // Stock is inferred from tblimei rows where imei status indicates available (assuming status null or 0 means available)
            // Adjust condition if your status uses a specific value for sold.
            var sql = "SELECT COUNT(*) FROM tblimei WHERE Nz([status], 0) = 0";
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
