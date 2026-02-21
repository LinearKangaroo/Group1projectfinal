using Dapper;

namespace Group1project.project.DAL
{
    public class UserRepository
    {
        public UserRecord? GetActiveUser(string username, string password)
        {
            using var conn = DBHelper.GetConnection();
            conn.Open();

            // OleDb (Access) uses positional parameters; Dapper recommends ?name? syntax.
            const string sql = @"
SELECT TOP 1
    [userID] AS UserId,
    [username] AS Username,
    [role] AS Role,
    [status] AS UserStatus
FROM [tbluser]
WHERE [username] = ?Username?
  AND [password] = ?Password?
  AND [status] = True";

            return conn.QueryFirstOrDefault<UserRecord>(sql, new
            {
                Username = username,
                Password = password
            });
        }
    }

    public class UserRecord
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool UserStatus { get; set; }
    }
}
