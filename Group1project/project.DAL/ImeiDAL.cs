using Group1project.Model;
using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace Group1project.project.DAL
{
    public class ImeiDAL
    {
        public List<imeiModel> GetAllImeiWithProduct()
        {
            const string sql = @"SELECT I.[imei], I.[status], I.[SKUcode],
                                        P.[SPUcode], P.[SPUname], P.[brand], P.[SKUspec], P.[SKUname]
                                 FROM [tblimei] AS I
                                 LEFT JOIN [tblproduct] AS P ON I.[SKUcode] = P.[SKUcode]
                                 ORDER BY I.[imei]";
            return DBHelper.Query<imeiModel>(sql);
        }

        public List<ProductModel> GetSkuOptions()
        {
            const string sql = @"SELECT [SKUcode], [SKUname] FROM [tblproduct] ORDER BY [SKUcode]";
            return DBHelper.Query<ProductModel>(sql);
        }

        private static HashSet<string> GetExistingImeiSet(OleDbConnection conn, OleDbTransaction trans)
        {
            var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            using var cmd = new OleDbCommand("SELECT [imei] FROM [tblimei]", conn, trans);
            using var reader = cmd.ExecuteReader();
            if (reader == null)
            {
                return existing;
            }

            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    string imei = Convert.ToString(reader.GetValue(0))?.Trim() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(imei))
                    {
                        existing.Add(imei);
                    }
                }
            }

            return existing;
        }

        public int AddImei(imeiModel model)
        {
            const string sql = @"INSERT INTO [tblimei] ([imei],[status],[SKUcode]) VALUES (?,?,?)";
            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);

            cmd.Parameters.AddWithValue("@imei", DbNullIfWhiteSpace(model.imei));
            cmd.Parameters.AddWithValue("@status", DbNullIfWhiteSpace(model.status));
            cmd.Parameters.AddWithValue("@SKUcode", DbNullIfWhiteSpace(model.SKUcode));

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdateImei(imeiModel model, string originalImei)
        {
            const string sql = @"UPDATE [tblimei] SET [imei]=?, [status]=?, [SKUcode]=? WHERE [imei]=?";
            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);

            cmd.Parameters.AddWithValue("@imei", DbNullIfWhiteSpace(model.imei));
            cmd.Parameters.AddWithValue("@status", DbNullIfWhiteSpace(model.status));
            cmd.Parameters.AddWithValue("@SKUcode", DbNullIfWhiteSpace(model.SKUcode));
            cmd.Parameters.AddWithValue("@originalImei", DbNullIfWhiteSpace(originalImei));

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public void ExportImei(string filePath)
        {
            List<imeiModel> data = GetAllImeiWithProduct();
                //.Select(x => new imeiModel { imei = x.imei, status = x.status, SKUcode = x.SKUcode })
                //.ToList();
            MiniExcel.SaveAs(filePath, data);
        }

        public (int insertedCount, int duplicateCount) ImportImei(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return (0, 0);
            }

            List<imeiModel> rows = MiniExcel.Query<imeiModel>(filePath)
                .Where(x => !string.IsNullOrWhiteSpace(x.imei))
                .Select(x => new imeiModel
                {
                    imei = x.imei?.Trim() ?? string.Empty,
                    status = NormalizeStatus(x.status),
                    SKUcode = x.SKUcode?.Trim() ?? string.Empty
                })
                .ToList();

            if (rows.Count == 0)
            {
                return (0, 0);
            }

            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                int count = 0;
                int duplicateCount = 0;
                HashSet<string> existingImei = GetExistingImeiSet(conn, trans);
                var importSeen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                const string sql = @"INSERT INTO [tblimei] ([imei],[status],[SKUcode]) VALUES (?,?,?)";
                foreach (imeiModel row in rows)
                {
                    string imeiCode = row.imei?.Trim() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(imeiCode))
                    {
                        continue;
                    }

                    if (existingImei.Contains(imeiCode) || importSeen.Contains(imeiCode))
                    {
                        duplicateCount++;
                        continue;
                    }

                    using var cmd = new OleDbCommand(sql, conn, trans);
                    cmd.Parameters.AddWithValue("@imei", DbNullIfWhiteSpace(imeiCode));
                    cmd.Parameters.AddWithValue("@status", DbNullIfWhiteSpace(row.status));
                    cmd.Parameters.AddWithValue("@SKUcode", DbNullIfWhiteSpace(row.SKUcode));
                    count += cmd.ExecuteNonQuery();

                    existingImei.Add(imeiCode);
                    importSeen.Add(imeiCode);
                }

                trans.Commit();
                return (count, duplicateCount);
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        private static string NormalizeStatus(string? status)
        {
            return string.Equals(status?.Trim(), "sold", StringComparison.OrdinalIgnoreCase) ? "sold" : "instock";
        }

        private static object DbNullIfWhiteSpace(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? DBNull.Value : value.Trim();
        }

        private static string GetConnectionString()
        {
            using var conn = DBHelper.GetConnection();
            return conn.ConnectionString;
        }
    }
}
