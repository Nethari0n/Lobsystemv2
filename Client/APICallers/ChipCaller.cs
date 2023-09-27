using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class ChipCaller : IChipCaller
    {
        private readonly HttpClient _httpClient;
        public ChipCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ChipExists(string UID) => await _httpClient.GetFromJsonAsync<bool>($"Chip/{UID}/exists");

        public async Task<List<Chip>> ChipPagination(int page, int totalItem) => await _httpClient.GetFromJsonAsync<List<Chip>>($"Chip/{page}/{totalItem}");

        public async Task<List<Chip>> GetAllChips() => await _httpClient.GetFromJsonAsync<List<Chip>>("Chip");

        public async Task<List<Chip>> GetAllChipsSearch(string search) => await _httpClient.GetFromJsonAsync<List<Chip>>($"Chip/{search}/Search");

        public async Task<List<ChipDTO>> GetAllChipsFromEvent(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ChipDTO>>($"Chip/{id}/Event");

                return response.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> GetChipIDByChipUID(string UID) => await _httpClient.GetFromJsonAsync<int>($"Chip/{UID}/chipuid");

        public async Task<int> GetChipIDByUID(string UID) => await _httpClient.GetFromJsonAsync<int>($"Chip/{UID}/uid");

        public async Task<List<Chip>> SearchChip(int page, int totalItem, string search)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Chip>>($"Chip/{page}/{totalItem}/{search}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ToggleActiveChip(int ID)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"Chip/ToggleActive", ID);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async Task CreateChip(ChipHandlingDTO chip)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"Chip/Create", chip);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task CreateChips(List<ChipHandlingDTO> chips)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Chip/CreateList", chips);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task UpdateChip(ChipHandlingDTO chip)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("Chip", chip);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }
    }
}
