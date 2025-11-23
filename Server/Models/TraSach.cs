using BookApi.Models;
using System.ComponentModel.DataAnnotations;

public class TraSach
{
    [Key]
    public int IDTra { get; set; }

    public int IDMuon { get; set; }
    public int IDUser { get; set; }

    public DateTime NgayTra { get; set; }

    public string TinhTrang { get; set; } = string.Empty;
    public string GhiChu { get; set; } = string.Empty;

    // Navigation
    public MuonSach? MuonSach { get; set; }
    public User? User { get; set; }
}
