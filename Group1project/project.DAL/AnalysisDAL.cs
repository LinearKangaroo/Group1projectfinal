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
            public decimal PurchasePrice { get; set; }
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
            public decimal UnitPrice { get; set; }
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

        public List<int> GetAvailableYears()
        {
            const string sql = "SELECT DISTINCT Year([sell_date]) AS Y FROM [tblsales] WHERE [sell_date] IS NOT NULL ORDER BY Year([sell_date])";
            var years = new List<int>();

            using var conn = DBHelper.GetConnection() as OleDbConnection;
            if (conn == null)
            {
                return years;
            }

            conn.Open();
            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return years;
            }

            while (reader.Read())
            {
                if (reader[0] != DBNull.Value)
                {
                    years.Add(Convert.ToInt32(reader[0]));
                }
            }

            if (years.Count == 0)
            {
                years.Add(DateTime.Today.Year);
            }

            return years.Distinct().OrderBy(x => x).ToList();
        }

        public List<AnalysisRowModel> GetAnalysisRows(DateTime startDate, DateTime endDate, AnalysisViewType viewType, List<string> brands)
        {
            using var conn = DBHelper.GetConnection() as OleDbConnection;
            if (conn == null)
            {
                return new List<AnalysisRowModel>();
            }

            conn.Open();

            Dictionary<string, ProductInfo> productBySku = LoadProducts(conn);
            Dictionary<string, ImeiInfo> imeiMap = LoadImeis(conn);
            List<SaleEvent> saleEvents = LoadSaleEvents(conn);

            HashSet<string> brandFilter = BuildBrandFilter(brands);
            Func<ProductInfo, string> keySelector = viewType == AnalysisViewType.SKU
                ? p => p.SKUname
                : p => p.SPUname;

            var rows = new Dictionary<string, AnalysisRowModel>(StringComparer.OrdinalIgnoreCase);

            foreach (ImeiInfo item in imeiMap.Values)
            {
                if (!string.Equals(item.Status, "instock", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!productBySku.TryGetValue(item.SKUcode, out ProductInfo? product) || !MatchBrand(product.Brand, brandFilter))
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

            foreach (SaleEvent evt in saleEvents)
            {
                if (!imeiMap.TryGetValue(evt.Imei, out ImeiInfo? imeiInfo))
                {
                    continue;
                }

                if (!productBySku.TryGetValue(imeiInfo.SKUcode, out ProductInfo? product) || !MatchBrand(product.Brand, brandFilter))
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
                    row.Profit += evt.UnitPrice - product.PurchasePrice;
                }

                if (day >= demandStart && day <= rangeEnd)
                {
                    row.DemandStock += 1m;
                }
            }

            foreach (AnalysisRowModel row in rows.Values)
            {
                decimal avgDaily7 = row.DemandStock / 7m;
                row.DOS = avgDaily7 > 0 ? Math.Round(row.Stock / avgDaily7, 2) : 0m;
                row.DemandStock = Math.Round(avgDaily7 * 20m - row.Stock, 2);
                row.Profit = Math.Round(row.Profit, 2);
            }

            return rows.Values.ToList();
        }

        public List<SalesTrendPointModel> GetTrendData(TrendRange range, List<string> brands, int? year = null, int? month = null)
        {
            DateTime today = DateTime.Today;
            int selectedYear = year ?? today.Year;
            int selectedMonth = month ?? today.Month;

            DateTime start;
            DateTime end;
            switch (range)
            {
                case TrendRange.Week:
                    start = today.AddDays(-6);
                    end = today;
                    break;
                case TrendRange.Month:
                    start = new DateTime(selectedYear, selectedMonth, 1);
                    end = start.AddMonths(1).AddDays(-1);
                    break;
                default:
                    start = new DateTime(selectedYear, 1, 1);
                    end = new DateTime(selectedYear, 12, 31);
                    break;
            }

            using var conn = DBHelper.GetConnection() as OleDbConnection;
            if (conn == null)
            {
                return new List<SalesTrendPointModel>();
            }

            conn.Open();

            Dictionary<string, ProductInfo> productBySku = LoadProducts(conn);
            Dictionary<string, ImeiInfo> imeiMap = LoadImeis(conn);
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

                if (!productBySku.TryGetValue(imeiInfo.SKUcode, out ProductInfo? product) || !MatchBrand(product.Brand, brandFilter))
                {
                    continue;
                }

                dayMap[day] = dayMap.TryGetValue(day, out int qty) ? qty + 1 : 1;
            }

            var points = new List<SalesTrendPointModel>();
            if (range == TrendRange.Year)
            {
                for (int m = 1; m <= 12; m++)
                {
                    DateTime m1 = new DateTime(selectedYear, m, 1);
                    DateTime m2 = m1.AddMonths(1).AddDays(-1);
                    int total = dayMap.Where(k => k.Key >= m1 && k.Key <= m2).Sum(k => k.Value);
                    points.Add(new SalesTrendPointModel { Date = m1, Label = m1.ToString("MM"), Quantity = total });
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
            const string sql = @"SELECT [SKUcode], [SKUname], [SPUname], [brand], [purchase_price] FROM [tblproduct]";
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
                    Brand = GetString(reader, 3),
                    PurchasePrice = GetDecimal(reader, 4)
                };
            }

            return map;
        }

        private static Dictionary<string, ImeiInfo> LoadImeis(OleDbConnection conn)
        {
            const string sql = "SELECT * FROM [tblimei]";
            var map = new Dictionary<string, ImeiInfo>(StringComparer.OrdinalIgnoreCase);

            using var cmd = new OleDbCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return map;
            }

            while (reader.Read())
            {
                string imei = GetStringSafe(reader, "imei");
                string sku = FirstNonEmpty(
                    GetStringSafe(reader, "SKUcode"),
                    GetStringSafe(reader, "statusSKUcode"),
                    GetStringSafe(reader, "StatusSKUcode"),
                    GetStringSafe(reader, "status_sku_code"));

                if (string.IsNullOrWhiteSpace(imei) || string.IsNullOrWhiteSpace(sku))
                {
                    continue;
                }

                map[imei] = new ImeiInfo
                {
                    Imei = imei,
                    SKUcode = sku,
                    Status = GetStringSafe(reader, "status")
                };
            }

            return map;
        }

        private static List<SaleEvent> LoadSaleEvents(OleDbConnection conn)
        {
            const string sql = @"SELECT S.[sell_date], D.[imei], D.[unit_price]
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

                list.Add(new SaleEvent { SellDate = date, Imei = imei, UnitPrice = GetDecimal(reader, 2) });
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
            return brandFilter.Count == 0 || brandFilter.Contains((brand ?? string.Empty).Trim());
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

        private static string GetStringSafe(IDataRecord reader, string columnName)
        {
            int ordinal = GetOrdinalSafe(reader, columnName);
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return string.Empty;
            }

            return Convert.ToString(reader.GetValue(ordinal))?.Trim() ?? string.Empty;
        }

        private static string GetString(IDataRecord reader, int ordinal)
        {
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return string.Empty;
            }

            return Convert.ToString(reader.GetValue(ordinal))?.Trim() ?? string.Empty;
        }

        private static decimal GetDecimal(IDataRecord reader, int ordinal)
        {
            if (ordinal < 0 || reader.IsDBNull(ordinal))
            {
                return 0m;
            }

            return Convert.ToDecimal(reader.GetValue(ordinal));
        }

    }
}
