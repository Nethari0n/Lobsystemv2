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

        public List<Types> GetAllTypes()
        {
            throw new NotImplementedException();
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

        public List<Types> SearchType(int page, int totalItem, string search)
        {
            throw new NotImplementedException();
        }

        public List<Types> TypesPagination(int page, int totalItem)
        {
            throw new NotImplementedException();
        }
    }
}
