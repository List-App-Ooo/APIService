using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public interface IListUIService
    {
        public Task<ListUIModel> Get(Guid id);
        public Task<ListModel> GetList(Guid id);
        public Task<IEnumerable<ItemModel>> GetItems(Guid listId);
    }
}