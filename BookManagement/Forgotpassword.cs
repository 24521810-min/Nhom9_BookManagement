using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Forgotpassword : Form
    {
        private Form parentForm;

        public Forgotpassword()
        {
            InitializeComponent();
        }

        public Forgotpassword(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        // Nút Reset password
        private async void btnResetPassword_Click_1(object sender, EventArgs e)
        {
            string email = txtusername.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Vui lòng nhập email đã đăng ký!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                var body = new { Email = email };

                // 🔥 Lấy API Base URL từ api.config / app.config
                var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

                if (string.IsNullOrWhiteSpace(baseUrl))
                {
                    MessageBox.Show(
                        "Không đọc được ApiBaseUrl trong file cấu hình!",
                        "Lỗi cấu hình",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // 🔥 Ép có dấu /
                if (!baseUrl.EndsWith("/"))
                    baseUrl += "/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.Timeout = TimeSpan.FromSeconds(10);

                    var response = await client.PostAsJsonAsync(
                        "api/Users/forget_password",
                        body
                    );

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            "Mật khẩu mới đã được gửi tới email. Vui lòng kiểm tra!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Mở form đổi mật khẩu
                        var resetForm = new ResetPasswordForm(email);
                        resetForm.Show();
                        this.Close();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(
                            "Gửi yêu cầu thất bại: " + error,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show(
                    "Không thể kết nối server (hết thời gian chờ).",
                    "Lỗi mạng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),   // hiện lỗi chi tiết
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Quay về form Login
        private void lbReturnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm?.Show();
        }
    }
}