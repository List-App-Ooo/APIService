using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public class TodoService : ITodoService
    {
        private readonly IHttpClient _httpClient;
        private readonly ServiceConfig _serviceConfig;

        public TodoService(IHttpClient httpClient, ServiceConfig serviceConfig)
        {
            this._httpClient = httpClient;
            this._serviceConfig = serviceConfig;
        }

        public async Task<TodoModel> Get(Guid id)
        {
            return await _httpClient.Get<TodoModel>(_serviceConfig.TodoClient, _serviceConfig.TodoUrl, id);
        }

        public async Task<IEnumerable<TodoModel>> GetAll(Guid listId)
        {
            return await _httpClient.Get<IEnumerable<TodoModel>>(_serviceConfig.TodoClient, $"{_serviceConfig.TodoUrl}/list", listId);
        }

        public async Task<int> GetTotal(Guid listId)
        {
            return await _httpClient.Get<int>(_serviceConfig.TodoClient, $"{_serviceConfig.TodoUrl}/total", listId);
        }
        
        public void DeleteTodo(Guid id)
        {
            _httpClient.Delete<TodoModel>(_serviceConfig.TodoClient, _serviceConfig.TodoUrl, id);
        }
    }
}