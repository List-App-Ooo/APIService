using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public class ListService : IListService
    {
        private readonly IHttpClient _httpClient;
        private readonly IItemsService _itemsService;
        private readonly ServiceConfig _serviceConfig;

        public ListService(IHttpClient httpClient, IItemsService itemsService, ServiceConfig serviceConfig)
        {
            this._httpClient = httpClient;
            this._itemsService = itemsService;
            this._serviceConfig = serviceConfig;
        }

        public async Task<ListModel> Get(Guid id)
        {
            return await _httpClient.Get<ListModel>(_serviceConfig.ListClient, _serviceConfig.ListUrl, id);
        }

        //TODO: should take user id in later iterations
        public async Task<IEnumerable<ListModel>> GetAll(Guid userId)
        {
            var lists = await _httpClient.Get<IEnumerable<ListModel>>(_serviceConfig.ListClient, $"{_serviceConfig.ListUrl}/user", userId);
            
            foreach (var list in lists)
            {
                list.TotalItems = await GetItemTotal(list.Id);
            }

            return lists;        
        }

        public async Task<int> GetItemTotal(Guid id)
        {
            return await _itemsService.GetTotal(id);
        }

    }
}