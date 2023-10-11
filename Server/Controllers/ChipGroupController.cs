using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChipGroupController : ControllerBase
    {
        private readonly IChipGroupRegistrationService _chipGroupRegistrationService;
        private readonly ICRUDService _CRUDService;

        public ChipGroupController(IChipGroupRegistrationService chipGroupRegistrationService, ICRUDService crudService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
            _CRUDService = crudService;
        }

        [HttpGet]
        public IActionResult GetAllChipGroups()
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetAllChipGroups());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("ChipId/{chipid}/EventId/{eventId}/GroupNumber/{Groupnumber}/exists")]
        public async Task<IActionResult> ChipGroupExists(int chipId, int eventId, int groupNumber)
        {
            try
            {
                //var temp =  _chipGroupRegistrationService.GetAllChipGroups().Where(x => x.ChipGroupID == chipId).Where(x => x.EventID == eventId).Where(x => x.GroupNumber == groupNumber).FirstOrDefault();

                return Ok(_chipGroupRegistrationService.ChipGroupExists(chipId, eventId, groupNumber));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("ChipId/{chipid}/EventId/{eventId}/GroupNumber/{groupnumber}")]
        public IActionResult GetChipGroupIDByChipGroupObject(int chipId, int eventId, int groupNumber)
        {
            try
            {
                //var temp = _chipGroupRegistrationService.GetAllChipGroups().Where(x => x.ChipGroupID == chipId).Where(x => x.EventID == eventId).Where(x => x.GroupNumber == groupNumber).FirstOrDefault();
                return Ok(_chipGroupRegistrationService.GetChipGroupIDByChipGroupObject(chipId, eventId, groupNumber));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("CreateChipGroup")]
        public async Task<IActionResult> CreateChipGroup(CreateChipGroupDTO createChipGroupDTO)
        {
            try
            {
                ChipGroup chipGroup1 = new() { ChipID = createChipGroupDTO.ChipId, EventID = createChipGroupDTO.EventId, GroupNumber = createChipGroupDTO.GroupNumber, GroupID = createChipGroupDTO.GroupId };
                await _CRUDService.CreateEntity(chipGroup1);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> DeleteChipGroup(EditChipGroupDTO editChipGroupDTO)
        {
            try
            {
                var editChipgroupDTO1 = _chipGroupRegistrationService.GetAllChipGroups().Where(x => x.ChipGroupID == editChipGroupDTO.ChipGroupId).SingleOrDefault();
                await _CRUDService.DeleteEntity(editChipgroupDTO1);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateChipGroup(EditChipGroupDTO editChipGroupDTO)
        {
            try
            {
                var editChipgroupDTO1 = _chipGroupRegistrationService.GetAllChipGroups().Where(x => x.ChipGroupID == editChipGroupDTO.ChipGroupId).SingleOrDefault();
                editChipgroupDTO1.GroupNumber = editChipGroupDTO.GroupNumber;
                editChipgroupDTO1.GroupID = editChipGroupDTO.GroupId;
                editChipgroupDTO1.ChipID = editChipGroupDTO.ChipId;
                await _CRUDService.UpdateEntity(editChipgroupDTO1);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        
        [HttpGet]
        [Route("ChipGroupEvent/{EventId}")]
        public IActionResult GetChipGroupsByEventId(int eventId)
        {
            try
            {
                List<ChipGroup> chipGroups = _chipGroupRegistrationService.GetAllChipGroupsAndGroupNamesByEventId(eventId);
                List<GroupIdAndGroupNameDTO> chipGroupAndGroupNameDTOs = new List<GroupIdAndGroupNameDTO>();

                foreach (var chipGroup in chipGroups)
                {
                    if (!chipGroupAndGroupNameDTOs.Any(x => x.GroupId == chipGroup.GroupID && x.GroupName == chipGroup.Group.GroupName && x.GroupNumber == chipGroup.GroupNumber)
                        || chipGroupAndGroupNameDTOs.Count == 0)
                    {
                        GroupIdAndGroupNameDTO chipGroupAndGroupNameDTO = new() { GroupId = chipGroup.GroupID, GroupName = chipGroup.Group.GroupName, GroupNumber = chipGroup.GroupNumber };
                        chipGroupAndGroupNameDTOs.Add(chipGroupAndGroupNameDTO);
                    }
                   
                }
                return Ok(chipGroupAndGroupNameDTOs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

    }
}
