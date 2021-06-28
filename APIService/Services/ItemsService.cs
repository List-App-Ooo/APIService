using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public class ItemsService : IItemsService
    {
        private readonly INoteService _noteService;
        private readonly ITodoService _todoService;

        public ItemsService(ITodoService todoService, INoteService noteService)
        {
            this._noteService = noteService;
            this._todoService = todoService;
        }

        public async Task<ItemModel> Get(Guid id)
        {
            ItemModel note = await _noteService.Get(id);
            ItemModel todo = await _todoService.Get(id);

            return note is not null ? note : todo;
        }
        public async Task<IEnumerable<ItemModel>> GetAll(Guid listId)
        {
            IEnumerable<ItemModel> notes = await _noteService.GetAll(listId);
            IEnumerable<ItemModel> todos = await _todoService.GetAll(listId);

            return notes.ToList().Count > 0 ? notes : todos;
        }
        public async Task<int> GetTotal(Guid listId)
        {
            IEnumerable<ItemModel> notes = await _noteService.GetAll(listId);
            IEnumerable<ItemModel> todos = await _todoService.GetAll(listId);

            var noteCount = notes.ToList().Count;
            var todoCount = todos.ToList().Count;
            
            return noteCount > 0 ? noteCount : todoCount;
        }
        public async void DeleteItem(Guid id)
        {
            ItemModel note = await _noteService.Get(id);
            ItemModel todo = await _todoService.Get(id);
            
            if (note is not null)
            {
                _noteService.DeleteNote(id);
            } else 
            {
                _todoService.DeleteTodo(id);
            }
        }
    }
}