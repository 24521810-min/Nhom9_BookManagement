namespace BookApi.Dtos
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string TemporaryPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
