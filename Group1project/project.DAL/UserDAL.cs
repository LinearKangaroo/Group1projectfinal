using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Group1project.Model;


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
                                 (?username?,?password?,?status?,?role?,?email?,?phone?,?position?,?create_time?,?edit_time?)";

            return DBHelper.Execute(sql, new
            {
                user.username,
                user.password,
                user.status,
                user.role,
                user.email,
                user.phone,
                user.position,
                user.create_time,
                user.edit_time
            });
        }

        public int UpdateUser(User user)
        {
            const string sql = @"UPDATE [tbluser]
                                 SET [username]=?username?,
                                     [password]=?password?,
                                     [status]=?status?,
                                     [role]=?role?,
                                     [email]=?email?,
                                     [phone]=?phone?,
                                     [position]=?position?,
                                     [edit_time]=?edit_time?
                                 WHERE [userId]=?userId?";

            return DBHelper.Execute(sql, new
            {
                user.username,
                user.password,
                user.status,
                user.role,
                user.email,
                user.phone,
                user.position,
                user.edit_time,
                user.userId
            });
        }
    }
}
