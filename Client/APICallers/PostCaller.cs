using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
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

        public async Task CreatePost(EditPostDTO post)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Post/CreatePost",post);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void DeletePost(int ID)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Post/{ID}");
                response.EnsureSuccessStatusCode();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Post>> GetAllPostByEventID(int id)
        {
            try
            {
                List<Post> response = await _httpClient.GetFromJsonAsync<List<Post>>($"post/{id}");
                return response.OrderBy(e => e.PostNum).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PostDTO> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<EditEventPostDTO> GetEventPostsForEdit(int id)
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

        public async Task UpdatePost(EditPostDTO post)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Post/UpdatePost", post);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
