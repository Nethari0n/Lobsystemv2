using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
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

        bool CheckUID(string uid);

        int GetChipIDByUID(string uid);

        List<ChipDTO> GetAllChipsFromEvent(int id); 

        bool ChipExists(string UID);

        int GetChipIDByChipUID(string UID);
        Chip GetChipByID(int id);

        #endregion

        #region Chip Group


        bool ChipGroupExists(int chipId, int eventId, int groupNumber);

        List<ChipGroup> GetAllChipGroups();


        int GetChipGroupIDByChipGroupObject(int chipId, int eventId, int groupNumber);

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
