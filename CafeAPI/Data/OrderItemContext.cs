using CafeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Data
{
    public class OrderItemContext : DbContext
    {
        public OrderItemContext(DbContextOptions<OrderItemContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 1, OrderId = 1, Quantity = 1, SKU = "COFFEE" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 2, OrderId = 1, Quantity = 1, SKU = "SUGAR" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 3, OrderId = 2, Quantity = 1, SKU = "TEA" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 4, OrderId = 2, Quantity = 1, SKU = "SUGAR" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 5, OrderId = 3, Quantity = 1, SKU = "TEA" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 6, OrderId = 3, Quantity = 2, SKU = "SUGAR" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 7, OrderId = 4, Quantity = 1, SKU = "TEA" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 8, OrderId = 4, Quantity = 2, SKU = "SUGAR" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 9, OrderId = 4, Quantity = 1, SKU = "DISC10" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 10, OrderId = 5, Quantity = 1, SKU = "TEA" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 11, OrderId = 5, Quantity = 1, SKU = "MILK" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 12, OrderId = 5, Quantity = 2, SKU = "SUGAR" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 13, OrderId = 6, Quantity = 1, SKU = "TEA" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 14, OrderId = 6, Quantity = 1, SKU = "MILK" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 15, OrderId = 6, Quantity = 2, SKU = "SUGAR" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 16, OrderId = 6, Quantity = 1, SKU = "DISC20" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 17, OrderId = 7, Quantity = 1, SKU = "HOTCHOC" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 18, OrderId = 7, Quantity = 1, SKU = "MALLOWS" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 19, OrderId = 8, Quantity = 1, SKU = "HOTCHOC" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 20, OrderId = 8, Quantity = 1, SKU = "MALLOWS" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 21, OrderId = 8, Quantity = 1, SKU = "DISC10" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 22, OrderId = 8, Quantity = 1, SKU = "DISC20" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 23, OrderId = 9, Quantity = 10, SKU = "COFFEE" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 24, OrderId = 9, Quantity = 5, SKU = "TEA" });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem { Id = 25, OrderId = 9, Quantity = 20, SKU = "SUGAR" });
        }
    }
}
