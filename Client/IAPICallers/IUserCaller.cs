using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Lobsystem.Client.IAPICallers
{
    public interface IUserCaller
    {
        Task<List<User>> UserPagination(int page, int totalItem);

        Task<List<User>> GetAllUsers();

        Task<List<User>> SearchUser(int page, int totalItem, string search);

        Task<string> GetUsernameByID(string id);
        Task UpdateUser(RegisterRequest registerRequest);
        Task DeleteUser(string id);

        Task<bool> UserExists(string username, string name, string oldUsername, string oldName);

        Task<List<string>> GetRoles();
  


        Task<bool> UserExists(string username, string name);


    }
}
