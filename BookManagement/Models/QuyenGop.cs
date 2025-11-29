using System;

namespace BookManagement.Models
{
    public class QuyenGop
    {
        public int IDQuyenGop { get; set; }
        public int IDUser { get; set; }
        public string TenSach { get; set; }
        public string LoaiSach { get; set; }
        public string TacGia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayQuyenGop { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public string TrangThai { get; set; }
    }
}
