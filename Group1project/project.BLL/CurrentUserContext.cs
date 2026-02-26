namespace Group1project.project.BLL
{
    public static class CurrentUserContext
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; } = string.Empty;
        public static string Role { get; private set; } = string.Empty;

        public static bool IsLoggedIn => UserId > 0 && !string.IsNullOrWhiteSpace(Username);

        public static void Set(int userId, string username, string role)
        {
            UserId = userId;
            Username = username ?? string.Empty;
            Role = role ?? string.Empty;
        }

        public static void Clear()
        {
            UserId = 0;
            Username = string.Empty;
            Role = string.Empty;
        }
    }
}
