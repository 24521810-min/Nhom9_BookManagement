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
            modelBuilder.Entity<Sach>()
                .ToTable("Sach");

            modelBuilder.Entity<Sach>()
                .HasKey(s => s.IDSach);

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.TacGia)
                .WithMany(t => t.Sachs)               
                .HasForeignKey(s => s.IDTacGia)
                .HasConstraintName("FK_Sach_TacGia");

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.LoaiSach)
                .WithMany(l => l.Sachs)              
                .HasForeignKey(s => s.IDLoaiSach)
                .HasConstraintName("FK_Sach_LoaiSach");

            modelBuilder.Entity<User>().HasKey(u => u.IDUser);
        }
    }
}