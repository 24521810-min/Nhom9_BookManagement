using Microsoft.EntityFrameworkCore;
using BookApi.Models;

namespace BookApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sach> Sach { get; set; }
        public DbSet<LoaiSach> LoaiSach { get; set; }
        public DbSet<TacGia> TacGia { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MuonSach> MuonSach { get; set; }
        public DbSet<TraSach> TraSach { get; set; }
        public DbSet<QuyenGop> QuyenGop { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ====== Sách ======
            modelBuilder.Entity<Sach>()
                .ToTable("Sach");

            modelBuilder.Entity<Sach>()
                .HasKey(s => s.IDSach);

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.TacGia)
                .WithMany(t => t.Sachs)
                .HasForeignKey(s => s.IDTacGia);

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.LoaiSach)
                .WithMany(l => l.Sachs)
                .HasForeignKey(s => s.IDLoaiSach);

            // ====== User ======
            modelBuilder.Entity<User>()
                .HasKey(u => u.IDUser);

            // FIX toàn bộ quan hệ lỗi từ User → MuonSach, TraSach
            modelBuilder.Entity<User>()
                .Ignore(u => u.TraSachs);

            modelBuilder.Entity<User>()
                .Ignore(u => u.MuonSachs);

            // ====== QuyenGop ======
            modelBuilder.Entity<QuyenGop>()
                .HasOne(q => q.User)
                .WithMany(u => u.QuyenGops)
                .HasForeignKey(q => q.IDUser);

            // ====== TraSach -> MuonSach ======
            modelBuilder.Entity<TraSach>()
                .HasOne(t => t.MuonSach)
                .WithMany()
                .HasForeignKey(t => t.IDMuon);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TraSach>()
    .HasOne(t => t.MuonSach)
    .WithMany()                  // KHÔNG có navigation ngược bên MuonSach
    .HasForeignKey(t => t.IDMuon)
    .OnDelete(DeleteBehavior.Restrict); // tránh lỗi vòng xoá

        }
    }
}
