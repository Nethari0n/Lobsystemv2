using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class RegistrationCaller : IRegistrationCaller
    {
        private readonly HttpClient _httpClient;

        public RegistrationCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Registration>> GetAllRegistrationsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Registration>>("Registration");
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task<Registration> GetRegistrationByChipAndEventIdAsync(int id, int eventId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Registration>($"Registration/chipid/{id}/eventid/{eventId}");
                return response;
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task CreateRegistrationAsync(RegistrationDTO registration)
        {
            try
            {
               var response = await _httpClient.PostAsJsonAsync("Registration", registration);
               response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }

        public async Task UpdateRegistrationAsync(RegistrationDTO registration)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("Registration", registration);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async Task DeleteRegistrationAsync(int id, int eventId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Registration/ChipId/{id}/EventId/{eventId}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
