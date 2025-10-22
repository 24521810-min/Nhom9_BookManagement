using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
            btnSignup.Click += BtnSignup_Click;
           

        }

        // Nút Signup
        private void BtnSignup_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                RegisterUser();
            }
        }

        // Kiểm tra dữ liệu hợp lệ 
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmpassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text != txtConfirmpassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPhone.Text.Length < 9 || !txtPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Hàm băm mật khẩu SHA256 
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


        // Ghi thông tin người dùng vào SQL Server 
        private void RegisterUser()
        {
            string connectionString = GetConnectionString();

            string fullname = txtFullname.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string passwordHash = HashPassword(txtPassword.Text.Trim());

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng username
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm người dùng mới
                    string insertQuery = @"INSERT INTO Users (FullName, Username, Email, Phone, PasswordHash)
                                   VALUES (@FullName, @Username, @Email, @Phone, @PasswordHash)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@FullName", fullname);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    DangNhap dangNhapForm = new DangNhap();
                    dangNhapForm.ShowDialog();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối hoặc ghi dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbAccount_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form đăng ký hiện tại
            DangNhap dangNhapForm = new DangNhap();
            dangNhapForm.ShowDialog(); // Mở form đăng nhập
            this.Close();
        }
    }
}
