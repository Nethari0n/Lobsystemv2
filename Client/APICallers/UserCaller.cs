using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.APICallers
{
    public class UserCaller : IUserCaller
    {
        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public string GetUsernameByID(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> SearchUser(int page, int totalItem, string search)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string username, string name, string oldUsername, string oldName)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string username, string name)
        {
            throw new NotImplementedException();
        }

        public List<User> UserPagination(int page, int totalItem)
        {
            throw new NotImplementedException();
        }
    }
}
