using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Load form
            Load += QuanLyMuonTra_Load;

            // Sự kiện MƯỢN
            button6.Click += BtnMuonMoi_Click;
            button7.Click += BtnChoMuon_Click;

            // Sự kiện TRẢ
            btnTraSach.Click += BtnTraSach_Click;

            //sự kiện từ chối
            btTuChoi.Click += BtTuChoi_Click;


            // Event chọn sách
            cmbMaSach.SelectedIndexChanged += CmbMaSach_SelectedIndexChanged;

            // Event trả sách (CHỈ GẮN 1 LẦN)
            cmbDocGia.SelectedIndexChanged += CmbDocGia_SelectedIndexChanged;
        }

        // ====================== LOAD FORM ===============================
        private async void QuanLyMuonTra_Load(object sender, EventArgs e)
        {
            // ❌ XÓA LoadUsers() — combo bị trùng gây lỗi nhân bản
            await LoadSach();
            await LoadDanhSachMuon();
            await LoadDanhSachTra();
            await LoadMuonToTra();
        }

        // ====================== LOAD SÁCH ================================
        private async Task LoadSach()
        {
            var sach = await _client.GetFromJsonAsync<List<Sach>>("api/Sach");

            cmbMaSach.DataSource = sach;
            cmbMaSach.DisplayMember = "TenSach";
            cmbMaSach.ValueMember = "IDSach";

            if (cmbMaSach.Items.Count > 0)
                cmbMaSach.SelectedIndex = 0;
        }

        private void CmbMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaSach.SelectedItem is Sach s)
            {
                // ====== THÔNG TIN SÁCH (GroupBox 1) ======

                // Tên Sách
                txtMaSach.Text = s.TenSach;

                // Loại Sách
                txtMaLoai.Text = s.IDLoaiSach.ToString();

                // Số lượng còn
                txtSoLuong.Text = s.SoLuong.ToString();

                // Tác giả
                txtMaTacGia.Text = s.IDTacGia.ToString();


                // ====== CHO MƯỢN SÁCH (GroupBox 3) ======

                // Mã sách mượn
                txtMaSachMuon.Text = s.IDSach.ToString();

                // luôn mặc định số lượng mượn = 1
                txtSoLuongMuon.Text = "1";
            }
        }


        // ====================== LOAD DS CHO MƯỢN =========================
        private async Task LoadDanhSachMuon()
        {
            var list = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");
            dataGridView1.DataSource = list;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dataGridView1.RowTemplate.Height = 28;

        }

        // ====================== LOAD DS TRẢ ===============================
        private async Task LoadDanhSachTra()
        {
            var list = await _client.GetFromJsonAsync<List<TraSach>>("api/TraSach");
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridView2.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView2.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dataGridView2.RowTemplate.Height = 28;

        }

        // ====================== LOAD COMBO TRẢ SÁCH ======================
        private async Task LoadMuonToTra()
        {
            var muon = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");

            cmbDocGia.DataSource = muon;
            cmbDocGia.DisplayMember = "IDUser";
            cmbDocGia.ValueMember = "IDMuon";

            if (cmbDocGia.Items.Count > 0)
                cmbDocGia.SelectedIndex = 0;
        }

        // ====================== FILL THÔNG TIN KHI CHỌN PHIẾU MƯỢN =======
        private void CmbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = cmbDocGia.SelectedItem as MuonSach;
            if (m == null) return;

            txtMaSachTra.Text = m.IDSach.ToString();
            txtSoLuongMuonTra.Text = "1";
            dateMuonTra.Value = m.NgayMuon;
            dateHenTraTra.Value = m.NgayTraDuKien;
        }

        // ====================== CLEAR FORM MƯỢN ==========================
        private void BtnMuonMoi_Click(object sender, EventArgs e)
        {
            txtMaSachMuon.Clear();
            txtSoLuongMuon.Clear();
            dateMuon.Value = DateTime.Today;
            dateHenTra.Value = DateTime.Today;
        }

        // ====================== ADMIN CHO MƯỢN ===========================
        private async void BtnChoMuon_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dòng đang chọn
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn yêu cầu mượn để duyệt!");
                    return;
                }

                // Lấy IDMuon
                int idMuon = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["IDMuon"].Value
                );

                // Gọi API DUYỆT
                var response = await _client.PutAsync(
                    $"api/MuonSach/duyet/{idMuon}", null);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không duyệt được yêu cầu!");
                    return;
                }

                // Load lại danh sách mượn
                await LoadDanhSachMuon();

                MessageBox.Show("Duyệt thành công! Email đã được gửi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi duyệt: " + ex.Message);
            }
        }


        // ====================== TRẢ SÁCH ===========================
        private async void BtnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một yêu cầu TRẢ SÁCH ở bảng bên dưới!");
                    return;
                }

                // Lấy IDTra từ hàng đang chọn trong dataGridView2 (bảng TraSach)
                int idTra = Convert.ToInt32(
                    dataGridView2.CurrentRow.Cells["IDTra"].Value
                );

                // Gọi API duyệt trả
                var res = await _client.PutAsync($"api/TraSach/duyet/{idTra}", null);

                if (!res.IsSuccessStatusCode)
                {
                    string err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show("Không duyệt được yêu cầu trả sách!\n" + err);
                    return;
                }

                MessageBox.Show("Đã DUYỆT TRẢ SÁCH thành công! Email đã được gửi cho người dùng.");

                // Load lại dữ liệu
                await LoadDanhSachMuon();
                await LoadDanhSachTra();
                await LoadSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi duyệt trả: " + ex.Message);
            }
        }


        // ====================== THOÁT ===========================
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            var ad = new Admin();
            ad.Show();
            this.Hide();
        }
        // =======từ chối====
        private async void BtTuChoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn yêu cầu mượn để từ chối!");
                    return;
                }

                int idMuon = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["IDMuon"].Value
                );

                var response = await _client.PutAsync(
                    $"api/MuonSach/tuchoi/{idMuon}", null
                );

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không thể từ chối yêu cầu này!");
                    return;
                }

                MessageBox.Show("Đã TỪ CHỐI yêu cầu và gửi email thông báo!");

                await LoadDanhSachMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Từ Chối: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                this.Close();
        }
    }
}
