using BookApi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;   // thêm dòng này

public class MuonSach
{
    [Key]
    public int IDMuon { get; set; }

    // NÓI RÕ: IDUser là FK của navigation User
    [ForeignKey(nameof(User))]
    public int IDUser { get; set; }

    [ForeignKey(nameof(Sach))]
    public int IDSach { get; set; }

    public DateTime NgayMuon { get; set; }
    public DateTime NgayTraDuKien { get; set; }

    public string TrangThai { get; set; } = string.Empty;

    // Navigation
    public User? User { get; set; }
    public Sach? Sach { get; set; }
}
