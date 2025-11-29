using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookManagement
{
    public partial class QuanLyNguoiDung : Form
    {
        private readonly HttpClient client = new HttpClient();
        private string apiUrl = "https://localhost:7214/api/Users";

        public QuanLyNguoiDung()
        {
            InitializeComponent();

            this.Load += QuanLyNguoiDung_Load;
            dsUsers.CellClick += dsUsers_CellClick;
        }

        private async void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            var response = await client.GetAsync(apiUrl);
            var data = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(data);

            dsUsers.DataSource = users;
        }

        private async void btnviewUser_Click(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async void btnsearchUser_Click(object sender, EventArgs e)
        {
            string keyword = txtUserName.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                return;
            }

            try
            {
                var response = await client.GetAsync($"{apiUrl}/search?keyword={keyword}");
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(data) ?? new List<User>();

                dsUsers.DataSource = null;
                dsUsers.DataSource = users;
                dsUsers.Refresh();

                if (users.Count == 0)
                    MessageBox.Show("Không tìm thấy người dùng nào!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
        private async void btnclearUser_Click(object sender, EventArgs e)
        {
            if (dsUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!");
                return;
            }

            int idUser = Convert.ToInt32(dsUsers.CurrentRow.Cells["IDUser"].Value);

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa người dùng này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No) return;

            var response = await client.DeleteAsync($"{apiUrl}/{idUser}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xóa người dùng thành công!");
                await LoadUsers();
            }
            else
                MessageBox.Show("Không thể xóa người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnlockUser_Click(object sender, EventArgs e)
        {
            if (dsUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng!");
                return;
            }

            int id = Convert.ToInt32(dsUsers.CurrentRow.Cells["IDUser"].Value);
            bool isLocked = Convert.ToBoolean(dsUsers.CurrentRow.Cells["IsLocked"].Value);

            string action = isLocked ? "unlock" : "lock";
            string message = isLocked ? "Mở khóa người dùng?" : "Khóa người dùng";

            var confirm = MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            var response = await client.PutAsync($"{apiUrl}/{action}/{id}", null);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(isLocked ? "Đã mở khóa!" : "Đã khóa!");
                await LoadUsers();
            }
            else
                MessageBox.Show("Thao tác thất bại!");
        }

        private void btnexitUser_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                this.Close();
        }

        private void dsUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dsUsers.Rows[e.RowIndex];
            txtFullName.Text = Convert.ToString(row.Cells["FullName"].Value ?? "");
            txtUserName.Text = Convert.ToString(row.Cells["UserName"].Value ?? "");
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value ?? "");
            txtPhone.Text = Convert.ToString(row.Cells["Phone"].Value ?? "");
            bool isLocked = Convert.ToBoolean(dsUsers.Rows[e.RowIndex].Cells["IsLocked"].Value);
            btnlockUser.Text = isLocked ? "Mở khóa" : "Khóa";
        }
    }
}
