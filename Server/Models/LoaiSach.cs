using System.ComponentModel.DataAnnotations;

public class LoaiSach
{
    [Key]
    public int IDLoaiSach { get; set; }

    public required string TenLoaiSach { get; set; }

    public ICollection<Sach>? Sachs { get; set; }
}