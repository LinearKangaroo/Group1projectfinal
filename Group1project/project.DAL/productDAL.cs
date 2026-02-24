using Group1project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace Group1project.project.DAL
{
    public class ProductDAL
    {
        public List<ProductModel> GetAllProductsWithStock()
        {
            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();

            // 优先尝试你在 Access 中保存的查询；若该查询含有 OLEDB 不支持函数（如 Nz）则自动回退
            if (TryReadProductsFromSavedQuery(conn, out List<ProductModel> queryProducts))
            {
                return queryProducts
                    .OrderBy(p => p.SKUcode, StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }

            List<ProductModel> products = ReadProducts(conn, "SELECT * FROM [tblproduct]");
            Dictionary<string, int> stockMap = BuildStockMap(conn);

            foreach (ProductModel product in products)
            {
                string key = product.SKUcode?.Trim() ?? string.Empty;
                product.Stock = stockMap.TryGetValue(key, out int qty) ? qty : 0;
            }

            return products
                .OrderBy(p => p.SKUcode, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private static bool TryReadProductsFromSavedQuery(OleDbConnection conn, out List<ProductModel> products)
        {
            try
            {
                products = ReadProducts(conn, "SELECT * FROM [Qstocklist]");
                return true;
            }
            catch (OleDbException)
            {
                products = new List<ProductModel>();
                return false;
            }
        }

        private static Dictionary<string, int> BuildStockMap(OleDbConnection conn)
        {
            // 故意不在 SQL 中使用 Nz/LCase，全部在 C# 做兼容处理
            const string sql = "SELECT * FROM [tblimei]";
            var stockMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return stockMap;
            }

            while (reader.Read())
            {
                string status = GetString(reader, "status");
                if (!string.Equals(status?.Trim(), "instock", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string sku = FirstNonEmpty(
                    GetString(reader, "statusSKUcode"),
                    GetString(reader, "SKUcode"));

                if (string.IsNullOrWhiteSpace(sku))
                {
                    continue;
                }

                string key = sku.Trim();
                stockMap[key] = stockMap.TryGetValue(key, out int qty) ? qty + 1 : 1;
            }

            return stockMap;
        }

        public int AddProduct(ProductModel product)
        {
            const string sql = @"INSERT INTO [tblproduct]
                                 ([SPUcode],[SPUname],[brand],[SKUspec],[SKUname],[purchase_price],[retail_price],[creative_time],[edit_time])
                                 VALUES
                                 (?,?,?,?,?,?,?,?,?)";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);

            cmd.Parameters.AddWithValue("@SPUcode", DbNullIfWhiteSpace(product.SPUcode));
            cmd.Parameters.AddWithValue("@SPUname", DbNullIfWhiteSpace(product.SPUname));
            cmd.Parameters.AddWithValue("@brand", DbNullIfWhiteSpace(product.brand));
            cmd.Parameters.AddWithValue("@SKUspec", DbNullIfWhiteSpace(product.SKUspec));
            cmd.Parameters.AddWithValue("@SKUname", DbNullIfWhiteSpace(product.SKUname));
            cmd.Parameters.AddWithValue("@purchase_price", product.purchase_price);
            cmd.Parameters.AddWithValue("@retail_price", product.retail_price);
            cmd.Parameters.AddWithValue("@creative_time", product.creative_time.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@edite_time", product.edit_time.ToString("yyyy-MM-dd HH:mm:ss"));

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdateProduct(ProductModel product, string originalSkuCode)
        {
            const string sql = @"UPDATE [tblproduct]
                                 SET [SPUcode]=?,
                                     [SPUname]=?,
                                     [brand]=?,
                                     [SKUspec]=?,
                                     [SKUname]=?,
                                     [purchase_price]=?,
                                     [retail_price]=?,
                                     [edit_time]=?
                                 WHERE [SKUcode]=?";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);

            cmd.Parameters.AddWithValue("@SPUcode", DbNullIfWhiteSpace(product.SPUcode));
            cmd.Parameters.AddWithValue("@SPUname", DbNullIfWhiteSpace(product.SPUname));
            cmd.Parameters.AddWithValue("@brand", DbNullIfWhiteSpace(product.brand));
            cmd.Parameters.AddWithValue("@SKUspec", DbNullIfWhiteSpace(product.SKUspec));
            cmd.Parameters.AddWithValue("@SKUname", DbNullIfWhiteSpace(product.SKUname));
            cmd.Parameters.AddWithValue("@purchase_price", product.purchase_price);
            cmd.Parameters.AddWithValue("@retail_price", product.retail_price);
            cmd.Parameters.AddWithValue("@edit_time", product.edit_time.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@originalSKUcode", DbNullIfWhiteSpace(originalSkuCode));

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        private static List<ProductModel> ReadProducts(OleDbConnection conn, string sql)
        {
            var products = new List<ProductModel>();

            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return products;
            }

            while (reader.Read())
            {
                products.Add(new ProductModel
                {
                    SKUcode = GetString(reader, "SKUcode"),
                    SPUcode = GetString(reader, "SPUcode"),
                    SPUname = GetString(reader, "SPUname"),
                    brand = GetString(reader, "brand"),
                    SKUspec = GetString(reader, "SKUspec"),
                    SKUname = GetString(reader, "SKUname"),
                    purchase_price = GetDecimal(reader, "purchase_price"),
                    retail_price = GetDecimal(reader, "retail_price"),
                    creative_time = GetDateTime(reader, "creative_time", "creative_time"),
                    edit_time = GetDateTime(reader, "edit_time", "edit_time"),
                    Stock = GetInt(reader, "stockQTY", "Stock", "stock")
                });
            }

            return products;
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

        private static int GetOrdinalSafe(IDataRecord reader, string columnName)
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

        private static string GetString(IDataRecord reader, string columnName)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return string.Empty;
            }

            return Convert.ToString(reader.GetValue(ordinal)) ?? string.Empty;
        }

        private static decimal GetDecimal(IDataRecord reader, string columnName)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return 0m;
            }

            return Convert.ToDecimal(reader.GetValue(ordinal));
        }

        private static DateTime GetDateTime(IDataRecord reader, params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                int ordinal = GetOrdinalSafe(reader, columnName);
                if (ordinal >= 0 && !reader.IsDBNull(ordinal))
                {
                    return Convert.ToDateTime(reader.GetValue(ordinal));
                }
            }

            return DateTime.MinValue;
        }

        private static int GetInt(IDataRecord reader, params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                int ordinal = GetOrdinalSafe(reader, columnName);
                if (ordinal >= 0 && !reader.IsDBNull(ordinal))
                {
                    return Convert.ToInt32(reader.GetValue(ordinal));
                }
            }

            return 0;
        }

        private static string GetConnectionString()
        {
            using var conn = DBHelper.GetConnection();
            return conn.ConnectionString;
        }

        private static object DbNullIfWhiteSpace(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? DBNull.Value : value.Trim();
        }
    }
}
