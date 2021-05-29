﻿using CafeAPI.Models;
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
    }
}
