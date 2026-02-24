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
