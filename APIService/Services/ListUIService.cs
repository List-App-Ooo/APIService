using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIService.Services
{
    public class ListUIService : IListUIService
    {
        //TODO: Implement an item service class that handles
        //TODO: calls to any other item service class 
        //TODO: (e.g., ItemService calls NoteService.Get<NoteModel>())
        private IListService _listService;
        private readonly IItemsService _itemsService;

        public ListUIService(IListService listService, IItemsService itemsService)
        {
            this._listService = listService;
            this._itemsService = itemsService;
        }

        public async Task<ListUIModel> Get(Guid id)
        {
            var list = await GetList(id);
            var items = await GetItems(id);
            var uIModel = new ListUIModel() {
                Id = list.Id,
                UserId = list.UserId,
                Title = list.Title,
                TotalItems =  items.ToList().Count,
                Items = items.ToList()
            };

            return uIModel;
        }

        public async Task<ListModel> GetList(Guid id)
        {
            return await _listService.Get(id);
        }

        //TODO: UI should be calling to ItemController to retrieve all items
        //TODO: belonging to a particular list
        public async Task<IEnumerable<ItemModel>> GetItems(Guid listId)
        {
            return await _itemsService.GetAll(listId);
        }
    }
}