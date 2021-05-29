using CafeAPI.Models;
using CafeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemsController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItem>> GetOrderItems()
        {
            return await _orderItemRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            return await _orderItemRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem([FromBody] OrderItem orderItem)
        {
            var newOrderItem = await _orderItemRepository.Create(orderItem);
            return CreatedAtAction(nameof(GetOrderItems), new { id = newOrderItem.Id }, newOrderItem);
        }

        [HttpPut]
        public async Task<ActionResult> PutOrderItem(int id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id) return BadRequest();

            await _orderItemRepository.Update(orderItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var orderItemToDelete = await _orderItemRepository.Get(id);

            if (orderItemToDelete == null) return NotFound();

            await _orderItemRepository.Delete(orderItemToDelete.Id);
            return NoContent();
        }
    }
}
