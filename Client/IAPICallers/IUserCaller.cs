using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IUserCaller
    {
        List<User> UserPagination(int page, int totalItem);

        List<User> GetAllUsers();

        List<User> SearchUser(int page, int totalItem, string search);

        string GetUsernameByID(string id);

        bool UserExists(string username, string name, string oldUsername, string oldName);

        bool UserExists(string username, string name);
    }
}
