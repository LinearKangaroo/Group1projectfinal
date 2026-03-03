using Group1project.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;

namespace Group1project.project.DAL
{
    public class SaleDAL
    {

        public List<SalehistoryModel> GetSaleHistory(DateTime startDate, DateTime endDate, string invoiceKeyword, string username)
        {
            var result = new List<SalehistoryModel>();
            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();

            string sql = @"SELECT S.[invoice_id], S.[sell_date], S.[userId], U.[username], S.[amount], S.[payment_type], S.[customer], S.[address]
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
                    username = reader["username"] == DBNull.Value ? string.Empty : Convert.ToString(reader["username"]) ?? string.Empty,
                    customer = reader["customer"] == DBNull.Value ? string.Empty : Convert.ToString(reader["customer"]) ?? string.Empty,
                    address = reader["address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["address"]) ?? string.Empty
                });
            }

            return result;
        }

        public List<SaleInvoiceModel> GetInvoiceDetails(int invoiceId)
        {
            var result = new List<SaleInvoiceModel>();

            const string detailSql = @"SELECT *
                                       FROM [tblsdetail]
                                       WHERE [invoice_id] = ?
                                       ORDER BY [imei]";

            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();

            using var detailCmd = new OleDbCommand(detailSql, conn);
            detailCmd.Parameters.AddWithValue("@invoiceId", invoiceId);
            using var detailReader = detailCmd.ExecuteReader();
            if (detailReader == null)
            {
                return result;
            }

            while (detailReader.Read())
            {
                if (detailReader["imei"] == DBNull.Value)
                {
                    continue;
                }

                string imei = Convert.ToString(detailReader["imei"])?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(imei))
                {
                    continue;
                }

                SaleInvoiceModel? item = GetInvoiceItemByImei(conn, imei);
                if (item != null)
                {
                    if (GetOrdinalSafe(detailReader, "unit_price") >= 0)
                    {
                        decimal detailUnitPrice = GetDecimalSafe(detailReader, "unit_price");
                        if (detailUnitPrice > 0)
                        {
                            item.unit_price = detailUnitPrice;
                        }
                    }

                    result.Add(item);
                }
            }

            return result;
        }

        public SaleInvoiceModel? GetInvoiceItemByImei(string imei)
        {
            if (string.IsNullOrWhiteSpace(imei))
            {
                return null;
            }

            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();
            return GetInvoiceItemByImei(conn, imei.Trim());
        }

        private static SaleInvoiceModel? GetInvoiceItemByImei(OleDbConnection conn, string imei)
        {
            const string imeiSql = @"SELECT TOP 1 *
                                     FROM [tblimei]
                                     WHERE [imei] = ?";

            using var imeiCmd = new OleDbCommand(imeiSql, conn);
            imeiCmd.Parameters.AddWithValue("@imei", imei);
            using var imeiReader = imeiCmd.ExecuteReader();
            if (imeiReader == null || !imeiReader.Read())
            {
                return null;
            }

            string skuCode = GetStringSafe(imeiReader, "SKUcode");
            string statusSkuCode = FirstNonEmpty(
                GetStringSafe(imeiReader, "statusSKUcode"),
                GetStringSafe(imeiReader, "StatusSKUcode"),
                GetStringSafe(imeiReader, "status_sku_code"));
            string resolvedSkuCode = string.IsNullOrWhiteSpace(skuCode) ? statusSkuCode : skuCode;

            decimal unitPrice = 0m;
            string skuName = string.Empty;

            if (!string.IsNullOrWhiteSpace(resolvedSkuCode))
            {
                const string productSql = @"SELECT TOP 1 [SKUname], [retail_price]
                                           FROM [tblproduct]
                                           WHERE [SKUcode] = ?";
                using var productCmd = new OleDbCommand(productSql, conn);
                productCmd.Parameters.AddWithValue("@skuCode", resolvedSkuCode);
                using var productReader = productCmd.ExecuteReader();
                if (productReader != null && productReader.Read())
                {
                    skuName = GetStringSafe(productReader, "SKUname");
                    unitPrice = GetDecimalSafe(productReader, "retail_price");
                }
            }

            return new SaleInvoiceModel
            {
                imei = imei,
                SKUcode = resolvedSkuCode,
                SKUname = skuName,
                unit_price = unitPrice
            };
        }

        private static string FirstNonEmpty(params string[] values)
        {
            foreach (string value in values)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }
            }

            return string.Empty;
        }

        private static int GetOrdinalSafe(System.Data.IDataRecord reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (string.Equals(reader.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        private static string GetStringSafe(System.Data.IDataRecord reader, string columnName)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return string.Empty;
            }

            return Convert.ToString(reader.GetValue(ordinal)) ?? string.Empty;
        }

        private static decimal GetDecimalSafe(System.Data.IDataRecord reader, string columnName)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return 0m;
            }

            return Convert.ToDecimal(reader.GetValue(ordinal));
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

        public bool SaveSale(int invoiceId, DateTime sellDate, int userId, string paymentType, string customer, string address, List<SaleInvoiceModel> items)
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
                const string insertSaleSql = @"INSERT INTO [tblsales] ([invoice_id], [sell_date], [userId], [amount], [payment_type], [customer], [address])
                                              VALUES (?,?,?,?,?,?,?)";
                using (var saleCmd = new OleDbCommand(insertSaleSql, conn, trans))
                {
                    saleCmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                    saleCmd.Parameters.AddWithValue("@sell_date", sellDate);
                    saleCmd.Parameters.AddWithValue("@userId", userId);
                    saleCmd.Parameters.AddWithValue("@amount", amount);
                    saleCmd.Parameters.AddWithValue("@payment_type", paymentType?.Trim() ?? string.Empty);
                    saleCmd.Parameters.AddWithValue("@customer", customer);
                    saleCmd.Parameters.AddWithValue("@address", address);
                    saleCmd.ExecuteNonQuery();
                }

                foreach (SaleInvoiceModel item in items)
                {
                    const string insertDetailSql = "INSERT INTO [tblsdetail] ([invoice_id], [imei], [unit_price]) VALUES (?,?,?)";
                    using (var detailCmd = new OleDbCommand(insertDetailSql, conn, trans))
                    {
                        detailCmd.Parameters.AddWithValue("@invoice_id", invoiceId);
                        detailCmd.Parameters.AddWithValue("@imei", item.imei);
                        detailCmd.Parameters.AddWithValue("@unit_price", item.unit_price);
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

        public int GetTodaySalesQuantity()
        {
            const string sql = @"SELECT COUNT(*)
                                 FROM [tblsdetail] AS D
                                 INNER JOIN [tblsales] AS S ON D.[invoice_id] = S.[invoice_id]
                                 WHERE DateValue(S.[sell_date]) = Date()";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            conn.Open();

            object? result = cmd.ExecuteScalar();
            return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        public decimal GetTodaySalesProfit()
        {
            const string sql = @"SELECT [unit_price], [purchase_price]
                                 FROM [Qtodaysale]";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            conn.Open();

            decimal profit = 0m;
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return 0m;
            }

            while (reader.Read())
            {
                decimal retail = GetDecimalSafe(reader, "unit_price");
                decimal purchase = GetDecimalSafe(reader, "purchase_price");
                profit += retail - purchase;
            }

            return profit;
        }

        public string GetTodayHotSellSpuName()
        {
            const string sql = @"SELECT TOP 1 
                                    SPUname, 
                                    COUNT(*) AS saleCount
                                FROM 
                                    Qtodaysale
                                WHERE 
                                    SPUname IS NOT NULL
                                GROUP BY 
                                    SPUname
                                ORDER BY 
                                    COUNT(*) DESC";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            if (reader == null || !reader.Read())
            {
                return string.Empty;
            }

            return GetStringSafe(reader, "SPUname");
        }

        public List<DailySalesPointModel> GetRecent7DaySales()
        {
            const string sql = @"SELECT DateValue(S.[sell_date]) AS SellDay, COUNT(*) AS Qty
                                 FROM [tblsdetail] AS D
                                 INNER JOIN [tblsales] AS S ON D.[invoice_id] = S.[invoice_id]
                                 WHERE DateValue(S.[sell_date]) >= Date()-6 AND DateValue(S.[sell_date]) <= Date()
                                 GROUP BY DateValue(S.[sell_date])";

            DateTime startDate = DateTime.Today.AddDays(-6);
            var resultMap = new Dictionary<DateTime, int>();

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            conn.Open();

            using (var reader = cmd.ExecuteReader())
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        DateTime date = Convert.ToDateTime(reader[0]).Date;
                        int qty = reader[1] == DBNull.Value ? 0 : Convert.ToInt32(reader[1]);
                        resultMap[date] = qty;
                    }
                }
            }

            var points = new List<DailySalesPointModel>();
            for (int i = 0; i < 7; i++)
            {
                DateTime date = startDate.AddDays(i).Date;
                points.Add(new DailySalesPointModel
                {
                    Date = date,
                    Quantity = resultMap.TryGetValue(date, out int qty) ? qty : 0
                });
            }

            return points;
        }

        public List<BrandSalesRatioModel> GetTodayBrandSalesRatios()
        {
            const string sql = @"SELECT [brand], COUNT(*) AS Qty
                                 FROM [Qtodaysale]
                                 GROUP BY [brand]";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            conn.Open();

            var ratios = new List<BrandSalesRatioModel>();
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return ratios;
            }

            while (reader.Read())
            {
                string brand = GetStringSafe(reader, "brand");
                ratios.Add(new BrandSalesRatioModel
                {
                    Brand = string.IsNullOrWhiteSpace(brand) ? "Unknown" : brand,
                    Quantity = reader[1] == DBNull.Value ? 0 : Convert.ToInt32(reader[1])
                });
            }

            return ratios;
        }

        private static string GetConnectionString()
        {
            using var conn = DBHelper.GetConnection();
            return conn.ConnectionString;
        }
    }
}
