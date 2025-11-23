using BookApi.Models;
using System.ComponentModel.DataAnnotations;

public class MuonSach
{
    [Key]
    public int IDMuon { get; set; }

    public int IDUser { get; set; }
    public int IDSach { get; set; }

    public DateTime NgayMuon { get; set; }
    public DateTime NgayTraDuKien { get; set; }

    public string TrangThai { get; set; } = string.Empty;

    // Navigation
    public User? User { get; set; }
    public Sach? Sach { get; set; }
}
