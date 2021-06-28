using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public interface IListService
    {
        Task<ListModel> Get(Guid id);
        Task<IEnumerable<ListModel>> GetAll(Guid userId);
        Task<int> GetItemTotal(Guid id);
    }
}