using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public interface IItemsService
    {
        Task<ItemModel> Get(Guid id);
        Task<IEnumerable<ItemModel>> GetAll(Guid listId);
        void DeleteItem(Guid id);
        Task<int> GetTotal(Guid listId);
    }
}