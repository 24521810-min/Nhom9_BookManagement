using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class DangKy : Form
    {
        private readonly string apiUrl = "https://localhost:7214/api/Users/register";

        public DangKy()
        {
            InitializeComponent();
            btnSignup.Click += BtnSignup_Click;
        }

        private async void BtnSignup_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirmpassword.Text.Trim();

            // KIỂM TRA RỖNG
            if (string.IsNullOrWhiteSpace(fullname) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Vui lòng điền đầy đủ TẤT CẢ thông tin!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIỂM TRA SỐ ĐIỆN THOẠI – phải đúng 10 số
            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!",
                    "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIỂM TRA EMAIL
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!",
                    "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIỂM TRA KHỚP MẬT KHẨU
            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TẠO MODEL
            var model = new
            {
                FullName = fullname,
                UserName = username,
                Email = email,
                Phone = phone,
                Password = password
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đăng ký thành công!");
                        new DangNhap().Show();
                        this.Hide();
                    }
                    else
                    {
                        string msg = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Đăng ký thất bại:\n" + msg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể kết nối server:\n" + ex.Message);
                }
            }
        }

        private void lbAccount_Click(object sender, EventArgs e)
        {
            DangNhap login = new DangNhap();
            login.Show();
            this.Hide();
        }
    }
}
