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
                dsQuyengop.DataSource = list;
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

        private async void btnDuyet_Click(object sender, EventArgs e)
        {
            await HandleDonationAction("duyet");
        }

        private async void btnTuchoi_Click(object sender, EventArgs e)
        {
            await HandleDonationAction("tuchoi");
        }
        private async Task HandleDonationAction(string action)
        {
            if (dsQuyengop.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một mục quyên góp để xử lý.", "Cảnh báo");
                return;
            }
            var selectedItem = dsQuyengop.SelectedRows[0].DataBoundItem as QuyenGop;

            if (selectedItem == null)
            {
                MessageBox.Show("Không đọc được dữ liệu của dòng đã chọn.");
                return;
            }
            int idQuyenGop = selectedItem.IDQuyenGop;

            string actionDisplay = action == "duyet" ? "DUYỆT" : "TỪ CHỐI";

            if (MessageBox.Show($"Bạn có chắc chắn muốn {actionDisplay} tài khoản này không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            btnDuyet.Enabled = btnTuchoi.Enabled = false;
            try
            {
                HttpResponseMessage res = await _client.PutAsync($"api/QuyenGop/{action}/{idQuyenGop}", null);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show($"{actionDisplay} quyên góp ID {idQuyenGop} thành công! Email thông báo đã được gửi.", "Thành công");

                    await LoadDanhSachQuyenGop();
                }
                else
                {
                    string errorContent = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi API ({res.StatusCode}): {errorContent}", "Lỗi Xử lý");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi Hệ thống");
            }
            finally
            {
                btnDuyet.Enabled = btnTuchoi.Enabled = true;
            }
        }
    }
}
