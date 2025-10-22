using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            
        }

       

        // khi bấm nút Đăng nhập
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string passwordHash = HashPassword(password);
            string connectionString = GetConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra tài khoản tồn tại (Username hoặc Email đều được)
                    string query = @"SELECT COUNT(*) FROM Users 
                                     WHERE (Username = @User OR Email = @User) 
                                     AND PasswordHash = @PasswordHash";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@User", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        //mở mainform (users)
                        Users mainForm = new Users();
                        mainForm.ShowDialog();   
                        this.Close();            
                    }

                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm băm mật khẩu SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private string GetConnectionString()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;
             AttachDbFilename=|DataDirectory|\BookManagementDB.mdf;
             Integrated Security=True";
        }


        // Sự kiện khi click "Don't have an account?"
        private void lbUnaccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dangKyForm = new DangKy();
            dangKyForm.ShowDialog();
            this.Show();
        }
    }
}
