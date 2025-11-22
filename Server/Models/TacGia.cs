using System.ComponentModel.DataAnnotations;

public class TacGia
{
    [Key]
    public int IDTacGia { get; set; }
    public required string HoTen { get; set; }

    public ICollection<Sach>? Sachs { get; set; }
}