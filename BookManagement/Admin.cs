using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
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
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Program.LoggedUserID = -1;

                MessageBox.Show("Bạn đã đăng xuất!", "Thông báo");

                DangNhap dn = new DangNhap();
                dn.Show();
                this.Hide();
            }
        }
    }
}
