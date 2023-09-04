using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class PostCaller : IPostCaller
    {
        private readonly HttpClient _httpClient;
        public PostCaller(HttpClient httpClient)
        {
                _httpClient = httpClient;
        }
        public void AddPostFromList(List<Post> list, int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetAllPostByEventID(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Post>>($"post/{id}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public void SortDeletedPosts(List<Post> list)
        {
            throw new NotImplementedException();
        }

        public void SortPosts(List<Post> list, int id)
        {
            throw new NotImplementedException();
        }

        public bool TypeExists(int ID)
        {
            throw new NotImplementedException();
        }

        public bool TypeExists(string TypeName)
        {
            throw new NotImplementedException();
        }
    }
}
