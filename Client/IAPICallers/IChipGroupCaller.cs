using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IChipGroupCaller
    {
        Task<List<ChipGroup>> GetChipGroupsAsync();
        Task<bool> ChipGroupExistsAsync(ChipGroup chipGroup);
        Task<int> GetChipGroupIDByChipGroupObjectAsync(ChipGroup chipGroup);
        Task CreateChipGroupAsync(ChipGroup chipGroup);
        Task UpdateChipGroupAsync(ChipGroup chipGroup);
        Task DeleteChipGroupAsync(ChipGroup chipGroup);
    }
}
