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
            List<imeiModel> data = GetAllImeiWithProduct()
                .Select(x => new imeiModel { imei = x.imei, status = x.status, SKUcode = x.SKUcode })
                .ToList();
            MiniExcel.SaveAs(filePath, data);
        }

        public int ImportImei(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return 0;
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
                return 0;
            }

            using var conn = new OleDbConnection(GetConnectionString());
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                int count = 0;
                const string sql = @"INSERT INTO [tblimei] ([imei],[status],[SKUcode]) VALUES (?,?,?)";
                foreach (imeiModel row in rows)
                {
                    using var cmd = new OleDbCommand(sql, conn, trans);
                    cmd.Parameters.AddWithValue("@imei", DbNullIfWhiteSpace(row.imei));
                    cmd.Parameters.AddWithValue("@status", DbNullIfWhiteSpace(row.status));
                    cmd.Parameters.AddWithValue("@SKUcode", DbNullIfWhiteSpace(row.SKUcode));
                    count += cmd.ExecuteNonQuery();
                }

                trans.Commit();
                return count;
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
