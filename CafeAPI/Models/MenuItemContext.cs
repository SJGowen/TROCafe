using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Models
{
    public class MenuItemContext : DbContext
    {
        public MenuItemContext(DbContextOptions<MenuItemContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
