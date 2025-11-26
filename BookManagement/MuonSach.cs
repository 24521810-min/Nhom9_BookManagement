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
        // ID user đang đăng nhập
        private int currentUserId;

        private readonly string baseAddress = "https://localhost:7214";

        public Muonsach()
        {
            InitializeComponent();

            currentUserId = Program.LoggedUserID;   

            this.Load += MuonSach_Load;
            textBox_timkiem.TextChanged += textBox_timkiem_TextChanged;
            button_muonsach.Click += button_muonsach_Click;
        }

        public Muonsach(int userId) : this()
        {
            currentUserId = userId;
        }

        // ================== LOAD DANH SÁCH SÁCH TỪ API ==================
        private async void MuonSach_Load(object sender, EventArgs e)
        {
            await LoadDanhSachSachAsync();
        }

        private async Task LoadDanhSachSachAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    // API GetAll của SachController: GET /api/Sach
                    var response = await client.GetAsync("/api/Sach");

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Không thể tải danh sách sách từ server!");
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<SachDto>>(json);

                    bangds.Rows.Clear();
                    int stt = 1;

                    foreach (var s in list)
                    {
                        int index = bangds.Rows.Add();
                        bangds.Rows[index].Cells[0].Value = stt++;                     // STT
                        bangds.Rows[index].Cells[1].Value = s.TenSach;                 // Tên sách
                        bangds.Rows[index].Cells[2].Value = s.IDSach;                  // Mã sách
                        bangds.Rows[index].Cells[3].Value = s.TacGia?.HoTen ?? "";     // Tác giả
                        bangds.Rows[index].Cells[4].Value = 1;                         // SL mượn mặc định
                        bangds.Rows[index].Cells[5].Value = s.SoLuong;                 // SL còn
                        bangds.Rows[index].Cells[6].Value = false;                     // Chưa chọn
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sách từ server:\n" + ex.Message);
            }
        }

        // ================== TÌM KIẾM THEO TÊN SÁCH (lọc trên grid) ==================
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

        // ================== GỬI YÊU CẦU MƯỢN SÁCH TỚI API ==================
        private async void button_muonsach_Click(object sender, EventArgs e)
        {
            if (currentUserId <= 0)
            {
                MessageBox.Show("Không xác định được người dùng đang đăng nhập!");
                return;
            }

            DateTime ngayMuon = dateTimePicker_muon.Value;
            DateTime ngayTra = dateTimePicker_tradk.Value;

            // Gom các sách được tick
            List<MuonSachDto> danhSachGuiLen = new List<MuonSachDto>();

            foreach (DataGridViewRow row in bangds.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = false;
                if (row.Cells[6].Value != null)
                    isChecked = Convert.ToBoolean(row.Cells[6].Value);

                if (!isChecked) continue;

                int idSach = Convert.ToInt32(row.Cells[2].Value);
                int soLuongMuon = Convert.ToInt32(row.Cells[4].Value);
                int soLuongCon = Convert.ToInt32(row.Cells[5].Value);

                if (soLuongMuon <= 0)
                {
                    MessageBox.Show("Số lượng mượn phải > 0.");
                    continue;
                }

                if (soLuongMuon > soLuongCon)
                {
                    MessageBox.Show($"Sách ID {idSach} không đủ số lượng để mượn.");
                    continue;
                }

                // 1 dòng = 1 record MuonSach gửi lên server
                var item = new MuonSachDto
                {
                    IDUser = currentUserId,
                    IDSach = idSach,
                    NgayMuon = ngayMuon,
                    NgayTraDuKien = ngayTra,
                    TrangThai = "ChoDuyet"
                   
                };

                danhSachGuiLen.Add(item);
            }

            if (danhSachGuiLen.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách nào để mượn.");
                return;
            }

            bool allSuccess = true;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    // MuonSachController hiện tại nhận 1 object MuonSach / lần POST
                    foreach (var req in danhSachGuiLen)
                    {
                        string json = JsonConvert.SerializeObject(req);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        // POST: /api/MuonSach
                        var response = await client.PostAsync("/api/MuonSach", content);

                        if (!response.IsSuccessStatusCode)
                        {
                            allSuccess = false;
                            string err = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Gửi yêu cầu mượn thất bại cho IDSach = "
                                            + req.IDSach + ":\n"
                                            + response.StatusCode + "\n" + err);
                        }
                    }
                }

                if (allSuccess)
                {
                    MessageBox.Show("Đã gửi yêu cầu mượn sách.\nVui lòng chờ admin duyệt!");
                   
                    await LoadDanhSachSachAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi yêu cầu mượn sách:\n" + ex.Message);
            }
        }

        // ================== ĐIỀU HƯỚNG ==================
        private void button_TrangChu_Click(object sender, EventArgs e)
        {
            Users f = new Users();
            f.Show();
            this.Hide();
        }

        private void button_DangXuat_Click(object sender, EventArgs e)
        {
            Program.LoggedUserID = -1;
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        // ================== DTO PHÙ HỢP VỚI API SERVER ==================

        // Dùng để nhận dữ liệu từ /api/Sach
        private class SachDto
        {
            public int IDSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }

            // Navigation object TacGia (server trả về: { "tacGia": { "hoTen": "..." } })
            public TacGiaDto TacGia { get; set; }
        }

        private class TacGiaDto
        {
            public string HoTen { get; set; }
        }

        // Dùng để gửi dữ liệu lên /api/MuonSach (khớp với entity MuonSach)
        private class MuonSachDto
        {
            public int IDUser { get; set; }
            public int IDSach { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime NgayTraDuKien { get; set; }
            public string TrangThai { get; set; }
            
        }

        private void button_TrangChu_Click_1(object sender, EventArgs e)
        {
            
            Users f = new Users();
            f.Show();
            this.Hide();
        }

        private void button_DXuat_Click(object sender, EventArgs e)
        {
            Program.LoggedUserID = -1;

            // Mở form đăng nhập
            DangNhap dn = new DangNhap();
            dn.Show();

            // Ẩn form hiện tại
            this.Hide();
        }

        private void button_Tra_Click(object sender, EventArgs e)
        {
            Trasach f = new Trasach();
            f.Show();
            this.Hide();
        }

        private void button_quyengop_Click(object sender, EventArgs e)
        {
            QuyenGopSach f = new QuyenGopSach();
            f.Show();
            this.Hide();
        }
    }
}
