using System;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            // Gắn sự kiện cho nút Lịch Sử
            btnlichsu.Click += btnlichsu_Click;
        }

        private void btnKhoSach_Click(object sender, EventArgs e)
        {
            KhoSach f = new KhoSach();
            f.FormClosed += (s, args) => this.Show();
            this.Hide();
            f.Show();
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyNguoiDung qlusersForm = new QuanLyNguoiDung();
            qlusersForm.ShowDialog();
            this.Show();
        }

        private void btnQuanLyMuonTra_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyMuonTra qlborrowForm = new QuanLyMuonTra();
            qlborrowForm.ShowDialog();
            this.Show();
        }

        private void btnQuanLyQuyenGop_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyQuyenGop qldonateForm = new QuanLyQuyenGop();
            qldonateForm.ShowDialog();
            this.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                AuthSession.UserId = -1;
                AuthSession.Token = "";

                MessageBox.Show("Bạn đã đăng xuất!", "Thông báo");

                DangNhap dn = new DangNhap();
                dn.Show();
                this.Hide();
            }
        }

        // ===================================================
        //   NÚT LỊCH SỬ GIAO DỊCH (ĐÃ SỬA ĐÚNG TOKEN)
        // ===================================================
        private void btnlichsu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AuthSession.Token))
            {
                MessageBox.Show("Lỗi: Token trống! Bạn cần đăng nhập lại.");
                return;
            }

            LichSu f = new LichSu(AuthSession.Token);   // TRUYỀN TOKEN ĐÚNG
            f.FormClosed += (s, args) => this.Show();
            this.Hide();
            f.Show();
        }
    }
}
