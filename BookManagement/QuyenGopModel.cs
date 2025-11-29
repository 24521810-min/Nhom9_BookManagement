using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    public class QuyenGopModel
    {
        public int IDQuyenGop { get; set; }
        public int IDUser { get; set; }
        public string TenSach { get; set; }
        public string LoaiSach { get; set; }
        public string TacGia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayQuyenGop { get; set; }
        public string TrangThai { get; set; }
    }

}
