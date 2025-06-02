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
        public async Task<bool> ChipGroupExistsAsync(int chipId, int eventId, int groupNumber)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<bool>($"ChipGroup/ChipId/{chipId}/EventId/{eventId}/GroupNumber/{groupNumber}/exists");
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task<int> GetChipGroupIDByChipGroupObjectAsync(int chipId, int eventId, int groupNumber)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<int>($"ChipGroup/ChipId/{chipId}/EventId/{eventId}/GroupNumber/{groupNumber}");
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

        public async Task CreateChipGroupAsync(CreateChipGroupDTO chipGroup)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("ChipGroup/CreateChipGroup", chipGroup);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task UpdateChipGroupAsync(EditChipGroupDTO editChipGroupDTO)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("ChipGroup", editChipGroupDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async Task DeleteChipGroupAsync(EditChipGroupDTO editChipGroupDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("ChipGroup/Remove", editChipGroupDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async Task<List<GroupIdAndGroupNameDTO>> GetChipGroupsByEventId(int eventId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<GroupIdAndGroupNameDTO>>($"ChipGroup/ChipGroupEvent/{eventId}");
                return response;
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }
    }
}
