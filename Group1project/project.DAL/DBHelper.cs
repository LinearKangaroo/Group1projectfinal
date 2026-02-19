using System.Data;
using System.Data.OleDb;

namespace Group1project.project.DAL
{
    public static class DBHelper
    {
        // Path to Access database (provided)
        private static readonly string _dbPath = @"D:\group1project\Group1beta\Group1project\Group1project\bin\Databasegroup1.accdb";

        public static IDbConnection GetConnection()
        {
            var cs = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};Persist Security Info=False;";
            return new OleDbConnection(cs);
        }
    }
}
