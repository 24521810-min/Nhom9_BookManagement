using System;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Users : Form
    {
        // Lưu ID user đang đăng nhập
        private int _currentUserId;

        // Constructor cũ (không có userId) – vẫn giữ để không bị lỗi
        public Users()
        {
            InitializeComponent();
            _currentUserId = 0; // 0 = chưa biết user, mượn sách test sẽ dùng default
        }

        // Constructor mới: nhận ID user từ form đăng nhập
        public Users(int userId) : this()
        {
            _currentUserId = userId;
        }

        // Sự kiện click nút "Mượn sách" trên form Users
        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            // Nếu đã có ID user thật thì truyền vào, không thì dùng form default
            Muonsach f;

            if (_currentUserId > 0)
            {
                f = new Muonsach(_currentUserId);
            }
            else
            {
                // chạy thử khi chưa có luồng đăng nhập
                f = new Muonsach();
            }

            f.Show();
            this.Hide();
        }
    }
}
