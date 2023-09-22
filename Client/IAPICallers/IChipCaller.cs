using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IChipCaller
    {
        //Task OnScan(Scanning scan);

        Task<List<Chip>> GetAllChips();
        Task<List<Chip>> GetAllChipsSearch(string search);

        Task<List<Chip>> ChipPagination(int page, int totalItem);

        Task<List<Chip>> SearchChip(int page, int totalItem, string search);

        Task ToggleActiveChip(int ID);

        Task<int> GetChipIDByUID(string uid);

        Task<List<ChipDTO>> GetAllChipsFromEvent(int id);

        Task<bool> ChipExists(string UID);

        Task<int> GetChipIDByChipUID(string UID);

        Task CreateChip(ChipHandlingDTO chip);
        Task CreateChips(List<ChipHandlingDTO> chips);
    }
}
