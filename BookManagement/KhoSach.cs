using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BookManagement
{
    public partial class KhoSach : Form
    {
        private readonly HttpClient client = new HttpClient();
        public KhoSach()
        {
            InitializeComponent();
            this.Load += KhoSach_Load;
        }
        private async void KhoSach_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:7214/api/");

            await LoadSach();
            await LoadLoaiSach();
            await LoadTacGia();
        }
        // ========== Sách ==========
        private async Task LoadSach()
        {
            var response = await client.GetAsync("Sach");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Sach>>(json);

            var list = data.Select(s => new
            {
                IDSach = s.IDSach,
                TenSach = s.TenSach,
                SoLuong = s.SoLuong,
                TacGia = s.TacGia?.HoTen,
                LoaiSach = s.LoaiSach?.TenLoaiSach
            }).ToList();

            dsSach.DataSource = list;
        }
        private async void btnviewSach_Click(object sender, EventArgs e)
        {
            await LoadSach();
        }
        private async Task AddSach()
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(txtTenSach.Text) ||
                string.IsNullOrEmpty(txtTacGia.Text) ||
                string.IsNullOrEmpty(txtLoaiSach.Text) ||
                string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sach = new
            {
                TenSach = txtTenSach.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                TacGia = new { HoTen = txtTacGia.Text },
                LoaiSach = new { TenLoaiSach = txtLoaiSach.Text }
            };

            var json = JsonConvert.SerializeObject(sach);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Sach", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm sách thành công!");
                await LoadSach();
                await LoadTacGia();
                await LoadLoaiSach();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể thêm sách!\n" + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnaddSach_Click(object sender, EventArgs e)
        {
            await AddSach();
        }
        private async Task UpdateSach()
        {
            if (string.IsNullOrEmpty(txtMaSach.Text) ||
                string.IsNullOrEmpty(txtTenSach.Text) ||
                string.IsNullOrEmpty(txtTacGia.Text) ||
                string.IsNullOrEmpty(txtLoaiSach.Text) ||
                string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            int id = int.Parse(txtMaSach.Text);

            var sach = new
            {
                IDSach = id,
                TenSach = txtTenSach.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                TacGia = new { HoTen = txtTacGia.Text },
                LoaiSach = new { TenLoaiSach = txtLoaiSach.Text }
            };

            var json = JsonConvert.SerializeObject(sach);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"Sach/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật sách thành công!");
                await LoadSach();
                await LoadTacGia();
                await LoadLoaiSach();
            }
            else
            {
                string err = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể cập nhật sách!\n" + err);
            }
        }

        private async void btneditSach_Click(object sender, EventArgs e)
        {
            await UpdateSach();
        }
        private async Task DeleteSach()
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!");
                return;
            }

            int id = int.Parse(txtMaSach.Text);

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var response = await client.DeleteAsync($"Sach/{id}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xóa sách thành công!");
                await LoadSach();
            }
            else
            {
                string err = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể xóa sách!\n" + err);
            }
        }
        private async void btnclearSach_Click(object sender, EventArgs e)
        {
            await DeleteSach();
        }
        private async Task SearchSach()
        {
            string keyword = txtTenSach.Text.Trim();
            //Ktra ten sach co rong khong
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên sách để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return;
            }

            var response = await client.GetAsync($"Sach/search?name={keyword}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Lỗi truy vấn API!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Sach>>(json);

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sách phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSach.Focus();
                return;
            }
            var table = data.Select(s => new
            {
                IDSach = s.IDSach,
                TenSach = s.TenSach,
                TacGia = s.TacGia?.HoTen,
                LoaiSach = s.LoaiSach?.TenLoaiSach,
                SoLuong = s.SoLuong
            }).ToList();

            dsSach.DataSource = table;
        }
        private async void btnsearchSach_Click(object sender, EventArgs e)
        {
            await SearchSach();
        }
        private void dsSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaSach.Text = dsSach.Rows[e.RowIndex].Cells["IDSach"].Value.ToString();
                txtTenSach.Text = dsSach.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();
                txtTacGia.Text = dsSach.Rows[e.RowIndex].Cells["TacGia"].Value.ToString();
                txtLoaiSach.Text = dsSach.Rows[e.RowIndex].Cells["LoaiSach"].Value.ToString();
                txtSoLuong.Text = dsSach.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
            }
        }
        private void btnexitSach_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }
        // ========== Loại Sách ==========
        private async Task LoadLoaiSach()
        {
            var response = await client.GetAsync("LoaiSach");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<LoaiSach>>(json);

            dsLoaiSach.DataSource = data;
        }
        private async void btnviewLoaiSach_Click(object sender, EventArgs e)
        {
            await LoadLoaiSach();
        }
        private async Task SearchLoaiSach()
        {
            string keyword = txtTenLoaiSach.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên loại sách để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiSach.Focus();
                return;
            }
            var response = await client.GetAsync($"LoaiSach/search?name={keyword}");
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Lỗi truy vấn API!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<LoaiSach>>(json);
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không tìm thấy loại sách phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoaiSach.Focus();
                return;
            }
            dsLoaiSach.DataSource = data;
        }
        private async void btnsearchLoaiSach_Click(object sender, EventArgs e)
        {
            await SearchLoaiSach();
        }
        private async Task AddLoaiSach()
        {
            if (string.IsNullOrEmpty(txtTenLoaiSach.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var loaiSach = new
            {
                TenLoaiSach = txtTenLoaiSach.Text
            };
            var json = JsonConvert.SerializeObject(loaiSach);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("LoaiSach", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm loại sách thành công!");
                await LoadLoaiSach();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể thêm loại sách!\n" + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnaddLoaiSach_Click(object sender, EventArgs e)
        {
            await AddLoaiSach();
        }
        private async Task EditLoaiSach()
        {
            if (string.IsNullOrEmpty(txtMaLoaiSach.Text) ||
                string.IsNullOrEmpty(txtTenLoaiSach.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            int id = int.Parse(txtMaLoaiSach.Text);
            var loaiSach = new
            {
                IDLoaiSach = id,
                TenLoaiSach = txtTenLoaiSach.Text
            };
            var json = JsonConvert.SerializeObject(loaiSach);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"LoaiSach/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật loại sách thành công!");
                await LoadLoaiSach();
            }
            else
            {
                string err = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể cập nhật loại sách!\n" + err);
            }
        }

        private async void btneditLoaiSach_Click(object sender, EventArgs e)
        {
            await EditLoaiSach();
        }
        private async Task DeleteLoaiSach()
        {
            if (string.IsNullOrEmpty(txtMaLoaiSach.Text))
            {
                MessageBox.Show("Vui lòng chọn loại sách cần xóa!");
                return;
            }
            int id = int.Parse(txtMaLoaiSach.Text);
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa loại sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            var response = await client.DeleteAsync($"LoaiSach/{id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xóa loại sách thành công!");
                await LoadLoaiSach();
            }
            else
            {
                string err = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể xóa loại sách!\n" + err);
            }
        }

        private async void btnclearLoaiSach_Click(object sender, EventArgs e)
        {
            await DeleteLoaiSach();
        }
        private void dsLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaLoaiSach.Text = dsLoaiSach.Rows[e.RowIndex].Cells["IDLoaiSach"].Value.ToString();
                txtTenLoaiSach.Text = dsLoaiSach.Rows[e.RowIndex].Cells["TenLoaiSach"].Value.ToString();
            }
        }
        private void btnexitLoaiSach_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {                
                this.Close();
            }
        }
        // ========== Tác Giả ==========
        private async Task LoadTacGia()
        {
            var response = await client.GetAsync("TacGia");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<TacGia>>(json);

            dsTacGia.DataSource = data;
        }
        private async void btnviewTacGia_Click(object sender, EventArgs e)
        {
            await LoadTacGia();
        }
        private async Task SearchTacGia()
        {
            string keyword = txtTenTacGia.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTacGia.Focus();
                return;
            }
            var response = await client.GetAsync($"TacGia/search?name={keyword}");
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Lỗi truy vấn API!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<TacGia>>(json);
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tác giả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTacGia.Focus();
                return;
            }
            dsTacGia.DataSource = data;
        }
        private async void btnsearchTacGia_Click(object sender, EventArgs e)
        {
            await SearchTacGia();
        }
        private async Task AddTacGia()
        {
            if (string.IsNullOrEmpty(txtTenTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var tacGia = new
            {
                HoTen = txtTenTacGia.Text
            };
            var json = JsonConvert.SerializeObject(tacGia);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("TacGia", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm tác giả thành công!");
                await LoadTacGia();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể thêm tác giả!\n" + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnaddTacGia_Click(object sender, EventArgs e)
        {
            await AddTacGia();
        }
        private async Task EditTacGia()
        {
            if (string.IsNullOrEmpty(txtMaTacGia.Text) ||
                string.IsNullOrEmpty(txtTenTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            int id = int.Parse(txtMaTacGia.Text);
            var tacGia = new
            {
                IDTacGia = id,
                HoTen = txtTenTacGia.Text
            };
            var json = JsonConvert.SerializeObject(tacGia);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"TacGia/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật tác giả thành công!");
                await LoadTacGia();
            }
            else
            {
                string err = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể cập nhật tác giả!\n" + err);
            }
        }
        private async void btneditTacGia_Click(object sender, EventArgs e)
        {
            await EditTacGia();
        }
        private async Task DeleteTacGia()
        {
            if (string.IsNullOrEmpty(txtMaTacGia.Text))
            {
                MessageBox.Show("Vui lòng chọn tác giả cần xóa!");
                return;
            }
            int id = int.Parse(txtMaTacGia.Text);
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa tác giả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            var response = await client.DeleteAsync($"TacGia/{id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xóa tác giả thành công!");
                await LoadTacGia();
            }
            else
            {
                string err = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Không thể xóa tác giả!\n" + err);
            }
        }
        private async void btnclearTacGia_Click(object sender, EventArgs e)
        {
            await DeleteTacGia();
        }
        private void dsTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaTacGia.Text = dsTacGia.Rows[e.RowIndex].Cells["IDTacGia"].Value.ToString();
                txtTenTacGia.Text = dsTacGia.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
            }
        }
        private void btnexitTacGia_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {                
                this.Close();
            }
        }
    }
}