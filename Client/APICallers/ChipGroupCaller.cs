using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class ChipGroupCaller : IChipGroupCaller
    {
        private readonly HttpClient _httpClient;
        public ChipGroupCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ChipGroupExistsAsync(ChipGroup chipGroup)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<bool>($"ChipGroup/{chipGroup}/exists");
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task<int> GetChipGroupIDByChipGroupObjectAsync(ChipGroup chipGroup)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<int>($"ChipGroup/{chipGroup}");
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task<List<ChipGroup>> GetChipGroupsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ChipGroup>>("ChipGroup");
                
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task CreateChipGroupAsync(ChipGroup chipGroup)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("ChipGroup", chipGroup);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task UpdateChipGroupAsync(ChipGroup chipGroup)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("ChipGroup", chipGroup);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async Task DeleteChipGroupAsync(ChipGroup chipGroup)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("ChipGroup/Remove", chipGroup);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
    }
}
