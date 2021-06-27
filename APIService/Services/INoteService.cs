using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public interface INoteService
    {
        Task<NoteModel> Get(Guid id);
        Task<IEnumerable<NoteModel>> GetAll(Guid listId);
        Task<int> GetTotal(Guid listId);
        void DeleteNote(Guid id);
    }
}