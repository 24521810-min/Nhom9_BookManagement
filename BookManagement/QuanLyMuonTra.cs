using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

// alias để không bị trùng với Form Users
using UserEntity = User;

namespace BookManagement
{
    public partial class QuanLyMuonTra : Form
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7214/")
        };

        public QuanLyMuonTra()
        {
            InitializeComponent();

            Load += QuanLyMuonTra_Load;

            // Mượn sách
            button6.Click += BtnMuonMoi_Click;   // Mượn mới
            button7.Click += BtnChoMuon_Click;   // Cho mượn

            // Trả sách
            btnTraSach.Click += BtnTraSach_Click;
        }

        // ============================================================
        private async void QuanLyMuonTra_Load(object sender, EventArgs e)
        {
            await LoadUsers();
            await LoadSach();
            await LoadDanhSachMuon();
            await LoadDanhSachTra();
            await LoadMuonToTra();
        }

        // ================== ĐỘC GIẢ =================================
        private async Task LoadUsers()
        {
            var users = await _client.GetFromJsonAsync<List<UserEntity>>("api/Users");

            cmbMaDocGia.DataSource = users;

            // ĐỔI "FullName" thành đúng tên property trong model của bạn
            // (ví dụ HoTen / TenUser / ...)
            cmbMaDocGia.DisplayMember = "FullName";
            cmbMaDocGia.ValueMember = "IDUser";
        }

        // ================== SÁCH ====================================
        private async Task LoadSach()
        {
            var sach = await _client.GetFromJsonAsync<List<Sach>>("api/Sach");

            cmbMaSach.DataSource = sach;
            cmbMaSach.DisplayMember = "TenSach";
            cmbMaSach.ValueMember = "IDSach";

            cmbMaSach.SelectedIndexChanged += (s, e) =>
            {
                var selected = cmbMaSach.SelectedItem as Sach;
                if (selected == null) return;

                txtMaSach.Text = selected.IDSach.ToString();
                txtMaLoai.Text = selected.IDLoaiSach.ToString();
                txtSoLuong.Text = selected.SoLuong.ToString();
                txtMaTacGia.Text = selected.IDTacGia.ToString();
            };
        }

        // ================== DS MƯỢN / TRẢ (ADMIN) ===================
        private async Task LoadDanhSachMuon()
        {
            var list = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");
            dataGridView1.DataSource = list;
        }

        private async Task LoadDanhSachTra()
        {
            var list = await _client.GetFromJsonAsync<List<TraSach>>("api/TraSach");
            dataGridView2.DataSource = list;
        }

        // ================== COMBO CHỌN PHIẾU MƯỢN ĐỂ TRẢ ============
        private async Task LoadMuonToTra()
        {
            var muon = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");

            cmbDocGia.DataSource = muon;
            cmbDocGia.DisplayMember = "IDUser";  // hiển thị mã độc giả
            cmbDocGia.ValueMember = "IDMuon";  // value là ID phiếu mượn

            cmbDocGia.SelectedIndexChanged -= CmbDocGia_SelectedIndexChanged;
            cmbDocGia.SelectedIndexChanged += CmbDocGia_SelectedIndexChanged;
        }

        private void CmbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = cmbDocGia.SelectedItem as MuonSach;
            if (m == null) return;

            txtMaSachTra.Text = m.IDSach.ToString();
            txtSoLuongMuonTra.Text = "1";
            dateMuonTra.Value = m.NgayMuon;
            dateHenTraTra.Value = m.NgayTraDuKien;
        }

        // ================== NÚT "MƯỢN MỚI" ==========================
        private void BtnMuonMoi_Click(object sender, EventArgs e)
        {
            txtMaSachMuon.Clear();
            txtSoLuongMuon.Clear();
            dateMuon.Value = DateTime.Today;
            dateHenTra.Value = DateTime.Today;
        }

        // ================== NÚT "CHO MƯỢN" – GỬI LÊN SERVER =========
        private async void BtnChoMuon_Click(object sender, EventArgs e)
        {
            try
            {
                // C# 7.3 không có "is not", dùng as + null check
                var docGia = cmbMaDocGia.SelectedItem as UserEntity;
                if (docGia == null)
                {
                    MessageBox.Show("Chọn độc giả!");
                    return;
                }

                var sach = cmbMaSach.SelectedItem as Sach;
                if (sach == null)
                {
                    MessageBox.Show("Chọn sách!");
                    return;
                }

                int soLuongMuon;
                if (!int.TryParse(txtSoLuongMuon.Text, out soLuongMuon) || soLuongMuon <= 0)
                {
                    MessageBox.Show("Số lượng mượn không hợp lệ!");
                    return;
                }

                var model = new MuonSach
                {
                    IDUser = docGia.IDUser,
                    IDSach = sach.IDSach,
                    NgayMuon = dateMuon.Value,
                    NgayTraDuKien = dateHenTra.Value,
                    TrangThai = "DangMuon"   // hoặc "ChoDuyet"
                };

                // GỬI YÊU CẦU MƯỢN LÊN SERVER
                var res = await _client.PostAsJsonAsync("api/MuonSach", model);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cho mượn thành công (đã gửi lên server)!");
                    await LoadDanhSachMuon();
                    await LoadMuonToTra();
                }
                else
                {
                    MessageBox.Show("Lỗi API khi cho mượn: " + res.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // ================== NÚT "TRẢ SÁCH" – GỬI LÊN SERVER =========
        private async void BtnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = cmbDocGia.SelectedItem as MuonSach;
                if (selected == null)
                {
                    MessageBox.Show("Chọn phiếu mượn cần trả!");
                    return;
                }

                var model = new TraSach
                {
                    IDMuon = selected.IDMuon,
                    IDUser = selected.IDUser,
                    NgayTra = dateTra.Value,
                    TinhTrang = "TraBinhThuong",  // hoặc "ChoDuyetTra"
                    GhiChu = ""
                };

                // GỬI YÊU CẦU TRẢ LÊN SERVER
                var res = await _client.PostAsJsonAsync("api/TraSach", model);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Trả sách thành công (đã gửi lên server)!");
                    await LoadDanhSachTra();
                }
                else
                {
                    MessageBox.Show("API lỗi khi trả sách: " + res.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trả sách: " + ex.Message);
            }
        }
    }
}
