using CafeAPI.Data;
using CafeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeAPI.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OrderItemContext _context;

        public OrderItemRepository(OrderItemContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task Delete(int id)
        {
            var orderItemToDelete = await _context.OrderItems.FindAsync(id);
            _context.OrderItems.Remove(orderItemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> Get()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> Get(int id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task Update(OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
