using Dapper;
using Group1project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Group1project.project.DAL
{
    using User = UserModel;
    public class UserDAL
    {
        public List<User> GetAllUsers()
        {
            const string sql = @"SELECT [userId],[username],[password],[status],[role],[email],[phone],[position],[create_time],[edit_time]
                                 FROM [tbluser]
                                 ORDER BY [userId]";
            return DBHelper.Query<User>(sql);
        }

        public int AddUser(User user)
        {
            const string sql = @"INSERT INTO [tbluser]
                                 ([username],[password],[status],[role],[email],[phone],[position],[create_time],[edit_time])
                                 VALUES
                                 (?,?,?,?,?,?,?,?,?)";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);

            cmd.Parameters.AddWithValue("@username", DbNullIfWhiteSpace(user.username));
            cmd.Parameters.AddWithValue("@password", DbNullIfWhiteSpace(user.password));
            cmd.Parameters.AddWithValue("@status", user.status ? -1 : 0);
            cmd.Parameters.AddWithValue("@role", DbNullIfWhiteSpace(user.role));
            cmd.Parameters.AddWithValue("@email", DbNullIfWhiteSpace(user.email));
            cmd.Parameters.AddWithValue("@phone", DbNullIfWhiteSpace(user.phone));
            cmd.Parameters.AddWithValue("@position", DbNullIfWhiteSpace(user.position));
            cmd.Parameters.AddWithValue("@create_time", user.create_time.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@edit_time", user.edit_time.ToString("yyyy-MM-dd HH:mm:ss"));

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdateUser(User user)
        {
            const string sql = @"UPDATE [tbluser]
                                 SET [username]=?,
                                     [password]=?,
                                     [status]=?,
                                     [role]=?,
                                     [email]=?,
                                     [phone]=?,
                                     [position]=?,
                                     [edit_time]=?
                                 WHERE [userId]=?";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);

            cmd.Parameters.AddWithValue("@username", DbNullIfWhiteSpace(user.username));
            cmd.Parameters.AddWithValue("@password", DbNullIfWhiteSpace(user.password));
            cmd.Parameters.AddWithValue("@status", user.status ? -1 : 0);
            cmd.Parameters.AddWithValue("@role", DbNullIfWhiteSpace(user.role));
            cmd.Parameters.AddWithValue("@email", DbNullIfWhiteSpace(user.email));
            cmd.Parameters.AddWithValue("@phone", DbNullIfWhiteSpace(user.phone));
            cmd.Parameters.AddWithValue("@position", DbNullIfWhiteSpace(user.position));
            cmd.Parameters.AddWithValue("@edit_time", user.edit_time.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@userId", user.userId);


            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public User? GetUserById(int userId)
        {
            const string sql = @"SELECT [userId],[username],[password],[status],[role],[email],[phone],[position],[create_time],[edit_time]
                                 FROM [tbluser]
                                 WHERE [userId]=?";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader == null || !reader.Read())
            {
                return null;
            }

            return new User
            {
                userId = reader["userId"] is DBNull ? 0 : Convert.ToInt32(reader["userId"]),
                username = reader["username"]?.ToString() ?? string.Empty,
                password = reader["password"]?.ToString() ?? string.Empty,
                status = reader["status"] is not DBNull && Convert.ToBoolean(reader["status"]),
                role = reader["role"]?.ToString() ?? string.Empty,
                email = reader["email"]?.ToString() ?? string.Empty,
                phone = reader["phone"]?.ToString() ?? string.Empty,
                position = reader["position"]?.ToString() ?? string.Empty,
                create_time = reader["create_time"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["create_time"]),
                edit_time = reader["edit_time"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["edit_time"])
            };
        }

        public bool VerifyUserPassword(int userId, string password)
        {
            const string sql = @"SELECT COUNT(1)
                                 FROM [tbluser]
                                 WHERE [userId]=? AND [password]=?";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@password", password?.Trim() ?? string.Empty);

            conn.Open();
            var result = cmd.ExecuteScalar();
            return result is not null && Convert.ToInt32(result) > 0;
        }

        public int UpdateUserProfile(User user)
        {
            const string sql = @"UPDATE [tbluser]
                                 SET [password]=?,
                                     [phone]=?,
                                     [email]=?,
                                     [edit_time]=?
                                 WHERE [userId]=?";

            using var conn = new OleDbConnection(GetConnectionString());
            using var cmd = new OleDbCommand(sql, conn);

            cmd.Parameters.AddWithValue("@password", DbNullIfWhiteSpace(user.password));
            cmd.Parameters.AddWithValue("@phone", DbNullIfWhiteSpace(user.phone));
            cmd.Parameters.AddWithValue("@email", DbNullIfWhiteSpace(user.email));
            cmd.Parameters.AddWithValue("@edit_time", user.edit_time.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@userId", user.userId);

            conn.Open();
            return cmd.ExecuteNonQuery();
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
