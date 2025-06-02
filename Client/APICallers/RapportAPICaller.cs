using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class RapportAPICaller : IRapportAPICaller
    {
        private readonly HttpClient _httpClient;
        public RapportAPICaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<LiveRapport>> GetLiveRapport(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<LiveRapport>>($"Rapport/{id}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EndRapport>> GetRapports(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<EndRapport>>($"Rapport/{id}/endrapport");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
