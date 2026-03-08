using Group1project.project.DAL;

namespace Group1project.project.BLL
{
    public class LoginService
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public LoginResult ValidateLogin(string username, string password, string selectedRole)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return LoginResult.Fail("The username and password cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(selectedRole))
            {
                return LoginResult.Fail("Please select your role.", true);
            }

            var user = _userRepository.GetActiveUser(username.Trim(), password.Trim());
            if (user is null)
            {
                return LoginResult.Fail("Username or password is incorrect, or the account is not activated.");
            }

            if (!string.Equals(user.Role?.Trim(), selectedRole.Trim(), System.StringComparison.OrdinalIgnoreCase))
            {
                return LoginResult.Fail("Selected role is incorrect.", true);
            }

            return LoginResult.Success(user.UserId, user.Username, user.Role);
        }
    }

    public class LoginResult
    {
        public bool IsSuccess { get; private set; }
        public bool IsRoleMismatch { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public int UserId { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Role { get; private set; } = string.Empty;

        public static LoginResult Success(int userId, string username, string role)
            => new LoginResult { IsSuccess = true, UserId = userId, Username = username, Role = role, Message = "登录成功。" };

        public static LoginResult Fail(string message, bool isRoleMismatch = false)
            => new LoginResult { IsSuccess = false, Message = message, IsRoleMismatch = isRoleMismatch };
    }
}
