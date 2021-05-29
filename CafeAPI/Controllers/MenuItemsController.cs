using CafeAPI.Models;
using CafeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private IMenuItemRepository _menuItemRepository;

        public MenuItemsController(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            return await _menuItemRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            return await _menuItemRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem([FromBody] MenuItem menuItem)
        {
            var newMenuItem = await _menuItemRepository.Create(menuItem);
            return CreatedAtAction(nameof(GetMenuItems), new { id = newMenuItem.Id }, newMenuItem);
        }

        [HttpPut]
        public async Task<ActionResult> PutMenuItem(int id, [FromBody] MenuItem menuItem)
        {
            if (id != menuItem.Id) return BadRequest();

            await _menuItemRepository.Update(menuItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var menuItemToDelete = await _menuItemRepository.Get(id);

            if (menuItemToDelete == null) return NotFound();

            await _menuItemRepository.Delete(menuItemToDelete.Id);
            return NoContent();
        }
    }
}
