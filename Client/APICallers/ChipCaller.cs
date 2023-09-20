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
        public bool CheckUID(string uid)
        {
            throw new NotImplementedException();
        }

        public bool ChipExists(string UID)
        {
            throw new NotImplementedException();
        }

        public List<Chip> ChipPagination(int page, int totalItem)
        {
            throw new NotImplementedException();
        }

        public List<Chip> GetAllChips()
        {
            throw new NotImplementedException();
        }

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

        public int GetChipIDByChipUID(string UID)
        {
            throw new NotImplementedException();
        }

        public int GetChipIDByUID(string uid)
        {
            throw new NotImplementedException();
        }



        public async Task OnScan(Scanning scan)
        {
            throw new NotImplementedException();
        }

        public List<Chip> SearchChip(int page, int totalItem, string search)
        {
            throw new NotImplementedException();
        }


        public Task ToggleAktiveChip(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
