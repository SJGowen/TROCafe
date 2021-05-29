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
    }
}
