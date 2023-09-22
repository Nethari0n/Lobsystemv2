using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IUserCaller
    {
        Task<List<User>> UserPagination(int page, int totalItem);

        Task<List<User>> GetAllUsers();

        Task<List<User>> SearchUser(int page, int totalItem, string search);

        Task<string> GetUsernameByID(string id);

        Task<bool> UserExists(string username, string name, string oldUsername, string oldName);

        Task<bool> UserExists(string username, string name);
    }
}
