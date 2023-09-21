using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
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
        public async Task DeleteType(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Types/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<List<Types>> GetAllTypes()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Types>>("Types");
                
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<bool> GetMultiRound(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"Types/{id}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
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
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public Task<List<Types>> TypesPagination(int page, int totalItem)
        {
            try
            {
                var response = _httpClient.GetFromJsonAsync<List<Types>>($"Types/{page}/{totalItem}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<bool> TypeExists(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"Types/Exists/{id}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<bool> TypeExists(string TypeName)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"Types/ExistsName/{TypeName}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
            
        }

        public async Task CreatTypes(CreateTypeDTO types)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Types/CreateType",types);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task UpdateTypes(EditTypeDTO types)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Types/UpdateType", types);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
    }
}
