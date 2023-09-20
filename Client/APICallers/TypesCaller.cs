using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class TypesCaller : ITypesCaller
    {
        private readonly HttpClient _httpClient;
        public TypesCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void DeleteType(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Types>> GetAllTypes()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Types>>("Types");
                
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> GetMultiRound(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"Types/{id}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Types GetTypeByID(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTypeNameByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Types>> SearchType(int page, int totalItem, string search)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Types>>($"Types/{page}/{totalItem}/{search}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Types>> TypesPagination(int page, int totalItem)
        {
            try
            {
                var response = _httpClient.GetFromJsonAsync<List<Types>>($"Types/{page}/{totalItem}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> TypeExists(int ID)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"Types/{ID}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> TypeExists(string TypeName)
        {
            throw new NotImplementedException();
        }
    }
}
