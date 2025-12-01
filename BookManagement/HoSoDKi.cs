using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class HoSoDKi : Form
    {
        private readonly HttpClient _client;
        private readonly int _userId;

        public HoSoDKi()
        {
            InitializeComponent();
            if (DesignMode) return;
            _userId = AuthSession.UserId;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(AuthSession.BaseApiUrl);
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AuthSession.Token);

            textBox_username.ReadOnly = true; // username không được sửa
            textBox1.ReadOnly = true;         // trạng thái tài khoản không sửa
        }

        private async void HoSoDKi_Load(object sender, EventArgs e)
        {
            await LoadUserInfo();
            await LoadStats();
        }


        // MODEL JSON (Client-side)

        private class UserInfo
        {
            public int IDUser { get; set; }
            public string FullName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public bool IsLocked { get; set; }
            public string Role { get; set; }
            public DateTime? BirthDate { get; set; }
            public string Gender { get; set; }
        }

        private class UpdateProfileRequest
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public DateTime? BirthDate { get; set; }
            public string Gender { get; set; }
        }


        // LOAD THÔNG TIN HỒ SƠ NGƯỜI DÙNG

        private async Task LoadUserInfo()
        {
            HttpResponseMessage resp = await _client.GetAsync($"api/Users/{_userId}");

            if (!resp.IsSuccessStatusCode)
            {
                MessageBox.Show("Không thể tải dữ liệu người dùng.");
                return;
            }

            string json = await resp.Content.ReadAsStringAsync();

            var user = JsonSerializer.Deserialize<UserInfo>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (user == null)
            {
                MessageBox.Show("Dữ liệu người dùng rỗng.");
                return;
            }

            // Gán dữ liệu lên form
            textBox_hoten.Text = user.FullName;
            textBox_email.Text = user.Email;
            textBox_sdt.Text = user.Phone;

            textBox_username.Text = user.UserName;
            textBox1.Text = user.IsLocked ? "Đã khóa" : "Đang hoạt động";

            // Ngày sinh
            if (user.BirthDate.HasValue)
                dateTimePicker_ngSinh.Value = user.BirthDate.Value;

            // Giới tính
            if (!string.IsNullOrEmpty(user.Gender))
                comboBox_gioitinh.SelectedItem = user.Gender;
        }


        // 3. LOAD THỐNG KÊ SÁCH (Mượn - Trả - Góp)

        private async Task LoadStats()
        {
            label_tsMuon.Text = await CountAsync($"api/MuonSach/user/{_userId}/count");
            label_tsTra.Text = await CountAsync($"api/TraSach/user/{_userId}/count");
            label_tsQuyenGop.Text = await CountAsync($"api/QuyenGop/user/{_userId}/count");
        }

        private async Task<string> CountAsync(string url)
        {
            HttpResponseMessage resp = await _client.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return "0";

            string result = await resp.Content.ReadAsStringAsync();
            return result;
        }


        // NÚT CẬP NHẬT

        private async void button_update_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var req = new UpdateProfileRequest
            {
                FullName = textBox_hoten.Text.Trim(),
                Email = textBox_email.Text.Trim(),
                Phone = textBox_sdt.Text.Trim(),
                BirthDate = dateTimePicker_ngSinh.Value.Date,
                Gender = comboBox_gioitinh.SelectedItem?.ToString()
            };

            string json = JsonSerializer.Serialize(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage resp =
                await _client.PutAsync($"api/Users/{_userId}/profile", content);

            if (!resp.IsSuccessStatusCode)
            {
                string err = await resp.Content.ReadAsStringAsync();
                MessageBox.Show("Cập nhật thất bại: " + err);
                return;
            }

            MessageBox.Show("Cập nhật hồ sơ thành công!");
        }


        // VALIDATE INPUT

        private bool ValidateInputs()
        {
            if (textBox_hoten.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên không được bỏ trống.");
                return false;
            }

            if (!textBox_email.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.");
                return false;
            }

            if (textBox_sdt.Text.Trim().Length < 8)
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return false;
            }

            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Users us = new Users();
            us.Show();
            this.Hide();
        }
    }
}
