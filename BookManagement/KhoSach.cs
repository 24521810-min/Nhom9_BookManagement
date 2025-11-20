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
        private async Task LoadSach()
        {
            var response = await client.GetAsync("Sach");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Sach>>(json);

            dsSach.DataSource = data;
        }
        private async Task LoadLoaiSach()
        {
            var response = await client.GetAsync("LoaiSach");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<LoaiSach>>(json);

            dsLoaiSach.DataSource = data;
        }
        private async Task LoadTacGia()
        {
            var response = await client.GetAsync("TacGia");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<TacGia>>(json);

            dsTacGia.DataSource = data;
        }
        private async Task AddSach()
        {
            var sach = new Sach
            {
                IDSach = int.Parse(txtMaSach.Text),
                TenSach = txtTenSach.Text,
                IDTacGia = int.Parse(txtTacGia.Text),
                IDLoaiSach = int.Parse(txtLoaiSach.Text),
                SoLuong = int.Parse(txtSoLuong.Text)
            };

            var json = JsonConvert.SerializeObject(sach);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Sach", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm sách thành công!");
                await LoadSach(); // load lại datagrid
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm sách!");
            }
        }
        private async void btnadd_Click(object sender, EventArgs e)
        {
            await AddSach();
        }
        private async Task UpdateSach()
        {
            var id = int.Parse(txtMaSach.Text);

            var sach = new Sach
            {
                IDSach = id,
                TenSach = txtTenSach.Text,
                IDTacGia = int.Parse(txtTacGia.Text),
                IDLoaiSach = int.Parse(txtLoaiSach.Text),
                SoLuong = int.Parse(txtSoLuong.Text)
            };

            var json = JsonConvert.SerializeObject(sach);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"Sach/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật sách thành công!");
                await LoadSach();
            }
            else
                MessageBox.Show("Không thể cập nhật sách!");
        }

        private async void btnedit_Click(object sender, EventArgs e)
        {
            await UpdateSach();
        }
        private async Task DeleteSach()
        {
            var id = int.Parse(txtMaSach.Text);
            var response = await client.DeleteAsync($"Sach/{id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xóa sách thành công!");
                await LoadSach();
            }
            else
                MessageBox.Show("Không thể xóa sách!");
        }
        private async void btndelete_Click(object sender, EventArgs e)
        {
            await DeleteSach();
        }
        private async Task SearchSach()
        {
            string keyword = txtTenSach.Text.Trim();

            var response = await client.GetAsync($"Sach/search?name={keyword}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Không tìm thấy sách!");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Sach>>(json);

            dsSach.DataSource = data;
        }
        private async void btnsearch_Click(object sender, EventArgs e)
        {
            await SearchSach();
        }

        private void dsSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaSach.Text = dsSach.Rows[e.RowIndex].Cells["IDSach"].Value.ToString();
                txtTenSach.Text = dsSach.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();
                txtTacGia.Text = dsSach.Rows[e.RowIndex].Cells["IDTacGia"].Value.ToString();
                txtLoaiSach.Text = dsSach.Rows[e.RowIndex].Cells["IDLoaiSach"].Value.ToString();
                txtSoLuong.Text = dsSach.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
            }
        }
    }
}
