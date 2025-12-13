using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Trasach : Form
    {
        private readonly string baseAddress = ApiConfig.BaseUrl;
        private readonly int currentUserId;

        // ===== CONSTRUCTOR DUY NHẤT =====
        public Trasach(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.Load += Trasach_Load;
        }

        // =============== LOAD DANH SÁCH SÁCH ĐANG MƯỢN ===============
        private async void Trasach_Load(object sender, EventArgs e)
        {
            await LoadSachDangMuonAsync();

            bangds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bangds.MultiSelect = false;
            bangds.CellClick += bangds_CellClick;
        }

        private async Task LoadSachDangMuonAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    var response = await client.GetAsync("api/MuonSach");

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Không thể tải danh sách mượn sách từ server!");
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    var all = JsonConvert.DeserializeObject<List<MuonSachItem>>(json) ?? new List<MuonSachItem>();

                    bangds.Rows.Clear();
                    int stt = 1;

                    foreach (var m in all)
                    {
                        if (m.IDUser != currentUserId) continue;
                        if (string.Equals(m.TrangThai, "Đã Trả", StringComparison.OrdinalIgnoreCase)) continue;
                        if (string.Equals(m.TrangThai, "Từ Chối", StringComparison.OrdinalIgnoreCase)) continue;

                        int index = bangds.Rows.Add();
                        bangds.Rows[index].Cells[0].Value = stt++;
                        bangds.Rows[index].Cells[1].Value = m.Sach?.TenSach ?? "";
                        bangds.Rows[index].Cells[2].Value = m.IDSach;
                        bangds.Rows[index].Cells[3].Value = m.NgayMuon.ToString("dd/MM/yyyy");
                        bangds.Rows[index].Cells[4].Value = m.NgayTraDuKien.ToString("dd/MM/yyyy");
                        bangds.Rows[index].Cells[5].Value = 1;

                        bangds.Rows[index].Tag = m;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách mượn sách:\n" + ex.Message);
            }
        }

        // =============== CHỌN 1 DÒNG ===============
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

        // =============== GỬI YÊU CẦU TRẢ SÁCH ===============
        private async void button_guiyc_Click(object sender, EventArgs e)
        {
            if (bangds.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách muốn trả.");
                return;
            }

            var m = bangds.SelectedRows[0].Tag as MuonSachItem;
            if (m == null) return;

            var traModel = new
            {
                IDMuon = m.IDMuon,
                NgayTra = dateTimePicker_trathucte.Value,
                TinhTrang = "Chưa Trả",
                GhiChu = ""
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    var response = await client.PostAsJsonAsync("api/TraSach", traModel);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Gửi yêu cầu trả sách thành công!\nVui lòng chờ admin duyệt.");
                        await LoadSachDangMuonAsync();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Gửi yêu cầu thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi yêu cầu trả:\n" + ex.Message);
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
            new Users(currentUserId).Show();
            this.Hide();
        }

        private void button_Muon_Click(object sender, EventArgs e)
        {
            new Muonsach(currentUserId).Show();
            this.Hide();
        }

        private void button_quyengop_Click(object sender, EventArgs e)
        {
            new QuyenGopSach(currentUserId).Show();
            this.Hide();
        }

        private void button_DXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Program.LoggedUserID = -1;
                Program.Token = null;
                new DangNhap().Show();
                this.Close();
            }
        }

        private void button_HSDKy_Click(object sender, EventArgs e)
        {
            new HoSoDKi(currentUserId).Show();
            this.Hide();
        }

        // =============== DTO ===============
        private class MuonSachItem
        {
            public int IDMuon { get; set; }
            public int IDUser { get; set; }
            public int IDSach { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime NgayTraDuKien { get; set; }
            public string TrangThai { get; set; }
            public SachDto Sach { get; set; }
        }

        private class SachDto
        {
            public int IDSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }
    }
}