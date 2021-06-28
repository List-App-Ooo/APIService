using System;
using System.Threading.Tasks;
using APIService.Models;
using APIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        private readonly IListUIService _listUIService;
        private readonly IListService _listService;

        public ListController(IListUIService listUIService, IListService listService)
        {
            this._listUIService = listUIService;
            this._listService = listService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetList(Guid id)
        {
            return Ok(await _listUIService.Get(id));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetLists(Guid userId)
        {
            return Ok(await _listService.GetAll(userId));
        }
    }
}
