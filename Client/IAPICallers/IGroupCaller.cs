using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IGroupCaller
    {
        Task CreateGroup(CreateGroupDTO group);
        Task UpdateGroup(ShowGroupDTO group);
        Task DeleteGroup(int id);
        Task<List<ShowGroupDTO>> GetAllGroups();
        Task<bool> GroupExists(int id);
        Task<bool> GroupExists(string navn);
        Task<List<ShowGroupDTO>> GroupPagination(int page, int totalItem);
        Task<List<ShowGroupDTO>> SearchGroup(int page, int totalItem, string search);
    }
}
