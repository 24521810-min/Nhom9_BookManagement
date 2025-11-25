using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class DangKy : Form
    {
        // Connection string 
        string connectionString =
            @"Data Source=localhost;Initial Catalog=BookManagementDB;Integrated Security=True;";

        public DangKy()
        {
            InitializeComponent();

            //Gắn event cho nút Sign Up
            btnSignup.Click += BtnSignup_Click;
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmpassword.Text;

            // Kiểm tra rỗng
            if (fullname == "" || username == "" || email == "" ||
                password == "" || confirm == "")
            {
                MessageBox.Show("Please fill in all required fields!");
                return;
            }

            // Kiểm tra khớp mật khẩu
            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // Hash mật khẩu
            string passwordHash = PasswordHelper.HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra trùng username/email
                string checkQuery = @"SELECT COUNT(*) FROM Users 
                                      WHERE UserName = @u OR Email = @e";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@u", username);
                checkCmd.Parameters.AddWithValue("@e", email);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Username or Email already exists!");
                    return;
                }

                // Thêm user vào DB
                string insertQuery = @"
                    INSERT INTO Users (FullName, UserName, Email, Phone, PasswordHash)
                    VALUES (@f, @u, @e, @p, @pw)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);

                insertCmd.Parameters.AddWithValue("@f", fullname);
                insertCmd.Parameters.AddWithValue("@u", username);
                insertCmd.Parameters.AddWithValue("@e", email);
                insertCmd.Parameters.AddWithValue("@p", phone);
                insertCmd.Parameters.AddWithValue("@pw", passwordHash);

                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Sign up successfully!");

            //Chuyển sang form đăng nhập
            DangNhap login = new DangNhap();
            login.Show();
            this.Hide();
        }

        // Already have an account?
        private void lbAccount_Click(object sender, EventArgs e)
        {
            DangNhap login = new DangNhap();
            login.Show();
            this.Hide();
        }
    }
}
