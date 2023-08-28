using Microsoft.EntityFrameworkCore;
using Lobsystem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBO.LobSystem.Services.ExtensionMethods;
using System.Threading.Tasks;
using SBO.LobSystem.Services.Interface;
using SBO.Lobsystem.Domain.Data;

namespace SBO.LobSystem.Services.Services
{
    public class ChipGroupRegistrationService : IChipGroupRegistrationService
    {

        private readonly ApplicationDBContext _lobsContext;

        private readonly ICreateService _create;

        public ChipGroupRegistrationService(ApplicationDBContext lobsContext, ICreateService create)
        {
            _lobsContext = lobsContext;
            _create = create;
        }

        #region Chip

        public List<Chip> GetAllChips() => _lobsContext.Chips.AsNoTracking().ToList();

        public List<Chip> ChipPagination(int page, int totalItem) => _lobsContext.Chips.Paging(page, totalItem).AsNoTracking().ToList();

        public List<Chip> SearchChip(int page, int totalItem, string search) => _lobsContext.Chips
            .Where(x => x.UID.Contains(search) || x.LaanerID.Contains(search))
            .Paging(page, totalItem).AsNoTracking().ToList();


        public int GetChipIDByUID(string uid)
        {
            try { return _lobsContext.Chips.Where(x => x.UID == uid).AsNoTracking().FirstOrDefault().ChipID; } catch { return 0; }
        }

        public List<string> GetAllUIDFromEvent(int id)
        {
            List<string> list = new List<string>();

            foreach ( var item in _lobsContext.Registrations.Where(x => x.EventID == id).Include(x => x.Chip).AsNoTracking() )
            {
                list.Add(item.Chip.UID);
            }

            return list;
        }

        public async Task ToggleAktiveChip(int ID)
        {
            Chip chip = _lobsContext.Chips.Where(c => c.ChipID == ID).AsNoTracking().FirstOrDefault();

            if ( chip.Aktive == true )
            {
                chip.Aktive = false;
            }
            else
            {
                chip.Aktive = true;
            }


            await _create.UpdateEntity(chip);
        }

        public bool ChipExists(string UID)
        {
            bool exists = false;

            Chip chip = _lobsContext.Chips.Where(c => c.UID == UID).AsNoTracking().FirstOrDefault();

            if ( chip != null )
            {
                exists = true;
            }
            return exists;
        }

        public int GetChipIDByChipUID(string UID) => _lobsContext.Chips?.Where(c => c.UID == UID).AsNoTracking().FirstOrDefault()?.ChipID ?? 0;

        #endregion

        #region Chip Group



        public int GetChipGroupIDByChipGroupObject(ChipGroup chipGroups) { return _lobsContext.ChipGroups.Where(c => c.ChipID == chipGroups.ChipID).Where(c => c.EventID == chipGroups.EventID).Where(c => c.GroupNumber == chipGroups.GroupNumber).AsNoTracking().FirstOrDefault().ChipGroupID; }

        public List<ChipGroup> GetAllChipGroups() => _lobsContext.ChipGroups.ToList();
        public bool ChipGroupExists(ChipGroup chipGroup)
        {
            bool exists = false;
            ChipGroup chipGroupObj = _lobsContext.ChipGroups.Where(c => c.ChipID == chipGroup.ChipID).Where(c => c.EventID == chipGroup.EventID).Where(c => c.GroupNumber == chipGroup.GroupNumber).AsNoTracking().FirstOrDefault();

            if ( chipGroupObj != null )
            {
                exists = true;
            }

            return exists;
        }
        public bool CheckUID(string uid)
        {
            return _lobsContext.Chips.Any(x => x.UID == uid) ? true : false;
        }

        public void RemoveChipGroup(ChipGroup chipGroupDTO)
        {
            ChipGroup chipGroup = _lobsContext.ChipGroups.Where(c => c.ChipID == chipGroupDTO.ChipID).Where(c => c.EventID == chipGroupDTO.EventID).Where(c => c.GroupNumber == chipGroupDTO.GroupNumber).AsNoTracking().FirstOrDefault();

            _lobsContext.ChipGroups.Remove(chipGroup);
            _lobsContext.SaveChanges();
        }

        #endregion

        #region Group



        public List<Group> GetAllGroups() => _lobsContext.Groups.Where(e => e.IsDeleted == false).AsNoTracking().ToList();

        public List<Group> GroupPagination(int page, int totalItem) => _lobsContext.Groups
            .Where(x => x.IsDeleted == false)
            .Paging(page, totalItem).AsNoTracking().ToList();

        public List<Group> SearchGroup(int page, int totalItem, string search) => _lobsContext.Groups
            .Where(x => x.GroupName.Contains(search) || x.GroupID.ToString().Contains(search) && x.IsDeleted == false)
            .Paging(page, totalItem).AsNoTracking().ToList();

        //Check if group exists with name
        public bool GroupExists(string navn)
        {
            return _lobsContext.Groups.Any(x => x.GroupName == navn) ? true : false;
        }

        //Check if group exists with id
        public bool GroupExists(int id)
        {
            return _lobsContext.Groups.Any(x => x.GroupID == id) ? true : false;
        }

        #endregion

        #region Registration


        public List<Registration> GetAllRegistrations() => _lobsContext.Registrations.AsNoTracking().ToList();

        public Registration GetRegistrationByChipAndEventId(int id, int eventId)
        {
            
                return _lobsContext.Registrations.Where(c => c.ChipID == id).Where(c => c.EventID == eventId).AsNoTracking().FirstOrDefault();
            
        }
        public async Task<Registration> GetRegistrationById(int id)
        {
                return await _lobsContext.Registrations.Where(x => x.RegistrationID == id).AsNoTracking().FirstOrDefaultAsync();
            
        }



        #endregion
    }
}





