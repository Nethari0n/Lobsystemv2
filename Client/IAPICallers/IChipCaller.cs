using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IChipCaller
    {
        Task OnScan(Scanning scan);

        List<Chip> GetAllChips();

        List<Group> GroupPagination(int page, int totalItem);

        List<Group> SearchGroup(int page, int totalItem, string search);

        List<Chip> ChipPagination(int page, int totalItem);

        List<Chip> SearchChip(int page, int totalItem, string search);

        Task ToggleAktiveChip(int ID);

        bool CheckUID(string uid);

        int GetChipIDByUID(string uid);

        Task<List<string>> GetAllUIDFromEvent(int id);

        bool ChipExists(string UID);

        int GetChipIDByChipUID(string UID);
    }
}
