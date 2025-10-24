using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Api.Models;
using System.Security.Cryptography.X509Certificates;

namespace MyOnlineShop.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "T-Shirt", Description = "Cotton", Price = 19.99m, DiscountPercent = 0, IsActive = true, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = 2, Name = "Mug", Description = "Coffee Mug 300ml", Price = 9.5m, DiscountPercent = 10, IsActive = true, CreatedAt = new DateTime(2025, 1, 1) },
                new Product { Id = 3, Name = "Notebook", Description = "A5 Notebook", Price = 4.75m, DiscountPercent = 0, IsActive = true, CreatedAt = new DateTime(2025, 1, 1) }
            );

            modelBuilder.Entity<DiscountCoupon>().HasData(
                new DiscountCoupon { Id = 1, Code = "WELCOME10", Percentage = 10, Expiry = new DateTime(2026, 12, 31), IsActive = true }
            );
        }
    }
    
}
