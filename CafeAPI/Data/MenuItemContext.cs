using CafeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Data
{
    public class MenuItemContext : DbContext
    {
        public MenuItemContext(DbContextOptions<MenuItemContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { Id = 1, SKU = "COFFEE", Description = "Coffee", Cost = 1.5M });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { Id = 2, SKU = "TEA", Description = "Tea", Cost = 1.2M });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { Id = 3, SKU = "HOTCHOC", Description = "Hot chocolate", Cost = 2.0M });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { Id = 4, SKU = "SUGAR", Description = "Sugar", Cost = 0.1M });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { Id = 5, SKU = "MILK", Description = "Milk", Cost = 0.3M });
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem { Id = 6, SKU = "MALLOWS", Description = "Marshmallows", Cost = 0.6M });
        }
    }
}
