using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Lobsystem.Client.APICallers
{
    public class GroupCaller : IGroupCaller
    {

        private readonly HttpClient _httpClient;

        public GroupCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task CreateGroup(CreateGroupDTO group)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<CreateGroupDTO>("Groups/CreateGroup",group);
                response.EnsureSuccessStatusCode(); ;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task UpdateGroup(ShowGroupDTO group)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<ShowGroupDTO>("Groups/UpdateGroup", group);
                response.EnsureSuccessStatusCode(); ;
            }
            catch (Exception e )
            {
                throw e.InnerException;
            }
        }

        public async Task DeleteGroup(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Groups/DeleteGroup/{id}");
                response.EnsureSuccessStatusCode(); ;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<List<ShowGroupDTO>> GetAllGroups()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ShowGroupDTO>>("Groups");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<bool> GroupExists(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"Groups/{id}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<bool> GroupExists(string navn)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<bool>($"Groups/{navn}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<List<ShowGroupDTO>> GroupPagination(int pages, int totalItem)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ShowGroupDTO>>($"Groups/GroupPage/{pages}/{totalItem}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public async Task<List<ShowGroupDTO>> SearchGroup(int page, int totalItem, string search)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ShowGroupDTO>>($"Groups/GrouppageSearch/{page}/{totalItem}/{search}");
                return response;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        
    }
}
