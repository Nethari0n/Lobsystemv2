using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Lobsystem.Client.Services
{
    public interface IAuthService
    {
        Task Login(LoginRequest loginRequest);
        Task Register(RegisterRequest registerRequest);
        Task Logout();
        Task<CurrentUser> CurrentUserInfo();
        Task CreateRole(string roleName);
        Task<List<IdentityRole>> GetRoles();
        Task<List<IdentityRole>> RolePagination(int pages, int totalPages);
    }
}
