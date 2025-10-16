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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void lbUnaccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            //DangKy dangKyForm = new DangKy();
            //dangKyForm.ShowDialog();
            this.Show();
        }
    }
}
