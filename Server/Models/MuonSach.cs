using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MuonSach
{
    [Key]
    public int IDMuon { get; set; }

    public int IDUser { get; set; }  // chỉ giữ IDUser

    [ForeignKey(nameof(Sach))]
    public int IDSach { get; set; }

    public DateTime NgayMuon { get; set; }
    public DateTime NgayTraDuKien { get; set; }

    public string TrangThai { get; set; } = string.Empty;

    public Sach? Sach { get; set; }   // giữ navigation Sách là đúng
}
