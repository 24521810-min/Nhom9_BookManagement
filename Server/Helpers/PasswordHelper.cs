using System.Text;
using System.Security.Cryptography;

namespace BookApi.Helpers
{
    public static class PasswordHelper
    {
        // Hàm hash mật khẩu (dạng hex string)
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        // Hàm kiểm tra mật khẩu khi đăng nhập
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            // Hash lại mật khẩu người dùng nhập
            string hashOfInput = HashPassword(inputPassword);

            // So sánh hash
            return hashOfInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
