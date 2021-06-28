using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.Services
{
    public class NoteService: INoteService
    {
        private readonly IHttpClient _httpClient;
        private readonly ServiceConfig _serviceConfig;

        public NoteService(IHttpClient httpClient, ServiceConfig serviceConfig)
        {
            this._httpClient = httpClient;
            this._serviceConfig = serviceConfig;
        }

        public async Task<NoteModel> Get(Guid id)
        {
            return await _httpClient.Get<NoteModel>(_serviceConfig.NoteClient, _serviceConfig.NoteUrl, id);
        }

        public async Task<IEnumerable<NoteModel>> GetAll(Guid listId)
        {
            return await _httpClient.Get<IEnumerable<NoteModel>>(_serviceConfig.NoteClient, $"{_serviceConfig.NoteUrl}/list", listId);
        }

        public async Task<int> GetTotal(Guid listId)
        {
            return await _httpClient.Get<int>(_serviceConfig.NoteClient, $"{_serviceConfig.NoteUrl}/total", listId);
        }
        
        public void DeleteNote(Guid id)
        {
            _httpClient.Delete<TodoModel>(_serviceConfig.NoteClient, $"{_serviceConfig.NoteUrl}", id);
        }
    }
}