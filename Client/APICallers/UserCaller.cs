using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class UserCaller : IUserCaller
    {
        private readonly HttpClient _httpClient;
        public UserCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<User>>("User");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetUsernameByID(string id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<string>($"User/{id}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> SearchUser(int page, int totalItem, string search)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<User>>($"User/{page}/{totalItem}/{search}");
                return response;
             }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UserExists(string username, string name, string oldUsername, string oldName)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"User/{username}/{name}/{oldUsername}/{oldName}/exists");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UserExists(string username, string name)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"User/{username}/{name}/exists");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> UserPagination(int page, int totalItem)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<User>>($"User/{page}/{totalItem}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
