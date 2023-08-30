using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.APICallers
{
    public class ChipCaller : IChipCaller
    {
        public bool CheckUID(string uid)
        {
            throw new NotImplementedException();
        }

        public bool ChipExists(string UID)
        {
            throw new NotImplementedException();
        }

        public List<Chip> ChipPagination(int page, int totalItem)
        {
            throw new NotImplementedException();
        }

        public List<Chip> GetAllChips()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllUIDFromEvent(int id)
        {
            throw new NotImplementedException();
        }

        public int GetChipIDByChipUID(string UID)
        {
            throw new NotImplementedException();
        }

        public int GetChipIDByUID(string uid)
        {
            throw new NotImplementedException();
        }

        public List<Group> GroupPagination(int page, int totalItem)
        {
            throw new NotImplementedException();
        }

        public async Task OnScan(Scanning scan)
        {
            throw new NotImplementedException();
        }

        public List<Chip> SearchChip(int page, int totalItem, string search)
        {
            throw new NotImplementedException();
        }

        public List<Group> SearchGroup(int page, int totalItem, string search)
        {
            throw new NotImplementedException();
        }

        public Task ToggleAktiveChip(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
