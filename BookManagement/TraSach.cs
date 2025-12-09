using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Trasach : Form
    {
        private readonly string baseAddress = "https://localhost:7214";
        private int currentUserId;

        public Trasach()
        {
            InitializeComponent();

            currentUserId = AuthSession.UserId;


            // Sự kiện form
            this.Load += Trasach_Load;

            // Điều hướng
            button_TrangChu.Click += button_TrangChu_Click;
            button_Muon.Click += button_Muon_Click;
            button_quyengop.Click += button_quyengop_Click;

            // Nút xử lý trả sách
            button_guiyc.Click += button_guiyc_Click;  // gửi yêu cầu
            button_huy.Click += button_huy_Click;

            // Chọn dòng trong bảng
            bangds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bangds.MultiSelect = false;
            bangds.CellClick += bangds_CellClick;
        }

        // =============== LOAD DANH SÁCH SÁCH ĐANG MƯỢN ===============
        private async void Trasach_Load(object sender, EventArgs e)
        {
            await LoadSachDangMuonAsync();
        }

        private async Task LoadSachDangMuonAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    var response = await client.GetAsync("/api/MuonSach");

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Không thể tải danh sách mượn sách từ server!");
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    var all = JsonConvert.DeserializeObject<List<MuonSachItem>>(json) ?? new List<MuonSachItem>();

                    // Chỉ lấy của user hiện tại và chưa trả
                    var list = new List<MuonSachItem>();
                    foreach (var x in all)
                    {
                        if (x.IDUser == currentUserId &&
                            !string.Equals(x.TrangThai, "Đã Trả", StringComparison.OrdinalIgnoreCase) &&
                            !string.Equals(x.TrangThai, "Từ Chối", StringComparison.OrdinalIgnoreCase))
                        {
                            list.Add(x);
                        }
                    }


                    bangds.Rows.Clear();
                    int stt = 1;

                    foreach (var m in list)
                    {
                        int index = bangds.Rows.Add();
                        bangds.Rows[index].Cells[0].Value = stt++;
                        bangds.Rows[index].Cells[1].Value = m.Sach?.TenSach ?? "";
                        bangds.Rows[index].Cells[2].Value = m.IDSach;
                        bangds.Rows[index].Cells[3].Value = m.NgayMuon.ToString("dd/MM/yyyy");
                        bangds.Rows[index].Cells[4].Value = m.NgayTraDuKien.ToString("dd/MM/yyyy");
                        bangds.Rows[index].Cells[5].Value = 1; // số lượng tạm = 1

                        // Lưu cả object để dùng khi trả
                        bangds.Rows[index].Tag = m;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sách đã mượn:\n" + ex.Message);
            }
        }

        // Khi click 1 dòng trong DataGridView → fill panel bên phải
        private void bangds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = bangds.Rows[e.RowIndex];
            var m = row.Tag as MuonSachItem;
            if (m == null) return;

            textBox_tensach.Text = m.Sach?.TenSach ?? "";
            textBox_masach.Text = m.IDSach.ToString();
            textBox_soluong.Text = "1";

            dateTimePicker_ngaymuon.Value = m.NgayMuon;
            dateTimePicker_tradukien.Value = m.NgayTraDuKien;
            dateTimePicker_trathucte.Value = DateTime.Now;
        }

        // =============== GỬI YÊU CẦU TRẢ SÁCH (PUT /api/MuonSach/{id}) ===============
        private async void button_guiyc_Click(object sender, EventArgs e)
        {
            if (bangds.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sách muốn trả.");
                return;
            }

            var row = bangds.SelectedRows[0];
            var m = row.Tag as MuonSachItem;

            if (m == null)
            {
                MessageBox.Show("Không lấy được thông tin mượn sách.");
                return;
            }

            // KHÔNG được gán "DaTra" ở đây
            // Vì user CHỈ gửi yêu cầu, admin mới duyệt

            var traModel = new
            {
                IDMuon = m.IDMuon,
                NgayTra = dateTimePicker_trathucte.Value,
                TinhTrang = "Trả Bình Thường",
                GhiChu = ""
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    var response = await client.PostAsJsonAsync("/api/TraSach", traModel);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Gửi yêu cầu trả sách THÀNH CÔNG!\nVui lòng chờ admin duyệt.");
                        ClearForm();
                    }
                    else
                    {
                        string err = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Gửi yêu cầu thất bại:\n" + response.StatusCode + "\n" + err);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi yêu cầu trả sách:\n" + ex.Message);
            }
        }


        private void button_huy_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            textBox_tensach.Clear();
            textBox_masach.Clear();
            textBox_soluong.Clear();
            dateTimePicker_ngaymuon.Value = DateTime.Now;
            dateTimePicker_tradukien.Value = DateTime.Now;
            dateTimePicker_trathucte.Value = DateTime.Now;
        }

        // =============== ĐIỀU HƯỚNG ===============
        private void button_TrangChu_Click(object sender, EventArgs e)
        {
            Users f = new Users();
            f.Show();
            this.Hide();
        }

        private void button_Muon_Click(object sender, EventArgs e)
        {
            Muonsach f = new Muonsach();
            f.Show();
            this.Hide();
        }

        private void button_quyengop_Click(object sender, EventArgs e)
        {
            QuyenGopSach f = new QuyenGopSach();
            f.Show();
            this.Hide();
        }
        private void button_DXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Program.LoggedUserID = -1;

                DangNhap dn = new DangNhap();
                dn.Show();
                this.Hide();
            }
        }
        // =============== DTO PHÙ HỢP VỚI API ===============
        private class MuonSachItem
        {
            public int IDMuon { get; set; }
            public int IDUser { get; set; }
            public int IDSach { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime NgayTraDuKien { get; set; }
            public string TrangThai { get; set; } = string.Empty;
            public SachDto Sach { get; set; }
        }

        private class SachDto
        {
            public int IDSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }

        private class MuonSachUpdateDto
        {
            public int IDMuon { get; set; }
            public int IDUser { get; set; }
            public int IDSach { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime NgayTraDuKien { get; set; }
            public string TrangThai { get; set; } = string.Empty;
        }            
       
        private void button_trasach_Click(object sender, EventArgs e)
        {
            if (bangds.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn sách muốn trả trong danh sách bên trái.");
                return;
            }

            var row = bangds.SelectedRows[0];
            var m = row.Tag as MuonSachItem;
            if (m == null)
            {
                MessageBox.Show("Không lấy được thông tin sách.");
                return;
            }

            // Fill thông tin vào bảng nâu
            textBox_tensach.Text = m.Sach?.TenSach ?? "";
            textBox_masach.Text = m.IDSach.ToString();
            textBox_soluong.Text = "1";
            dateTimePicker_ngaymuon.Value = m.NgayMuon;
            dateTimePicker_tradukien.Value = m.NgayTraDuKien;
            dateTimePicker_trathucte.Value = DateTime.Now;
        }

        private void button_HSDKy_Click(object sender, EventArgs e)
        {
            HoSoDKi hs = new HoSoDKi();
            hs.Show();
            this.Hide();
        }   
    }
}
