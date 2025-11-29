using System.Net;
using System.Net.Mail;

public static class EmailHelper
{
    private const string SenderEmail = "dhtran2006@gmail.com";
    private const string AppPassword = "pwvf nhgq raei ryet";

    public static async Task<bool> SendMailAsync(string to, string subject, string body)
    {
        try
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SenderEmail, AppPassword)
            };

            var mail = new MailMessage(SenderEmail, to, subject, body);
            // Có thể thêm HTML body nếu cần
            mail.IsBodyHtml = true;

            await client.SendMailAsync(mail);
            return true; // Gửi thành công
        }
        catch (SmtpException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi SMTP khi gửi email: {ex.Message}");
            return false; // Gửi thất bại
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Lỗi chung khi gửi email: {ex.Message}");
            return false;
        }
    }
}