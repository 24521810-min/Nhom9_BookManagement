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
    public partial class Forgotpassword : Form
    {
        public Forgotpassword()
        {
            InitializeComponent();
        }
        private Form parentForm;
        public Forgotpassword(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string input = txtusername.Text.Trim();

            string adminUser = "admin";
            string adminEmail = "admin@gmail.com";
            string adminPass = "123456";

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username/Password!");
                return;
            }

            if (input == adminUser || input == adminEmail)
            {
                lbpass.Text = $"{adminPass}";
                lbpass.Visible = true;
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản nào phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbReturnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm.Show();
        }
    }
}
