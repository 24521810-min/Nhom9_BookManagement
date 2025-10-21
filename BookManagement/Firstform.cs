using Microsoft.Win32;
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
    public partial class Firstform : Form
    {
        public Firstform()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangnhapForm = new DangNhap();
            dangnhapForm.ShowDialog();
            this.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangnhap_admin dangnhapForm = new Dangnhap_admin();
            if (dangnhapForm.ShowDialog() == DialogResult.OK)
            {
                Admin adminForm = new Admin();
                adminForm.ShowDialog(); // Chờ admin đóng
            }
        }
    }
}
