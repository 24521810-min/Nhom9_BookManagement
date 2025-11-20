using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BookApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TacGia> TacGia { get; set; }
        public DbSet<LoaiSach> LoaiSach { get; set; }
        public DbSet<Sach> Sach { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Sach>().ToTable("Sach");
            modelBuilder.Entity<TacGia>().ToTable("TacGia");
            modelBuilder.Entity<LoaiSach>().ToTable("LoaiSach");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
