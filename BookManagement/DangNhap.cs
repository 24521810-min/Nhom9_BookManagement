using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class DangNhap : Form
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=BookManagementDB;Integrated Security=True;";

        public DangNhap()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userInput = txtUsername.Text.Trim();   // Username hoặc Email
            string password = txtPassword.Text;

            if (userInput == "" || password == "")
            {
                MessageBox.Show("Please enter username/email and password!");
                return;
            }

            // Hash password nhập vào để so sánh với PasswordHash
            string hash = PasswordHelper.HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT IDUser, FullName, Role, IsLocked
                    FROM Users
                    WHERE (UserName = @input OR Email = @input)
                          AND PasswordHash = @pw";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@input", userInput);
                cmd.Parameters.AddWithValue("@pw", hash);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bool locked = reader.GetBoolean(reader.GetOrdinal("IsLocked"));

                    if (locked)
                    {
                        MessageBox.Show("Your account is locked. Please contact admin!");
                        return;
                    }

                    string name = reader["FullName"].ToString();
                    string role = reader["Role"].ToString();

                    MessageBox.Show($"Welcome back, {name}!");

                    // Mở form chính 
                    Users f = new Users();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username/email or password!");
                }
            }
        }
        //Don't have an account
        private void lbUnaccount_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
            this.Hide();
        }

    }
}
