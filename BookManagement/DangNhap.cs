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
                MessageBox.Show("Please enter username/email and password!");
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
                        MessageBox.Show("Invalid username/email or password!");
                        return;
                    }

                    // Lấy JSON trả về từ server
                    string resultJson = await response.Content.ReadAsStringAsync();

                    // Parse JSON thành object
                    dynamic result = JsonConvert.DeserializeObject(resultJson);

                    bool isLocked = result.isLocked;

                    if (isLocked)
                    {
                        MessageBox.Show("Your account is locked. Please contact admin!");
                        return;
                    }

                    // Lưu IDUser để dùng cho các chức năng khác (như Quyên góp)
                    Program.LoggedUserID = (int)result.idUser;

                    string name = (string)result.fullName;

                    MessageBox.Show($"Welcome back, {name}!");

                    // Mở form Users
                    Users f = new Users();
                    f.Show();
                    this.Hide();
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
