using Group1project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Group1project.project.DAL
{
    public class SaleDAL
    {
        public List<SalehistoryModel> GetSaleHistory(DateTime startDate, DateTime endDate, string invoiceKeyword, string username)
        {
            var result = new List<SalehistoryModel>();
            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();

            string sql = @"SELECT S.[invoice_id], S.[sell_date], S.[userId], S.[amount], S.[payment_type], U.[username]
                           FROM [tblsales] AS S
                           LEFT JOIN [tbluser] AS U ON S.[userId] = U.[userId]
                           WHERE S.[sell_date] >= ? AND S.[sell_date] < ?";

            using var cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@startDate", startDate.Date);
            cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1));

            if (!string.IsNullOrWhiteSpace(invoiceKeyword) && int.TryParse(invoiceKeyword.Trim(), out int invoiceId))
            {
                cmd.CommandText += " AND S.[invoice_id] = ?";
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
            }

            if (!string.IsNullOrWhiteSpace(username))
            {
                cmd.CommandText += " AND U.[username] LIKE ?";
                cmd.Parameters.AddWithValue("@username", $"%{username.Trim()}%");
            }

            cmd.CommandText += " ORDER BY S.[sell_date] DESC, S.[invoice_id] DESC";

            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return result;
            }

            while (reader.Read())
            {
                result.Add(new SalehistoryModel
                {
                    invoice_id = reader["invoice_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["invoice_id"]),
                    sell_date = reader["sell_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["sell_date"]),
                    userId = reader["userId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["userId"]),
                    amount = reader["amount"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["amount"]),
                    payment_type = reader["payment_type"] == DBNull.Value ? string.Empty : Convert.ToString(reader["payment_type"]) ?? string.Empty,
                    username = reader["username"] == DBNull.Value ? string.Empty : Convert.ToString(reader["username"]) ?? string.Empty
                });
            }

            return result;
        }

        public List<SaleInvoiceModel> GetInvoiceDetails(int invoiceId)
        {
            const string sql = @"SELECT D.[imei],
                                        IIF(I.[SKUcode] IS NULL OR I.[SKUcode]='', I.[statusSKUcode], I.[SKUcode]) AS [SKUcode],
                                        P.[SKUname],
                                        P.[retail_price] AS [unit_price]
                                 FROM [tblsdetail] AS D
                                 LEFT JOIN [tblimei] AS I ON D.[imei] = I.[imei]
                                 LEFT JOIN [tblproduct] AS P ON (I.[SKUcode] = P.[SKUcode]) OR (I.[statusSKUcode] = P.[SKUcode])
                                 WHERE D.[invoice_id] = ?
                                 ORDER BY D.[imei]";

            var result = new List<SaleInvoiceModel>();
            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return result;
            }

            while (reader.Read())
            {
                result.Add(new SaleInvoiceModel
                {
                    imei = reader["imei"] == DBNull.Value ? string.Empty : Convert.ToString(reader["imei"]) ?? string.Empty,
                    SKUcode = reader["SKUcode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SKUcode"]) ?? string.Empty,
                    SKUname = reader["SKUname"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SKUname"]) ?? string.Empty,
                    unit_price = reader["unit_price"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["unit_price"])
                });
            }

            return result;
        }

        public SaleInvoiceModel? GetInvoiceItemByImei(string imei)
        {
            const string sql = @"SELECT TOP 1 I.[imei],
                                        IIF(I.[SKUcode] IS NULL OR I.[SKUcode]='', I.[statusSKUcode], I.[SKUcode]) AS [SKUcode],
                                        P.[SKUname],
                                        P.[retail_price] AS [unit_price]
                                 FROM [tblimei] AS I
                                 LEFT JOIN [tblproduct] AS P ON (I.[SKUcode] = P.[SKUcode]) OR (I.[statusSKUcode] = P.[SKUcode])
                                 WHERE I.[imei] = ?";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@imei", imei.Trim());
            conn.Open();

            using var reader = cmd.ExecuteReader();
            if (reader == null || !reader.Read())
            {
                return null;
            }

            return new SaleInvoiceModel
            {
                imei = reader["imei"] == DBNull.Value ? string.Empty : Convert.ToString(reader["imei"]) ?? string.Empty,
                SKUcode = reader["SKUcode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SKUcode"]) ?? string.Empty,
                SKUname = reader["SKUname"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SKUname"]) ?? string.Empty,
                unit_price = reader["unit_price"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["unit_price"])
            };
        }

        public bool IsImeiInStock(string imei)
        {
            const string sql = "SELECT TOP 1 [status] FROM [tblimei] WHERE [imei] = ?";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@imei", imei.Trim());
            conn.Open();

            object? status = cmd.ExecuteScalar();
            if (status == null || status == DBNull.Value)
            {
                return false;
            }

            return string.Equals(Convert.ToString(status)?.Trim(), "instock", StringComparison.OrdinalIgnoreCase);
        }

        public List<UserModel> GetActiveUsers()
        {
            const string sql = @"SELECT [userId], [username], [status]
                                 FROM [tbluser]
                                 WHERE [status] = True
                                 ORDER BY [userId]";
            return DBHelper.Query<UserModel>(sql);
        }

        public int GetNextInvoiceId()
        {
            const string sql = "SELECT MAX([invoice_id]) FROM [tblsales]";
            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            conn.Open();
            object? value = cmd.ExecuteScalar();
            int max = value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
            return max + 1;
        }

        public bool SaveSale(int invoiceId, DateTime sellDate, int userId, string paymentType, List<SaleInvoiceModel> items)
        {
            if (items.Count == 0)
            {
                return false;
            }

            decimal amount = 0m;
            foreach (SaleInvoiceModel item in items)
            {
                amount += item.unit_price;
            }

            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                const string insertSaleSql = @"INSERT INTO [tblsales] ([invoice_id], [sell_date], [userId], [amount], [payment_type])
                                              VALUES (?,?,?,?,?)";
                using (var saleCmd = new OleDbCommand(insertSaleSql, conn, trans))
                {
                    saleCmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                    saleCmd.Parameters.AddWithValue("@sell_date", sellDate);
                    saleCmd.Parameters.AddWithValue("@userId", userId);
                    saleCmd.Parameters.AddWithValue("@amount", amount);
                    saleCmd.Parameters.AddWithValue("@payment_type", paymentType?.Trim() ?? string.Empty);
                    saleCmd.ExecuteNonQuery();
                }

                foreach (SaleInvoiceModel item in items)
                {
                    const string insertDetailSql = "INSERT INTO [tblsdetail] ([invoice_id], [imei]) VALUES (?,?)";
                    using (var detailCmd = new OleDbCommand(insertDetailSql, conn, trans))
                    {
                        detailCmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                        detailCmd.Parameters.AddWithValue("@imei", item.imei);
                        detailCmd.ExecuteNonQuery();
                    }

                    const string updateImeiSql = "UPDATE [tblimei] SET [status] = 'sold' WHERE [imei] = ?";
                    using var imeiCmd = new OleDbCommand(updateImeiSql, conn, trans);
                    imeiCmd.Parameters.AddWithValue("@imei", item.imei);
                    imeiCmd.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
        }

        private static string GetConnectionString()
        {
            using var conn = DBHelper.GetConnection();
            return conn.ConnectionString;
        }
    }
}
