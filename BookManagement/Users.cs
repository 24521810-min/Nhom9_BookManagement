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
            _currentUserId = Program.LoggedUserID;
        }

        public Users(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
        }


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

        private void btnQuyenGop_Click(object sender, EventArgs e)
        {
            QuyenGopSach qg = new QuyenGopSach();
            qg.Show();
            this.Hide();
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            Trasach t = new Trasach();
            t.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Program.LoggedUserID = -1;

                DangNhap dn = new DangNhap();
                dn.Show();
                this.Hide();
            }
        }
    }
}
