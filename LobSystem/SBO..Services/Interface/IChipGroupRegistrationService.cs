using SBO.LobSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Interface
{
    public interface IChipGroupRegistrationService
    {

        #region Chip


        List<Chip> GetAllChips();

        List<Group> GroupPagination(int page, int totalItem);

        List<Group> SearchGroup(int page, int totalItem, string search);

        List<Chip> ChipPagination(int page, int totalItem);

        List<Chip> SearchChip(int page, int totalItem, string search);

        Task ToggleAktiveChip(int ID);

        bool CheckUID(string uid);

        int GetChipIDByUID(string uid);

        List<string> GetAllUIDFromEvent(int id); 

        bool ChipExists(string UID);

        int GetChipIDByChipUID(string UID);

        #endregion

        #region Chip Group


        bool ChipGroupExists(ChipGroup chipGroupDTO);

        List<ChipGroup> GetAllChipGroups();


        int GetChipGroupIDByChipGroupObject(ChipGroup chipGroups);

        void RemoveChipGroup(ChipGroup chipGroupDTO);

        #endregion

        #region Group

        List<Group> GetAllGroups();


        bool GroupExists(int id);
        bool GroupExists(string navn);

        #endregion

        #region Registration


        List<Registration> GetAllRegistrations();

        Task<Registration> GetRegistrationById(int id);

        Registration GetRegistrationByChipAndEventId(int id, int eventId);

        #endregion
    }
}
