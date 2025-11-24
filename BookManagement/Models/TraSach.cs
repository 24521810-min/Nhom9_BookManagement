using System;

namespace BookManagement.Models
{
    public class TraSach
    {
        public int IDTra { get; set; }
        public int IDMuon { get; set; }
        public int IDUser { get; set; }
        public DateTime NgayTra { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}
