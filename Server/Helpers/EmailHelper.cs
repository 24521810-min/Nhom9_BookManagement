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
        string body =
$@"Xin chào,

Bạn đã yêu cầu lấy lại mật khẩu.

Mật khẩu mới của bạn là:

<b>{tempPassword}</b>

Vui lòng đăng nhập lại bằng mật khẩu tạm thời này.
Nếu bạn không yêu cầu, hãy bỏ qua email này.

Trân trọng,
Hệ thống Quản Lý Sách";

        return SendMailAsync(to, subject, body, isHtml: true);
    }
}
