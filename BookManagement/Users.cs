using System;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Users : Form
    {
        private readonly int _currentUserId;

        // ===== CONSTRUCTOR DUY NHẤT =====
        public Users(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
        }

        // ===== MƯỢN SÁCH =====
        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            new Muonsach(_currentUserId).Show();
            this.Hide();
        }

        // ===== QUYÊN GÓP =====
        private void btnQuyenGop_Click(object sender, EventArgs e)
        {
            new QuyenGopSach(_currentUserId).Show();
            this.Hide();
        }

        // ===== TRẢ SÁCH =====
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            new Trasach(_currentUserId).Show();
            this.Hide();
        }

        // ===== HỒ SƠ ĐĂNG KÝ =====
        private void btnHoSo_Click(object sender, EventArgs e)
        {
            new HoSoDKi(_currentUserId).Show();
            this.Hide();
        }

        // ===== ĐĂNG XUẤT =====
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                Program.LoggedUserID = -1;
                Program.Token = null;

                new DangNhap().Show();
                this.Close();
            }
        }
    }
}