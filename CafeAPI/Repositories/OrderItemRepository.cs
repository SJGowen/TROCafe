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
        private readonly OrderItemContext _orderContext;
        private readonly MenuItemContext _menuContext;

        public OrderItemRepository(OrderItemContext orderItemContext, MenuItemContext menuItemContext)
        {
            _orderContext = orderItemContext;
            _menuContext = menuItemContext;
        }

        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            _orderContext.OrderItems.Add(orderItem);
            await _orderContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task Delete(int id)
        {
            var orderItemToDelete = await _orderContext.OrderItems.FindAsync(id);
            _orderContext.OrderItems.Remove(orderItemToDelete);
            await _orderContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> Get()
        {
            return await _orderContext.OrderItems.ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetOrder(int orderId)
        {
            return await _orderContext.Set<OrderItem>().Where(o => o.OrderId == orderId).ToListAsync();
        }

        public async Task<OrderItem> Get(int id)
        {
            return await _orderContext.OrderItems.FindAsync(id);
        }

        public async Task Update(OrderItem orderItem)
        {
            _orderContext.Entry(orderItem).State = EntityState.Modified;
            await _orderContext.SaveChangesAsync();
        }

        public async Task<decimal> GetTotal(int orderId)
        {
            var orderItems = await _orderContext.Set<OrderItem>().Where(o => o.OrderId == orderId).ToListAsync();
            var total = 0.0M;
            var discount = 0.0M;
            foreach (var item in orderItems)
            {
                if (item.SKU.StartsWith("DISC"))
                {
                    var disc = int.Parse(item.SKU[4..]);
                    discount += item.Quantity * (disc / 100.0M);
                }
                else
                {
                    var menuItem = await _menuContext.Set<MenuItem>().Where(m => m.SKU == item.SKU).FirstAsync();
                    total += item.Quantity * menuItem.Cost;
                }
            }
            if (discount > 1.0M) discount = 1.0M; // ensure that we never pay the customer
            return total - (total * discount);
        }
    }
}
