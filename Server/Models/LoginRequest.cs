namespace BookApi.Models
{
    public class LoginRequest
    {
        public string UserInput { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
