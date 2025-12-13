using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BookManagement
{
    public partial class Muonsach : Form
    {
        private readonly int _currentUserId;
        private readonly string _baseAddress = ApiConfig.BaseUrl;

        // ===== CONSTRUCTOR DUY NHẤT =====
        public Muonsach(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;

            this.Load += MuonSach_Load;
        }

        // ===== FORM LOAD =====
        private async void MuonSach_Load(object sender, EventArgs e)
        {
            textBox_timkiem.TextChanged += textBox_timkiem_TextChanged;
            button_muonsach.Click += button_muonsach_Click;

            await LoadDanhSachSachAsync();
        }

        // ===== LOAD DANH SÁCH SÁCH =====
        private async Task LoadDanhSachSachAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);

                    var response = await client.GetAsync("api/Sach");

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Không thể tải danh sách sách!");
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<SachDto>>(json) ?? new List<SachDto>();

                    bangds.Rows.Clear();
                    int stt = 1;

                    foreach (var s in list)
                    {
                        int index = bangds.Rows.Add();
                        bangds.Rows[index].Cells[0].Value = stt++;
                        bangds.Rows[index].Cells[1].Value = s.TenSach;
                        bangds.Rows[index].Cells[2].Value = s.IDSach;
                        bangds.Rows[index].Cells[3].Value = s.TacGia?.HoTen ?? "";
                        bangds.Rows[index].Cells[4].Value = 1;
                        bangds.Rows[index].Cells[5].Value = s.SoLuong;
                        bangds.Rows[index].Cells[6].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sách:\n" + ex.Message);
            }
        }

        // ===== TÌM KIẾM =====
        private void textBox_timkiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox_timkiem.Text.Trim().ToLower();

            foreach (DataGridViewRow row in bangds.Rows)
            {
                if (row.IsNewRow) continue;

                string tenSach = row.Cells[1].Value?.ToString().ToLower() ?? "";
                row.Visible = tenSach.Contains(keyword);
            }
        }

        // ===== GỬI YÊU CẦU MƯỢN =====
        private async void button_muonsach_Click(object sender, EventArgs e)
        {
            if (_currentUserId <= 0)
            {
                MessageBox.Show("Không xác định được người dùng!");
                return;
            }

            DateTime ngayMuon = dateTimePicker_muon.Value;
            DateTime ngayTra = dateTimePicker_tradk.Value;

            var danhSachGui = new List<MuonSachDto>();

            foreach (DataGridViewRow row in bangds.Rows)
            {
                if (row.IsNewRow) continue;

                bool checkedRow = Convert.ToBoolean(row.Cells[6].Value ?? false);
                if (!checkedRow) continue;

                int idSach = Convert.ToInt32(row.Cells[2].Value);
                int soLuongMuon = Convert.ToInt32(row.Cells[4].Value);
                int soLuongCon = Convert.ToInt32(row.Cells[5].Value);

                if (soLuongMuon <= 0 || soLuongMuon > soLuongCon)
                {
                    MessageBox.Show($"Số lượng mượn không hợp lệ (ID sách {idSach})");
                    return;
                }

                danhSachGui.Add(new MuonSachDto
                {
                    IDUser = _currentUserId,
                    IDSach = idSach,
                    NgayMuon = ngayMuon,
                    NgayTraDuKien = ngayTra,
                    TrangThai = "Chờ Duyệt"
                });
            }

            if (danhSachGui.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách để mượn.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);

                    foreach (var req in danhSachGui)
                    {
                        var content = new StringContent(
                            JsonConvert.SerializeObject(req),
                            Encoding.UTF8,
                            "application/json");

                        var response = await client.PostAsync("api/MuonSach", content);

                        if (!response.IsSuccessStatusCode)
                        {
                            string err = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Lỗi gửi yêu cầu:\n" + err);
                            return;
                        }
                    }
                }

                MessageBox.Show("Đã gửi yêu cầu mượn sách!\nVui lòng chờ admin duyệt.");
                await LoadDanhSachSachAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi yêu cầu:\n" + ex.Message);
            }
        }

        // ===== ĐIỀU HƯỚNG =====
        private void button_TrangChu_Click(object sender, EventArgs e)
        {
            new Users(_currentUserId).Show();
            this.Hide();
        }

        private void button_Tra_Click(object sender, EventArgs e)
        {
            new Trasach(_currentUserId).Show();
            this.Hide();
        }

        private void button_quyengop_Click(object sender, EventArgs e)
        {
            new QuyenGopSach(_currentUserId).Show();
            this.Hide();
        }

        private void button_HSDKy_Click(object sender, EventArgs e)
        {
            new HoSoDKi(_currentUserId).Show();
            this.Hide();
        }
        // ===== DTO =====
        private class SachDto
        {
            public int IDSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
            public TacGiaDto TacGia { get; set; }
        }

        private class TacGiaDto
        {
            public string HoTen { get; set; }
        }

        private class MuonSachDto
        {
            public int IDUser { get; set; }
            public int IDSach { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime NgayTraDuKien { get; set; }
            public string TrangThai { get; set; }
        }

        private void button_DXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Program.LoggedUserID = -1;
                Program.Token = null;

                new DangNhap().Show();
                this.Close();
            }
        }
    }
}