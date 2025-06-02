using Lobsystem.Client.IAPICallers;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class CRUDCaller : ICRUDCaller
    {

        private readonly HttpClient _httpClient;

        public CRUDCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateEntity<T>(T entity) where T : class
        {
            await _httpClient.PostAsJsonAsync("GenericCRUD",entity);
        }

        public async Task DeleteEntity<T>(T entity) where T : class
        {
            await _httpClient.DeleteAsync($"GenericCRUD?={entity}");
        
        }

        public async Task UpdateEntity<T>(T entity) where T : class
        {
            await _httpClient.PutAsJsonAsync("GenericCRUD",entity);
        }
    }

}
