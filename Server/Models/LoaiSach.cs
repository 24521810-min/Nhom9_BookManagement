namespace BookApi.Models
{
    public class LoaiSach
    {
        public int IDLoaiSach { get; set; }
        public string TenLoaiSach { get; set; }

        public List<Sach> Saches { get; set; }
    }
}