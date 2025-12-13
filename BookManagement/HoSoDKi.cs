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

        // ===== CONSTRUCTOR DUY NHẤT =====
        public HoSoDKi(int userId)
        {
            InitializeComponent();
            if (DesignMode) return;

            _userId = userId;

            _client = new HttpClient
            {
                BaseAddress = new Uri(ApiConfig.BaseUrl),
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Gắn token đăng nhập
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", UserSession.Token);

            textBox_username.ReadOnly = true;
            textBox1.ReadOnly = true;

            this.Load += HoSoDKi_Load;
        }

        // ================= LOAD FORM =================
        private async void HoSoDKi_Load(object sender, EventArgs e)
        {
            await LoadUserInfo();
            await LoadStats();
        }

        // ================= MODEL =================
        private class UserInfo
        {
            public int IDUser { get; set; }
            public string FullName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public bool IsLocked { get; set; }
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

        // ================= LOAD USER INFO =================
        private async Task LoadUserInfo()
        {
            var resp = await _client.GetAsync($"api/Users/{_userId}");
            if (!resp.IsSuccessStatusCode)
            {
                MessageBox.Show("Không tải được hồ sơ người dùng.");
                return;
            }

            var json = await resp.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserInfo>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (user == null) return;

            textBox_hoten.Text = user.FullName;
            textBox_email.Text = user.Email;
            textBox_sdt.Text = user.Phone;
            textBox_username.Text = user.UserName;
            textBox1.Text = user.IsLocked ? "Đã khóa" : "Đang hoạt động";

            if (user.BirthDate.HasValue)
                dateTimePicker_ngSinh.Value = user.BirthDate.Value;

            if (!string.IsNullOrEmpty(user.Gender))
                comboBox_gioitinh.SelectedItem = user.Gender;
        }

        // ================= LOAD THỐNG KÊ =================
        private async Task LoadStats()
        {
            label_tsMuon.Text = await CountAsync($"api/MuonSach/user/{_userId}/count");
            label_tsTra.Text = await CountAsync($"api/TraSach/user/{_userId}/count");
            label_tsQuyenGop.Text = await CountAsync($"api/QuyenGop/user/{_userId}/count");
        }

        private async Task<string> CountAsync(string url)
        {
            var resp = await _client.GetAsync(url);
            return resp.IsSuccessStatusCode
                ? await resp.Content.ReadAsStringAsync()
                : "0";
        }

        // ================= UPDATE PROFILE =================
        private async void button_update_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin.");
                return;
            }

            var req = new UpdateProfileRequest
            {
                FullName = textBox_hoten.Text.Trim(),
                Email = textBox_email.Text.Trim(),
                Phone = textBox_sdt.Text.Trim(),
                BirthDate = dateTimePicker_ngSinh.Value.Date,
                Gender = comboBox_gioitinh.SelectedItem?.ToString()
            };

            var content = new StringContent(
                JsonSerializer.Serialize(req),
                Encoding.UTF8,
                "application/json");

            var resp = await _client.PutAsync(
                $"api/Users/{_userId}/profile",
                content);

            if (!resp.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật hồ sơ thất bại!");
                return;
            }

            MessageBox.Show("Cập nhật hồ sơ thành công!");
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox_hoten.Text)) return false;
            if (!textBox_email.Text.Contains("@")) return false;
            if (textBox_sdt.Text.Trim().Length < 8) return false;
            return true;
        }

        // ================= QUAY LẠI TRANG CHỦ =================
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Users(_userId).Show();
            this.Hide();
        }
    }
}