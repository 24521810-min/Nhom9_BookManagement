using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Muonsach : Form
    {
        // Chuỗi kết nối: dùng (localdb)\MSSQLLocalDB, DB tên BookManagementDB
        private string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookManagementDB;Integrated Security=True;";

        // ID user đang mượn sách
        private int currentUserId;

        // Constructor cũ – dùng cho trường hợp test khi chưa truyền userId
        public Muonsach()
        {
            InitializeComponent();

            // Tạm set = 1 để mượn sách thử
            currentUserId = 1;

            // Gắn event
            this.Load += MuonSach_Load;
            textBox_timkiem.TextChanged += textBox_timkiem_TextChanged;
            button_muonsach.Click += button_muonsach_Click;
        }

        // Constructor mới: nhận ID user thật từ form Users
        public Muonsach(int userId) : this()
        {
            currentUserId = userId;
        }

        // Khi form load thì tải danh sách sách
        private void MuonSach_Load(object sender, EventArgs e)
        {
            LoadDanhSachSach();
        }

        // Load danh sách sách khả dụng lên DataGridView
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

                        bangds.Rows.Clear();
                        int stt = 1;

                        foreach (DataRow r in dt.Rows)
                        {
                            int index = bangds.Rows.Add();
                            bangds.Rows[index].Cells[0].Value = stt++;              // STT
                            bangds.Rows[index].Cells[1].Value = r["TenSach"];        // Tên sách
                            bangds.Rows[index].Cells[2].Value = r["IDSach"];         // Mã sách (ID)
                            bangds.Rows[index].Cells[3].Value = r["TacGia"];         // Tác giả
                            bangds.Rows[index].Cells[4].Value = 1;                   // Số lượng mượn mặc định = 1
                            bangds.Rows[index].Cells[5].Value = r["SoLuong"];        // Số lượng còn lại
                            bangds.Rows[index].Cells[6].Value = false;               // Chưa chọn
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải danh sách sách.\n\nChi tiết: " + ex.Message,
                    "Lỗi Kết Nối Cơ Sở Dữ Liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Lọc theo tên sách khi gõ trong ô tìm kiếm
        private void textBox_timkiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox_timkiem.Text.Trim().ToLower();

            foreach (DataGridViewRow row in bangds.Rows)
            {
                if (row.IsNewRow) continue;

                string tenSach = row.Cells[1].Value?.ToString().ToLower() ?? "";

                // Ẩn/hiện theo từ khóa
                row.Visible = tenSach.Contains(keyword);
            }
        }

        // Xử lý mượn sách
        private void button_muonsach_Click(object sender, EventArgs e)
        {
            DateTime ngayMuon = dateTimePicker_muon.Value;
            DateTime ngayTra = dateTimePicker_tradk.Value;

            bool daMuonDuocSach = false;

            try
            {
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

                        int idSach = Convert.ToInt32(row.Cells[2].Value);   // IDSach
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

                        // 1. Lưu vào bảng MuonSach
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

                        // 2. Trừ số lượng trong bảng Sach
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
                    LoadDanhSachSach(); // load lại danh sách sau khi trừ số lượng
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sách nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi mượn sách:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
