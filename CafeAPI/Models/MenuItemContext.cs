using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
