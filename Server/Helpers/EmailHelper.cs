using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public static class EmailHelper
{
    private const string SenderEmail = "dhtran2006@gmail.com";
    private const string AppPassword = "pwvf nhgq raei ryet";

    // Hàm dùng chung cho TẤT CẢ email (duyệt mượn, duyệt trả, quyên góp, ...)
    public static async Task<bool> SendMailAsync(string to, string subject, string body, bool isHtml = true)
    {
        try
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SenderEmail, AppPassword)
            };

            var mail = new MailMessage(SenderEmail, to, subject, body)
            {
                IsBodyHtml = isHtml
            };

            await client.SendMailAsync(mail);
            return true; // Gửi thành công
        }
        catch (SmtpException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi SMTP khi gửi email: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi chung khi gửi email: {ex.Message}");
            return false;
        }
    }

    // Hàm chuyên dùng cho QUÊN MẬT KHẨU (gọi lại SendMailAsync cho đỡ lặp code)
    public static Task<bool> SendTemporaryPasswordMail(string to, string tempPassword)
    {
        string subject = "Mật khẩu mới cho tài khoản của bạn";
        string body = $@"
                <h2>🔐 Cấp lại mật khẩu</h2>
                <p>Xin chào,</p>
                <p>Bạn đã yêu cầu lấy lại mật khẩu.</p>

                <p><b>Mật khẩu mới của bạn là:</b></p>
                <p style='font-size:18px;color:#d9534f;'><b>{tempPassword}</b></p>

                <p>Vui lòng đăng nhập lại bằng mật khẩu tạm thời này.</p>
                <p>Nếu bạn không yêu cầu, hãy bỏ qua email này.</p>

                <hr>
                <p style='color:gray; font-size:14px;'>Trân trọng,<br>Hệ thống BookManagement</p>
                ";      

        return SendMailAsync(to, subject, body, isHtml: true);
    }
}
