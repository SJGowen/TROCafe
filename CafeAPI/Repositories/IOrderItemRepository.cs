using CafeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeAPI.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> Get();
        Task<OrderItem> Get(int id);
        Task<OrderItem> Create(OrderItem orderItem);
        Task Update(OrderItem orderItem);
        Task Delete(int id);

    }
}
