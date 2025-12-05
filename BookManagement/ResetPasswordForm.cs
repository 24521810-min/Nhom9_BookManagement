using BookManagement.Services;
using System;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class ResetPasswordForm : Form
    {
        private readonly string _email;

        public ResetPasswordForm(string email)
        {
            InitializeComponent();
            _email = email;

            txtEmail.Text = email;
            txtEmail.ReadOnly = true;

            // Ẩn ký tự mật khẩu
            txtTempPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        // Nút "Đổi mật khẩu"
        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            string tempPass = txtTempPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(tempPass) ||
                string.IsNullOrWhiteSpace(newPass) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không trùng khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var body = new
                {
                    Email = _email,
                    TemporaryPassword = tempPass,
                    NewPassword = newPass
                };

                var response = await ApiService.Client
                    .PostAsJsonAsync("api/Users/reset_password", body);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đổi mật khẩu thành công! Hãy đăng nhập lại bằng mật khẩu mới.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var login = new DangNhap();
                    login.Show();
                    this.Close();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Đổi mật khẩu thất bại: " + error,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối server: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var dk = new DangNhap();
            dk.Show();
            this.Hide();
        }
    }
}
