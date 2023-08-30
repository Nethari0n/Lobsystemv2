using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.APICallers
{
    public class PostCaller : IPostCaller
    {
        public void AddPostFromList(List<Post> list, int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPostByEventID(int id)
        {
            throw new NotImplementedException();
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
