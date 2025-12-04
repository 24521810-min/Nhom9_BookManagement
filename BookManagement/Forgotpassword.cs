using BookManagement.Services;
using System;
using System.Net.Http.Json;
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
                MessageBox.Show("Vui lòng nhập email đã đăng ký!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var body = new { Email = email };

                var response = await ApiService.Client.PostAsJsonAsync("api/Users/forget_password", body);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Mật khẩu mới đã được gửi tới email. Vui lòng kiểm tra!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form đổi mật khẩu mới
                    var resetForm = new ResetPasswordForm(email);
                    resetForm.Show();
                    this.Close();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Gửi yêu cầu thất bại: " + error,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối server: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
