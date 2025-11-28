using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class DangNhap : Form
    {
        private readonly string apiLoginUrl = "https://localhost:7214/api/Users/login";

        public DangNhap()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string userInput = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (userInput == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập/email và mật khẩu!");
                return;
            }

            // Tạo object gửi API
            var loginRequest = new
            {
                UserInput = userInput,
                Password = password
            };

            string json = JsonConvert.SerializeObject(loginRequest);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(apiLoginUrl, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Tên đăng nhập/email hoặc mật khẩu không đúng!");
                        return;
                    }

                    // Lấy JSON trả về từ server
                    string resultJson = await response.Content.ReadAsStringAsync();

                    // Parse JSON thành object
                    dynamic result = JsonConvert.DeserializeObject(resultJson);

                    bool isLocked = result.isLocked;

                    if (isLocked)
                    {
                        MessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ Admin!");
                        return;
                    }

                    // Lưu ID người dùng
                    Program.LoggedUserID = (int)result.idUser;
                    string name = (string)result.fullName;
                    string role = (string)result.role;

                    MessageBox.Show($"Chào mừng bạn trở lại, {name}!");

                    if (role == "Admin")
                    {
                        MessageBox.Show("Bạn đang đăng nhập bằng quyền ADMIN");
                        Admin adminForm = new Admin();
                        adminForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Bạn đang đăng nhập bằng quyền USER");
                        Users userForm = new Users();
                        userForm.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot connect to server:\n" + ex.Message);
                }
            }
        }

        private void lbUnaccount_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
            this.Hide();
        }
    }
}
