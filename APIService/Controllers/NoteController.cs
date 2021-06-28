using System;
using System.Threading.Tasks;
using APIService.Models;
using APIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            this._noteService = noteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(Guid id)
        {
            var result = await _noteService.Get(id);
            return Ok(result);
        }

        [HttpGet("total/{listId}")]
        public async Task<IActionResult> GetTotal(Guid listId)
        {
            return Ok(await _noteService.GetTotal(listId));
        }

        [HttpGet("list/{listId}")]
        public async Task<IActionResult> GetNotes(Guid listId)
        {
            var result = await _noteService.GetAll(listId);
            return Ok(result);
        }
    }
}