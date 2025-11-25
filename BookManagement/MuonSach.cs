using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Muonsach : Form
    {
        // Chuỗi kết nối giống DangNhap.cs
        private string connectionString =
            @"Data Source=localhost;Initial Catalog=BookManagementDB;Integrated Security=True;";

        // 0 nghĩa là chưa biết user nào, sẽ tự lấy từ DB khi mượn sách
        
        private int currentUserId = 0;

        public Muonsach()
        {
            InitializeComponent();
           

            // Gán event (vì Designer của bạn chưa gán)
            this.Load += MuonSach_Load;
            textBox_timkiem.TextChanged += textBox_timkiem_TextChanged;
            button_muonsach.Click += button_muonsach_Click;
        }

        // ====== FORM LOAD ======
        private void MuonSach_Load(object sender, EventArgs e)
        {
            LoadDanhSachSach();
        }

        // ====== LOAD DANH SÁCH SÁCH ======
        private void LoadDanhSachSach()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT S.IDSach, S.TenSach, TG.HoTen AS TacGia, S.SoLuong
                        FROM Sach S
                        LEFT JOIN TacGia TG ON S.IDTacGia = TG.IDTacGia";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Nếu muốn debug:
                        // MessageBox.Show("Số sách lấy được: " + dt.Rows.Count);

                        bangds.Rows.Clear();
                        int stt = 1;

                        foreach (DataRow r in dt.Rows)
                        {
                            int index = bangds.Rows.Add();
                            bangds.Rows[index].Cells[0].Value = stt++;
                            bangds.Rows[index].Cells[1].Value = r["TenSach"];
                            bangds.Rows[index].Cells[2].Value = r["IDSach"];
                            bangds.Rows[index].Cells[3].Value = r["TacGia"];
                            bangds.Rows[index].Cells[4].Value = 1;               // Số lượng mượn mặc định
                            bangds.Rows[index].Cells[5].Value = r["SoLuong"];     // Số lượng còn lại
                            bangds.Rows[index].Cells[6].Value = false;           // Chưa chọn
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải danh sách sách. Vui lòng kiểm tra:\n" +
                    "1. SQL Server đã bật chưa.\n" +
                    "2. Chuỗi kết nối có đúng không.\n" +
                    "3. Database 'BookManagementDB' đã tồn tại chưa.\n\n" +
                    "Thông tin lỗi: " + ex.Message,
                    "Lỗi Kết Nối Cơ Sở Dữ Liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ====== TÌM KIẾM THEO TÊN SÁCH ======
        private void textBox_timkiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox_timkiem.Text.Trim().ToLower();

            foreach (DataGridViewRow row in bangds.Rows)
            {
                if (row.IsNewRow) continue;

                string tenSach = row.Cells[1].Value?.ToString().ToLower() ?? "";
                row.Visible = tenSach.Contains(keyword);
            }
        }

        // ====== HÀM LẤY TẠM MỘT IDUSER BẤT KỲ TRONG BẢNG USERS ======
        // (để không sửa DangNhap.cs mà vẫn không lỗi FK)
        private int GetAnyUserId()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT TOP 1 IDUser FROM Users ORDER BY IDUser";

                object result = new SqlCommand(sql, conn).ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    throw new Exception("Chưa có user nào trong bảng Users. Hãy đăng ký ít nhất một tài khoản.");

                return Convert.ToInt32(result);
            }
        }

        // ====== NÚT MƯỢN SÁCH ======
        private void button_muonsach_Click(object sender, EventArgs e)
        {
            try
            {
                // Nếu chưa có userId thì tạm lấy 1 user bất kỳ trong bảng Users
                if (currentUserId == 0)
                {
                    currentUserId = GetAnyUserId();
                }

                DateTime ngayMuon = dateTimePicker_muon.Value;
                DateTime ngayTra = dateTimePicker_tradk.Value;

                bool daMuonDuocSach = false;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in bangds.Rows)
                    {
                        if (row.IsNewRow) continue;

                        bool isChecked = false;
                        if (row.Cells[6].Value != null)
                            isChecked = Convert.ToBoolean(row.Cells[6].Value);

                        if (!isChecked) continue;

                        int idSach = Convert.ToInt32(row.Cells[2].Value);
                        int soLuongMuon = Convert.ToInt32(row.Cells[4].Value);
                        int soLuongCon = Convert.ToInt32(row.Cells[5].Value);

                        if (soLuongMuon <= 0)
                        {
                            MessageBox.Show("Số lượng mượn phải lớn hơn 0.");
                            continue;
                        }

                        if (soLuongMuon > soLuongCon)
                        {
                            MessageBox.Show($"Sách ID {idSach} không đủ số lượng để mượn.");
                            continue;
                        }

                        // INSERT vào bảng MuonSach
                        string sqlInsert = @"
                            INSERT INTO MuonSach (IDUser, IDSach, NgayMuon, NgayTraDuKien)
                            VALUES (@IDUser, @IDSach, @NgayMuon, @NgayTraDuKien)";

                        using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@IDUser", currentUserId);
                            cmdInsert.Parameters.AddWithValue("@IDSach", idSach);
                            cmdInsert.Parameters.AddWithValue("@NgayMuon", ngayMuon);
                            cmdInsert.Parameters.AddWithValue("@NgayTraDuKien", ngayTra);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // Cập nhật lại số lượng sách
                        string sqlUpdate = @"
                            UPDATE Sach SET SoLuong = SoLuong - @SL WHERE IDSach = @IDSach";

                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@SL", soLuongMuon);
                            cmdUpdate.Parameters.AddWithValue("@IDSach", idSach);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        daMuonDuocSach = true;
                    }
                }

                if (daMuonDuocSach)
                {
                    MessageBox.Show("Mượn sách thành công!");
                    LoadDanhSachSach();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sách.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mượn sách:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
