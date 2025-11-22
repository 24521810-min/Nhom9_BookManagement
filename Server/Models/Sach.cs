using System.ComponentModel.DataAnnotations;

public class Sach
{
    [Key]
    public int IDSach { get; set; }

    public string TenSach { get; set; } = string.Empty;

    public int IDTacGia { get; set; }
    public TacGia? TacGia { get; set; }

    public int IDLoaiSach { get; set; }
    public LoaiSach? LoaiSach { get; set; }

    public int SoLuong { get; set; }
}