using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IChipGroupCaller
    {
        Task<List<ChipGroup>> GetChipGroupsAsync();
        Task<bool> ChipGroupExistsAsync(int ChipId, int EventId, int groupNumber);
        Task<int> GetChipGroupIDByChipGroupObjectAsync(int chipId, int eventId, int groupNumber);
        Task<List<ChipGroup>> GetChipGroupsByEventId(int eventId);
        Task CreateChipGroupAsync(CreateChipGroupDTO chipGroup);
        Task UpdateChipGroupAsync(EditChipGroupDTO editChipGroupDTO);
        Task DeleteChipGroupAsync(EditChipGroupDTO editChipGroupDTO);
    }
}
