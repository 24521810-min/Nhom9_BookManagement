using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

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

            // Kiểm tra rỗng
            if (fullname == "" || username == "" || email == "" ||
                password == "" || confirm == "")
            {
                MessageBox.Show("Please fill in all required fields!");
                return;
            }

            // Kiểm tra khớp mật khẩu
            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // Tạo model gửi lên server
            var model = new
            {
                FullName = fullname,
                UserName = username,
                Email = email,
                Phone = phone,
                Password = password  // hash sẽ làm ở server
            };

            string json = JsonConvert.SerializeObject(model);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sign up successfully!");

                        // Mở form login
                        DangNhap login = new DangNhap();
                        login.Show();
                        this.Hide();
                    }
                    else
                    {
                        string msg = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Sign up failed:\n" + msg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to server:\n" + ex.Message);
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
