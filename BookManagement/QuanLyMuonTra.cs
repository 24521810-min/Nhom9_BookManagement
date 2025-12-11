using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private readonly string _token;

        public QuanLyMuonTra(string token)
        {
            InitializeComponent();

            _token = token;
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            Load += QuanLyMuonTra_Load;

            // BUTTON EVENTS
            button7.Click += BtnChoMuon_Click;
            btTuChoi.Click += BtTuChoi_Click;
            btnTraSach.Click += BtnTraSach_Click;
            button8.Click += BtnThoat_Click;
            btnExit.Click += BtnThoat_Click;

            // ComboBox chọn phiếu mượn để trả sách
            cmbDocGia.SelectedIndexChanged += CmbDocGia_SelectedIndexChanged;

            // ⭐⭐ THÊM DÒNG NÀY
            dataGridView1.CellClick += DataGridView1_CellClick;
        }


        // ============================ LOAD FORM ===============================
        private async void QuanLyMuonTra_Load(object sender, EventArgs e)
        {
            await LoadSach();
            await LoadDanhSachMuon();
            await LoadDanhSachTra();
            await LoadMuonToTra();
        }

        // ============================ LOAD SÁCH ===============================
        private async Task LoadSach()
        {
            try
            {
                var sachList = await _client.GetFromJsonAsync<List<Sach>>("api/Sach");
                if (sachList == null || sachList.Count == 0) return;

                // HIỂN THỊ LÊN TEXTBOX (vì KHÔNG có combobox chọn sách)
                var s = sachList[0];

                textBox2.Text = s.TenSach;            // Tên sách
                txtMaSach.Text = s.IDSach.ToString(); // Mã Sách
                txtMaTacGia.Text = s.IDTacGia.ToString();
                txtSoLuong.Text = s.SoLuong.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sách: " + ex.Message);
            }
        }

        // ============================ LOAD DANH SÁCH MƯỢN =====================
        private async Task LoadDanhSachMuon()
        {
            var list = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");

            dataGridView1.DataSource = list;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Font = new Font("Segoe UI", 10);
        }

        // ============================ LOAD DANH SÁCH TRẢ =======================
        private async Task LoadDanhSachTra()
        {
            var list = await _client.GetFromJsonAsync<List<TraSach>>("api/TraSach");

            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Font = new Font("Segoe UI", 10);
        }

        // ============================ COMBO TRẢ SÁCH ==========================
        private async Task LoadMuonToTra()
        {
            var muon = await _client.GetFromJsonAsync<List<MuonSach>>("api/MuonSach");

            cmbDocGia.DataSource = muon;
            cmbDocGia.DisplayMember = "IDUser";    // Show IDUser
            cmbDocGia.ValueMember = "IDMuon";      // Lấy ID mượn
        }

        // ============================ FILL THÔNG TIN TRẢ ======================
        private void CmbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocGia.SelectedItem is MuonSach m)
            {
                txtMaSachTra.Text = m.IDSach.ToString();
                txtSoLuongMuonTra.Text = "1";
                dateMuonTra.Value = m.NgayMuon;
                dateHenTraTra.Value = m.NgayTraDuKien;
            }
        }

        // ============================ DUYỆT CHO MƯỢN ==========================
        private async void BtnChoMuon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn yêu cầu mượn!");
                    return;
                }

                int idMuon = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["IDMuon"].Value);

                var res = await _client.PutAsync($"api/MuonSach/duyet/{idMuon}", null);

                if (!res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không duyệt được yêu cầu!");
                    return;
                }

                MessageBox.Show("Duyệt thành công! Email đã được gửi");

                await LoadDanhSachMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi duyệt mượn: " + ex.Message);
            }
        }

        // ============================ TỪ CHỐI MƯỢN ============================
        private async void BtTuChoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn yêu cầu!");
                    return;
                }

                int idMuon = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["IDMuon"].Value);

                var res = await _client.PutAsync($"api/MuonSach/tuchoi/{idMuon}", null);

                if (!res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không thể từ chối!");
                    return;
                }

                MessageBox.Show("Đã TỪ CHỐI yêu cầu!");

                await LoadDanhSachMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi từ chối: " + ex.Message);
            }
        }

        // ============================ DUYỆT TRẢ SÁCH ==========================
        private async void BtnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn yêu cầu trả sách!");
                    return;
                }

                int idTra = Convert.ToInt32(
                    dataGridView2.CurrentRow.Cells["IDTra"].Value);

                var res = await _client.PutAsync($"api/TraSach/duyet/{idTra}", null);

                if (!res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không duyệt được yêu cầu trả!");
                    return;
                }

                MessageBox.Show("Đã DUYỆT TRẢ SÁCH thành công! Email đã được gửi cho người dùng ");

                await LoadDanhSachMuon();
                await LoadDanhSachTra();
                await LoadSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi duyệt trả: " + ex.Message);
            }
        }

        // ============================ THOÁT FORM ==============================
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            // ====== LẤY ID USER & ID SÁCH TỪ DÒNG ĐANG CHỌN ======
            int idUser = Convert.ToInt32(row.Cells["IDUser"].Value);
            int idSach = Convert.ToInt32(row.Cells["IDSach"].Value);

            // ====== LOAD USERNAME CHO Ô "Mã Độc Giả" ======
            try
            {
                var user = await _client.GetFromJsonAsync<User>($"api/Users/{idUser}");
                if (user != null)
                    textBox1.Text = user.UserName;  // hoặc user.FullName nếu muốn
                else
                    textBox1.Text = "Không tìm thấy";
            }
            catch
            {
                textBox1.Text = "Lỗi tải user";
            }

            // ====== LOAD THÔNG TIN SÁCH ĐÚNG THEO IDSach ======
            try
            {
                var sach = await _client.GetFromJsonAsync<Sach>($"api/Sach/{idSach}");
                if (sach != null)
                {
                    textBox2.Text = sach.TenSach;           // Chọn Sách
                    txtMaSach.Text = sach.IDSach.ToString(); // Mã Sách
                    txtMaTacGia.Text = sach.IDTacGia.ToString();
                    txtSoLuong.Text = sach.SoLuong.ToString();
                }
            }
            catch
            {
                // nếu lỗi thì giữ nguyên, không crash form
            }

            // ====== NGÀY MƯỢN + NGÀY HẸN TRẢ ======
            dateMuon.Value = Convert.ToDateTime(row.Cells["NgayMuon"].Value);
            dateHenTra.Value = Convert.ToDateTime(row.Cells["NgayTraDuKien"].Value);
        }



    }
}
