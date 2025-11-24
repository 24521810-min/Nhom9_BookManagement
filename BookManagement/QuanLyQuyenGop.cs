using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class QuanLyQuyenGop : Form
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7214/")
        };

        public QuanLyQuyenGop()
        {
            InitializeComponent();

            Load += QuanLyQuyenGop_Load;

            button6.Click += BtnQuyenGop_Click;   // Quyên góp
            button7.Click += BtnXem_Click;        // Xem danh sách Quyên Góp
            button8.Click += (s, e) => Close();   // Thoát
        }

        // =======================================================
        // 1. LOAD DANH SÁCH QUYÊN GÓP KHI MỞ FORM
        // =======================================================
        private async void QuanLyQuyenGop_Load(object sender, EventArgs e)
        {
            await LoadDanhSachQuyenGop();
        }

        private async Task LoadDanhSachQuyenGop()
        {
            try
            {
                var list = await _client.GetFromJsonAsync<List<QuyenGop>>("api/QuyenGop");
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách Quyên Góp: " + ex.Message);
            }
        }

        private async void BtnXem_Click(object sender, EventArgs e)
        {
            await LoadDanhSachQuyenGop();
        }

        // =======================================================
        // 2. NÚT QUYÊN GÓP
        // =======================================================
        private async void BtnQuyenGop_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Vui lòng nhập Họ Tên người quyên góp!");
                    return;
                }

                if (!int.TryParse(txtMaSach.Text, out int idSach))
                {
                    MessageBox.Show("Mã sách không hợp lệ!");
                    return;
                }

                var sach = await _client.GetFromJsonAsync<Sach>($"api/Sach/{idSach}");
                if (sach == null)
                {
                    MessageBox.Show("Không tìm thấy sách!");
                    return;
                }

                // Lấy tên tác giả
                string tacGia = sach.TacGia?.HoTen ?? "Không rõ";

                var model = new QuyenGop
                {
                    IDUser = 1,                 // tạm user 1
                    TenSach = sach.TenSach,
                    TacGia = tacGia,
                    SoLuong = 1,
                    NgayQuyenGop = DateTime.Now,
                    TrangThai = "Đã tiếp nhận"
                };

                var res = await _client.PostAsJsonAsync("api/QuyenGop", model);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("✔ Quyên góp thành công!");
                    await LoadDanhSachQuyenGop();   // 🔥 load lại bảng ngay lập tức
                }
                else
                {
                    MessageBox.Show("API lỗi: " + res.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quyên góp: " + ex.Message);
            }
        }
    }
}
