using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TraSach
{
    [Key]
    public int IDTra { get; set; }

    [ForeignKey(nameof(MuonSach))]
    public int IDMuon { get; set; }

    public DateTime NgayTra { get; set; }

    public string TinhTrang { get; set; } = string.Empty;

    public string GhiChu { get; set; } = string.Empty;

    // Navigation 1 chiều từ trả sách → mượn sách
    public MuonSach? MuonSach { get; set; }
}
