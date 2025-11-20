namespace BookApi.Models
{
    public class TacGia
    {
        public int IDTacGia { get; set; }
        public string HoTen { get; set; }

        public List<Sach> Saches { get; set; }  // Navigation
    }
}
