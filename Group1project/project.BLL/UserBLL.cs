using Group1project.project.DAL;
using Group1project.Model;
using System.Collections.Generic;
using System.Linq;

namespace Group1project.project.BLL
{
    public class UserBLL
    {
        private readonly UserDAL _userDal = new UserDAL();

        public List<UserModel> GetAllUsers()
        {
            return _userDal.GetAllUsers();
        }

        public List<UserModel> SearchUsersByUsername(List<UserModel> users, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return users;
            }

            string normalizedKeyword = keyword.Trim();
            return users
                .Where(u => !string.IsNullOrWhiteSpace(u.username)
                    && u.username.Contains(normalizedKeyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public int AddUser(UserModel user)
        {
            user.create_time = DateTime.Now;
            user.edit_time = DateTime.Now;
            return _userDal.AddUser(user);
        }

        public int UpdateUser(UserModel user, DateTime createTime)
        {
            user.create_time = createTime;
            user.edit_time = DateTime.Now;
            return _userDal.UpdateUser(user);
        }
    }
}