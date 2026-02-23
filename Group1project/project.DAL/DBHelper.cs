using System.Data;
using System.Data.OleDb;
using Dapper;

namespace Group1project.project.DAL
{
    public static class DBHelper
    {
        // Path to Access database (provided)
        private static readonly string _dbPath = @"D:\group1project\Group1beta\Group1project\Group1project\bin\Databasegroup1.accdb";
        private static readonly string _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};Persist Security Info=False;";

        public static IDbConnection GetConnection()
        {
            return new OleDbConnection(_connectionString);
        }

        // 1. Query (用于查询数据，返回列表)
        public static List<T> Query<T>(string sql, object param = null)
        {
            using (var conn = new OleDbConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<T>(sql, param).ToList();
            }
        }

        // 2. add/update/delete (用于保存数据)
        public static int Execute(string sql, object param = null)
        {
            using (var conn = new OleDbConnection(_connectionString))
            {
                conn.Open();
                return conn.Execute(sql, param);
            }
        }

        // 3. Transcation 支持 (批量执行多条 SQL)
        public static bool ExecuteTransaction(List<(string sql, object param)> commands)
        {
            using (var conn = new OleDbConnection(_connectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var cmd in commands)
                        {
                            conn.Execute(cmd.sql, cmd.param, trans);
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
            }
        }
    }
}
