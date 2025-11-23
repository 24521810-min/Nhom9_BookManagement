using BookApi.Models;
using System.ComponentModel.DataAnnotations;

public class QuyenGop
{
    [Key]
    public int IDQuyenGop { get; set; }

    public int IDUser { get; set; }

    public string TenSach { get; set; } = string.Empty;
    public string TacGia { get; set; } = string.Empty;
    public int SoLuong { get; set; }

    public DateTime NgayQuyenGop { get; set; }
    public string TrangThai { get; set; } = string.Empty;

    // Navigation
    public User? User { get; set; }
}
