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
            this.Hide();
            KhoSach khosachForm = new KhoSach();
            khosachForm.ShowDialog();
            this.Show();
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
    }
}
