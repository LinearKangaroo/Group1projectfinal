using Group1project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace Group1project.project.DAL
{
    public class AnalysisDAL
    {
        private sealed class ProductInfo
        {
            public string SKUcode { get; set; } = string.Empty;
            public string SKUname { get; set; } = string.Empty;
            public string SPUname { get; set; } = string.Empty;
            public string Brand { get; set; } = string.Empty;
        }

        private sealed class ImeiInfo
        {
            public string Imei { get; set; } = string.Empty;
            public string SKUcode { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }

        private sealed class SaleEvent
        {
            public DateTime SellDate { get; set; }
            public string Imei { get; set; } = string.Empty;
        }

        public List<string> GetBrands()
        {
            const string sql = "SELECT DISTINCT [brand] FROM [tblproduct] WHERE [brand] IS NOT NULL AND [brand]<>'' ORDER BY [brand]";
            var result = new List<string>();

            using var conn = DBHelper.GetConnection() as OleDbConnection;
            if (conn == null)
            {
                return result;
            }

            conn.Open();
            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return result;
            }

            while (reader.Read())
            {
                string brand = reader[0] == DBNull.Value ? string.Empty : Convert.ToString(reader[0]) ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(brand))
                {
                    result.Add(brand.Trim());
                }
            }

            return result.Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList();
        }

        public List<AnalysisRowModel> GetAnalysisRows(DateTime startDate, DateTime endDate, AnalysisViewType viewType, List<string> brands)
        {
            using var conn = DBHelper.GetConnection() as OleDbConnection;
            if (conn == null)
            {
                return new List<AnalysisRowModel>();
            }

            conn.Open();

            string imeiSkuColumn = ResolveExistingColumn(conn, "tblimei", "SKUcode", "statusSKUcode", "StatusSKUcode", "status_sku_code");
            if (string.IsNullOrWhiteSpace(imeiSkuColumn))
            {
                return new List<AnalysisRowModel>();
            }

            Dictionary<string, ProductInfo> productBySku = LoadProducts(conn);
            Dictionary<string, ImeiInfo> imeiMap = LoadImeis(conn, imeiSkuColumn);
            List<SaleEvent> saleEvents = LoadSaleEvents(conn);

            HashSet<string> brandFilter = BuildBrandFilter(brands);
            Func<ProductInfo, string> keySelector = viewType == AnalysisViewType.SKU
                ? p => p.SKUname
                : p => p.SPUname;

            var rows = new Dictionary<string, AnalysisRowModel>(StringComparer.OrdinalIgnoreCase);

            // stock: 现有库存（instock）
            foreach (ImeiInfo item in imeiMap.Values)
            {
                if (!string.Equals(item.Status, "instock", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!productBySku.TryGetValue(item.SKUcode, out ProductInfo? product))
                {
                    continue;
                }

                if (!MatchBrand(product.Brand, brandFilter))
                {
                    continue;
                }

                string name = keySelector(product);
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                AnalysisRowModel row = GetOrCreate(rows, name);
                row.Stock += 1;
            }

            DateTime rangeStart = startDate.Date;
            DateTime rangeEnd = endDate.Date;
            DateTime demandStart = rangeEnd.AddDays(-6);

            // sellout + demand(7天)
            foreach (SaleEvent evt in saleEvents)
            {
                if (!imeiMap.TryGetValue(evt.Imei, out ImeiInfo? imeiInfo))
                {
                    continue;
                }

                if (!productBySku.TryGetValue(imeiInfo.SKUcode, out ProductInfo? product))
                {
                    continue;
                }

                if (!MatchBrand(product.Brand, brandFilter))
                {
                    continue;
                }

                string name = keySelector(product);
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                AnalysisRowModel row = GetOrCreate(rows, name);
                DateTime day = evt.SellDate.Date;

                if (day >= rangeStart && day <= rangeEnd)
                {
                    row.Sellout += 1;
                }

                if (day >= demandStart && day <= rangeEnd)
                {
                    row.DemandStock += 1m; // 临时累计“近7天总销量”，后续再 /7
                }
            }

            // DOS + Demand Stock
            foreach (AnalysisRowModel row in rows.Values)
            {
                decimal avgDaily7 = row.DemandStock / 7m;
                row.DOS = avgDaily7 > 0 ? Math.Round(row.Stock / avgDaily7, 2) : 0m;
                row.DemandStock = Math.Round(avgDaily7 * 20m - row.Stock, 2);
            }

            return rows.Values.ToList();
        }

        public List<SalesTrendPointModel> GetTrendData(TrendRange range, List<string> brands)
        {
            DateTime today = DateTime.Today;
            DateTime start;
            DateTime end;
            switch (range)
            {
                case TrendRange.Week:
                    start = today.AddDays(-6);
                    end = today;
                    break;
                case TrendRange.Month:
                    start = new DateTime(today.Year, today.Month, 1);
                    end = start.AddMonths(1).AddDays(-1);
                    break;
                default:
                    start = new DateTime(today.Year, 1, 1);
                    end = new DateTime(today.Year, 12, 31);
                    break;
            }

            using var conn = DBHelper.GetConnection() as OleDbConnection;
            if (conn == null)
            {
                return new List<SalesTrendPointModel>();
            }

            conn.Open();

            string imeiSkuColumn = ResolveExistingColumn(conn, "tblimei", "SKUcode", "statusSKUcode", "StatusSKUcode", "status_sku_code");
            if (string.IsNullOrWhiteSpace(imeiSkuColumn))
            {
                return new List<SalesTrendPointModel>();
            }

            Dictionary<string, ProductInfo> productBySku = LoadProducts(conn);
            Dictionary<string, ImeiInfo> imeiMap = LoadImeis(conn, imeiSkuColumn);
            List<SaleEvent> saleEvents = LoadSaleEvents(conn);
            HashSet<string> brandFilter = BuildBrandFilter(brands);

            var dayMap = new Dictionary<DateTime, int>();
            foreach (SaleEvent evt in saleEvents)
            {
                DateTime day = evt.SellDate.Date;
                if (day < start.Date || day > end.Date)
                {
                    continue;
                }

                if (!imeiMap.TryGetValue(evt.Imei, out ImeiInfo? imeiInfo))
                {
                    continue;
                }

                if (!productBySku.TryGetValue(imeiInfo.SKUcode, out ProductInfo? product))
                {
                    continue;
                }

                if (!MatchBrand(product.Brand, brandFilter))
                {
                    continue;
                }

                dayMap[day] = dayMap.TryGetValue(day, out int qty) ? qty + 1 : 1;
            }

            var points = new List<SalesTrendPointModel>();
            if (range == TrendRange.Year)
            {
                for (int month = 1; month <= 12; month++)
                {
                    DateTime m1 = new DateTime(today.Year, month, 1);
                    DateTime m2 = m1.AddMonths(1).AddDays(-1);
                    int total = dayMap.Where(k => k.Key >= m1 && k.Key <= m2).Sum(k => k.Value);
                    points.Add(new SalesTrendPointModel
                    {
                        Date = m1,
                        Label = m1.ToString("MM"),
                        Quantity = total
                    });
                }
            }
            else
            {
                DateTime cursor = start.Date;
                while (cursor <= end.Date)
                {
                    points.Add(new SalesTrendPointModel
                    {
                        Date = cursor,
                        Label = range == TrendRange.Week ? cursor.ToString("MM-dd") : cursor.ToString("dd"),
                        Quantity = dayMap.TryGetValue(cursor, out int qty) ? qty : 0
                    });

                    cursor = cursor.AddDays(1);
                }
            }

            return points;
        }

        private static Dictionary<string, ProductInfo> LoadProducts(OleDbConnection conn)
        {
            const string sql = @"SELECT [SKUcode], [SKUname], [SPUname], [brand] FROM [tblproduct]";
            var map = new Dictionary<string, ProductInfo>(StringComparer.OrdinalIgnoreCase);

            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return map;
            }

            while (reader.Read())
            {
                string sku = GetString(reader, 0);
                if (string.IsNullOrWhiteSpace(sku))
                {
                    continue;
                }

                map[sku] = new ProductInfo
                {
                    SKUcode = sku,
                    SKUname = GetString(reader, 1),
                    SPUname = GetString(reader, 2),
                    Brand = GetString(reader, 3)
                };
            }

            return map;
        }

        private static Dictionary<string, ImeiInfo> LoadImeis(OleDbConnection conn, string imeiSkuColumn)
        {
            string sql = $"SELECT [imei], [{imeiSkuColumn}], [status] FROM [tblimei]";
            var map = new Dictionary<string, ImeiInfo>(StringComparer.OrdinalIgnoreCase);

            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return map;
            }

            while (reader.Read())
            {
                string imei = GetString(reader, 0);
                string sku = GetString(reader, 1);
                if (string.IsNullOrWhiteSpace(imei) || string.IsNullOrWhiteSpace(sku))
                {
                    continue;
                }

                map[imei] = new ImeiInfo
                {
                    Imei = imei,
                    SKUcode = sku,
                    Status = GetString(reader, 2)
                };
            }

            return map;
        }

        private static List<SaleEvent> LoadSaleEvents(OleDbConnection conn)
        {
            const string sql = @"SELECT S.[sell_date], D.[imei]
                                 FROM [tblsales] S INNER JOIN [tblsdetail] D ON S.[invoice_id]=D.[invoice_id]
                                 WHERE S.[sell_date] IS NOT NULL AND D.[imei] IS NOT NULL";
            var list = new List<SaleEvent>();

            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return list;
            }

            while (reader.Read())
            {
                DateTime date;
                try
                {
                    date = Convert.ToDateTime(reader[0]).Date;
                }
                catch
                {
                    continue;
                }

                string imei = GetString(reader, 1);
                if (string.IsNullOrWhiteSpace(imei))
                {
                    continue;
                }

                list.Add(new SaleEvent
                {
                    SellDate = date,
                    Imei = imei
                });
            }

            return list;
        }

        private static AnalysisRowModel GetOrCreate(Dictionary<string, AnalysisRowModel> rows, string key)
        {
            if (!rows.TryGetValue(key, out AnalysisRowModel? row))
            {
                row = new AnalysisRowModel { Name = key };
                rows[key] = row;
            }

            return row;
        }

        private static HashSet<string> BuildBrandFilter(List<string> brands)
        {
            if (brands == null || brands.Count == 0)
            {
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            return new HashSet<string>(brands.Where(b => !string.IsNullOrWhiteSpace(b)).Select(b => b.Trim()), StringComparer.OrdinalIgnoreCase);
        }

        private static bool MatchBrand(string brand, HashSet<string> brandFilter)
        {
            if (brandFilter.Count == 0)
            {
                return true;
            }

            return brandFilter.Contains((brand ?? string.Empty).Trim());
        }

        private static string GetString(IDataRecord reader, int ordinal)
        {
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return string.Empty;
            }

            return Convert.ToString(reader.GetValue(ordinal))?.Trim() ?? string.Empty;
        }

        private static string ResolveExistingColumn(OleDbConnection conn, string tableName, params string[] candidates)
        {
            DataTable? columns = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName, null });
            if (columns == null)
            {
                return string.Empty;
            }

            var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow row in columns.Rows)
            {
                string name = Convert.ToString(row["COLUMN_NAME"]) ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    existing.Add(name);
                }
            }

            foreach (string candidate in candidates)
            {
                if (existing.Contains(candidate))
                {
                    return candidate;
                }
            }

            return string.Empty;
        }
    }
}
