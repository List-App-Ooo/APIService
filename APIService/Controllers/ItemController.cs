using System;
using System.Threading.Tasks;
using APIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsService _itemsService;

        public ItemController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            return Ok(await _itemsService.Get(id));
        }

        [HttpGet("list/{listId}")]
        public async Task<IActionResult> GetItems(Guid listId)
        {
            return Ok(await _itemsService.GetAll(listId));
        }

        [HttpGet("total/{listId}")]
        public async Task<IActionResult> GetItemTotal(Guid listId)
        {
            return Ok(await _itemsService.GetTotal(listId));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            _itemsService.DeleteItem(id);
            return NoContent();
        }
    }
}