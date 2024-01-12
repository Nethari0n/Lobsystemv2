using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Json;

namespace Lobsystem.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrentUser> CurrentUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>("api/auth/currentuserinfo");
            return result;
        }

        public async Task Login(LoginRequest loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/auth/logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterRequest registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task CreateRole(string roleName)
        {
            try
            {
                IdentityRole identityRole = new() {  Name = roleName, ConcurrencyStamp = Guid.NewGuid().ToString() };
                var response = await _httpClient.PostAsJsonAsync<IdentityRole>("api/auth/createrole", identityRole);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception(await response.Content.ReadAsStringAsync());
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<List<IdentityRole>> GetRoles()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<IdentityRole>>("api/auth/getroles");

                return response;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<List<IdentityRole>> RolePagination(int pages, int totalPages)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<IdentityRole>>($"api/auth/rolepagination/{pages}/{totalPages}");
                return response;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

    }
}
