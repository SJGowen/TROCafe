using CafeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeAPI.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private MenuItemContext _context;

        public MenuItemRepository(MenuItemContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> Create(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task Delete(int id)
        {
            var menuItemToDelete = await _context.MenuItems.FindAsync(id);
            _context.MenuItems.Remove(menuItemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MenuItem>> Get()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> Get(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task Update(MenuItem menuItem)
        {
            _context.Entry(menuItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
