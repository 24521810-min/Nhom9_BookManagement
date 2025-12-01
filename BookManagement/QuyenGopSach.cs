using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using System.Windows.Forms;

namespace BookManagement
{
    public partial class QuyenGopSach : Form
    {
        public QuyenGopSach()
        {
            InitializeComponent();
        }

        private void QuyenGopSach_Load(object sender, EventArgs e)
        {
            LoadDanhSachQuyenGop();
        }

        private async void button_guiyc_Click(object sender, EventArgs e)
        {
            string tenSach = textBox_tensach.Text.Trim();
            string loaiSach = txtLoaiSach.Text.Trim();
            string tacGia = textBox_tacgia.Text.Trim();
            string soLuongStr = textBox_sluong.Text.Trim();
            string tinhTrang = textBox_tt.Text.Trim();
            string ghiChu = textBox_ghichu.Text.Trim();

            if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(tacGia) ||
                string.IsNullOrEmpty(soLuongStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
                return;
            }

            if (!int.TryParse(soLuongStr, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên > 0!");
                return;
            }

            // Lấy ID user đang đăng nhập (bạn phải gán khi đăng nhập)
            int idUser = AuthSession.UserId;


            var model = new
            {
                IDUser = idUser,
                TenSach = tenSach,
                LoaiSach = loaiSach,
                TacGia = tacGia,
                SoLuong = soLuong,
                TinhTrang = tinhTrang,
                GhiChu = ghiChu
            };

            string json = JsonConvert.SerializeObject(model);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7214");

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/QuyenGop", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Gửi yêu cầu thành công!");
                    LoadDanhSachQuyenGop();  // Cập nhật lại bảng bên phải
                    ClearForm();
                }
                else
                {
                    string err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Gửi yêu cầu thất bại:\n" + response.StatusCode + "\n" + err);
                }

            }
        }
        private void ClearForm()
        {
            textBox_tensach.Clear();
            txtLoaiSach.Clear();
            textBox_tacgia.Clear();
            textBox_sluong.Clear();
            textBox_tt.Clear();
            textBox_ghichu.Clear();
        }

        private void button_huy_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void LoadDanhSachQuyenGop()
        {
            int idUser = AuthSession.UserId;

            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7214/api/QuyenGop/user/{idUser}";

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không thể tải danh sách!");
                    return;
                }

                string data = await response.Content.ReadAsStringAsync();

                var list = JsonConvert.DeserializeObject<List<QuyenGopModel>>(data);

                bangds.Rows.Clear();
                int stt = 1;

                foreach (var item in list)
                {
                    bangds.Rows.Add(
                        stt++,
                        item.TenSach,
                        item.LoaiSach,
                        item.TacGia,
                        item.SoLuong,
                        item.NgayQuyenGop.ToString("dd/MM/yyyy"),
                        item.TrangThai
                    );
                }
            }
        }
        
        private void button_TrangChu_Click(object sender, EventArgs e)
        {
            Users f = new Users();
            f.Show();
            this.Close();  
        }

        private void button_DangXuat_Click(object sender, EventArgs e)
        {
            AuthSession.UserId = 0;
            AuthSession.Token = "";
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void button_HSDKy_Click(object sender, EventArgs e)
        {
            HoSoDKi hs = new HoSoDKi();
            hs.Show();
            this.Hide();
        }
    }
}
