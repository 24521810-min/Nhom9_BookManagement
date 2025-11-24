namespace BookApi.Models
{
    public class User
    {
        public int IDUser { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        // ===== Navigation Properties =====
        public ICollection<MuonSach>? MuonSachs { get; set; }
        public ICollection<TraSach>? TraSachs { get; set; }
        public ICollection<QuyenGop>? QuyenGops { get; set; }
    }
}
