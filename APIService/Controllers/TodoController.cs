using System;
using System.Threading.Tasks;
using APIService.Models;
using APIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var result = await _todoService.Get(id);
            return Ok(result);
        }

        [HttpGet("total/{listId}")]
        public async Task<IActionResult> GetTotal(Guid listId)
        {
            return Ok(await _todoService.GetTotal(listId));
        }

        [HttpGet("list/{listId}")]
        public async Task<IActionResult> GetTodos(Guid listId)
        {
            var result = await _todoService.GetAll(listId);
            return Ok(result);
        }
    }
}