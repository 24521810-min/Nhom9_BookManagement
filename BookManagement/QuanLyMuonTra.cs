using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            button6.Click += BtnMuonMoi_Click;
            button7.Click += BtnChoMuon_Click;

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

        // ============================================================
        private async Task LoadUsers()
        {
            var users = await _client.GetFromJsonAsync<List<Users>>("api/Users");

            cmbMaDocGia.DataSource = new List<Users>(users);
            cmbMaDocGia.DisplayMember = "HoTen";
            cmbMaDocGia.ValueMember = "IDUser";

            cmbDocGia.DataSource = new List<Users>(users);
            cmbDocGia.DisplayMember = "HoTen";
            cmbDocGia.ValueMember = "IDUser";
        }

        // ============================================================
        private async Task LoadSach()
        {
            var sach = await _client.GetFromJsonAsync<List<Sach>>("api/Sach");

            cmbMaSach.DataSource = sach;
            cmbMaSach.DisplayMember = "TenSach";
            cmbMaSach.ValueMember = "IDSach";

            cmbMaSach.SelectedIndexChanged += (s, e) =>
            {
                if (cmbMaSach.SelectedItem is Sach selected)
                {
                    txtMaSach.Text = selected.TenSach;
                    txtMaLoai.Text = selected.IDLoaiSach.ToString();
                    txtSoLuong.Text = selected.SoLuong.ToString();
                    txtMaTacGia.Text = selected.IDTacGia.ToString();
                }
            };
        }

        // ============================================================
        private async Task LoadDanhSachMuon()
        {
            var list = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");
            dataGridView1.DataSource = list;
        }

        // ============================================================
        private async Task LoadDanhSachTra()
        {
            var list = await _client.GetFromJsonAsync<List<TraSach>>("api/TraSach");
            dataGridView2.DataSource = list;
        }

        // ============================================================
        private async Task LoadMuonToTra()
        {
            var muon = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");

            cmbDocGia.DataSource = muon;
            cmbDocGia.DisplayMember = "IDUser";
            cmbDocGia.ValueMember = "IDMuon";

            cmbDocGia.SelectedIndexChanged += (s, e) =>
            {
                if (cmbDocGia.SelectedItem is MuonSach m)
                {
                    txtMaSachTra.Text = m.IDSach.ToString();
                    txtSoLuongMuonTra.Text = "1";
                    dateMuonTra.Value = m.NgayMuon;
                    dateHenTraTra.Value = m.NgayTraDuKien;
                }
            };
        }

        // ============================================================
        private void BtnMuonMoi_Click(object sender, EventArgs e)
        {
            txtMaSachMuon.Clear();
            txtSoLuongMuon.Clear();
            dateMuon.Value = DateTime.Today;
            dateHenTra.Value = DateTime.Today;
        }

        // ============================================================
        private async void BtnChoMuon_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaSachMuon.Text))
                {
                    MessageBox.Show("Nhập mã sách!");
                    return;
                }

                var model = new MuonSach
                {
                    IDUser = (int)cmbMaDocGia.SelectedValue,
                    IDSach = int.Parse(txtMaSachMuon.Text),
                    NgayMuon = dateMuon.Value,
                    NgayTraDuKien = dateHenTra.Value,
                    TrangThai = "Đang mượn"
                };

                var res = await _client.PostAsJsonAsync("api/MuonSach", model);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cho mượn thành công!");
                    await LoadDanhSachMuon();
                }
                else
                {
                    MessageBox.Show("Lỗi API: " + res.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // ============================================================
        private async void BtnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = (MuonSach)cmbDocGia.SelectedItem;

                var model = new TraSach
                {
                    IDMuon = selected.IDMuon,
                    IDUser = selected.IDUser,
                    NgayTra = dateTra.Value,
                    TinhTrang = "Trả bình thường",
                    GhiChu = ""
                };

                var res = await _client.PostAsJsonAsync("api/TraSach", model);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Trả sách thành công!");
                    await LoadDanhSachTra();
                }
                else
                {
                    MessageBox.Show("API lỗi: " + res.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trả sách: " + ex.Message);
            }
        }
    }
}
