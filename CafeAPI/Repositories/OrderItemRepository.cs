using CafeAPI.Data;
using CafeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeAPI.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private OrderItemContext _context;

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

        public async Task<IEnumerable<OrderItem>> GetOrder(int orderId)
        {
            return await _context.Set<OrderItem>().Where(o => o.OrderId == orderId).ToListAsync();
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

        public async Task<decimal> GetTotal(int orderId)
        {
            var orderItems = await _context.Set<OrderItem>().Where(o => o.OrderId == orderId).ToListAsync();
            var total = 0.0M;
            var discount = 0.0M;
            foreach (var item in orderItems)
            {
                if (item.SKU.StartsWith("DISC"))
                {
                    if (item.SKU.EndsWith("10")) discount += 0.1M * item.Quantity;
                    if (item.SKU.EndsWith("20")) discount += 0.2M * item.Quantity;
                }
                else total += item.Quantity * item.Cost;
            }
            if (discount > 1.0M) discount = 1.0M; // ensure that we never pay the customer for drinking
            return total - (total * discount);
        }
    }
}
