using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Group1project.project.DAL;
using System.Data;

namespace Group1project.project.BLL
{
    public class SalesService
    {
        // Returns total sell quantity for today across all products
        public int GetTodaySellOut()
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();
            // count sold items (details) for today
            var sql = "SELECT COUNT(*) FROM tblsdetail SD INNER JOIN tblsales S ON SD.invoice_id = S.invoice_id WHERE DateValue([sell_date]) = ?";
            var res = conn.ExecuteScalar(sql, new { Date = DateTime.Today });
            return res == null || res == DBNull.Value ? 0 : Convert.ToInt32(res);
        }

        // Returns total stock across all products
        public int GetTotalStock()
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();
            var sql = "SELECT SUM(Stock) FROM Products";
            var res = conn.ExecuteScalar(sql);
            return res == null || res == DBNull.Value ? 0 : Convert.ToInt32(res);
        }

        // Returns total sales amount for today
        public decimal GetTodayAmount()
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();
            var sql = "SELECT SUM(amount) FROM tblsales WHERE DateValue([sell_date]) = ?";
            var res = conn.ExecuteScalar(sql, new { Date = DateTime.Today });
            return res == null || res == DBNull.Value ? 0m : Convert.ToDecimal(res);
        }

        // Returns best selling product name for today
        public string GetTodayBestSell()
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();
            // Join sale details -> imei -> product to get SKUname and count sold today
            var sql = @"SELECT TOP 1 P.SKUname, COUNT(*) AS Qty
                        FROM tblsdetail SD
                        INNER JOIN tblsales S ON SD.invoice_id = S.invoice_id
                        INNER JOIN tblimei I ON SD.imei = I.imei
                        INNER JOIN tblproduct P ON I.statusSKUcode = P.SKUcode
                        WHERE DateValue(S.sell_date) = ?
                        GROUP BY P.SKUname
                        ORDER BY Qty DESC";
            var r = conn.QueryFirstOrDefault(sql, new { Date = DateTime.Today });
            if (r == null) return string.Empty;
            return r.SKUname ?? string.Empty;
        }
        // Average daily sold items (total across all products) for the last 7 days
        public decimal GetAverageDailySalesLast7DaysTotal()
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();
            var sql = @"SELECT COUNT(*) FROM tblsdetail SD INNER JOIN tblsales S ON SD.invoice_id = S.invoice_id WHERE S.sell_date >= ? AND S.sell_date < ?";
            var start = DateTime.Today.AddDays(-7);
            var end = DateTime.Today.AddDays(1);
            var res = conn.ExecuteScalar(sql, new { start, end });
            var total = res == null || res == DBNull.Value ? 0M : Convert.ToDecimal(res);
            return total / 7M;
        }
    }
}
