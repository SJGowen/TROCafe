using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeAPI.Repositories
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> Get();
        Task<MenuItem> Get(int id);
        Task<MenuItem> Create(MenuItem menuItem);
        Task Update(MenuItem menuItem);
        Task Delete(int id);
    }
}
