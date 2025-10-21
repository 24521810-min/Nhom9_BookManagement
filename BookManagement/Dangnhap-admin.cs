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
    public partial class Dangnhap_admin : Form
    {
        public Dangnhap_admin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameoremail = txtusername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string adminUser = "admin";
            string adminEmail = "admin@gmail.com";
            string adminPass = "123456";

            if (string.IsNullOrWhiteSpace(usernameoremail) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username/Password!");
                return;
            }

            if ((usernameoremail.Equals(adminUser, StringComparison.OrdinalIgnoreCase) ||
                 usernameoremail.Equals(adminEmail, StringComparison.OrdinalIgnoreCase))
                 && password == adminPass)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username/Email hoặc Password sai, vui lòng thử lại!");
            }
        }

        private void lbForgot_Click(object sender, EventArgs e)
        {

        }
    }
}
