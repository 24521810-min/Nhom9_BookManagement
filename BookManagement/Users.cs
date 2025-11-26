using System;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Users : Form
    {
        private int _currentUserId;

        public Users()
        {
            InitializeComponent();
            _currentUserId = Program.LoggedUserID; // lấy từ đăng nhập
        }

        public Users(int userId) : this()
        {
            _currentUserId = userId;
        }

        // ==== MƯỢN SÁCH ====
        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            Muonsach f;

            if (_currentUserId > 0)
                f = new Muonsach(_currentUserId);
            else
                f = new Muonsach();   

            f.Show();
            this.Hide();
        }

        // ==== QUYÊN GÓP SÁCH ====
        private void btnQuyenGop_Click(object sender, EventArgs e)
        {
            QuyenGopSach qg = new QuyenGopSach();
            qg.Show();
            this.Hide();
        }

        // ==== TRẢ SÁCH ====
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            Trasach t = new Trasach();
            t.Show();
            this.Hide();
        }

        // ==== ĐĂNG XUẤT ====
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Program.LoggedUserID = -1;

            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }
    }
}
