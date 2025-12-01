namespace BookManagement
{
    public static class AuthSession
    {
        public static int UserId { get; set; }
        public static string Token { get; set; } = string.Empty;
        public static string BaseApiUrl { get; set; } = "https://localhost:7214/"; 
    }
}
