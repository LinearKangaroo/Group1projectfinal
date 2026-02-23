using System;

namespace Group1project.Model
{
    public class UserModel
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string position { get; set; }
        public DateTime create_time { get; set; }
        public DateTime edit_time { get; set; }
    }
}