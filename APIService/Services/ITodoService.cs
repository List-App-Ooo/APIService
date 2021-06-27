using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public interface ITodoService
    {
        Task<TodoModel> Get(Guid id);
        Task<IEnumerable<TodoModel>> GetAll(Guid listId);
        Task<int> GetTotal(Guid listId);
        void DeleteTodo(Guid id);
    }
}