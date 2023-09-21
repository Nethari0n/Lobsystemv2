using Microsoft.AspNetCore.Mvc;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.Interface;
using Lobsystem.Shared.DTO;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IChipGroupRegistrationService _chipGroupRegistrationService;
        private readonly ICRUDService _crudService;

        public GroupsController(IChipGroupRegistrationService chipGroupRegistrationService, ICRUDService CRUDService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
            _crudService = CRUDService;
        }


        [HttpPost]
        [Route("CreateGroup")]
        public IActionResult CreateGroup(CreateGroupDTO createGroupDTO)
        {
            try
            {
                Group group = new() { GroupName = createGroupDTO.GroupName, IsDeleted = false };
                _crudService.CreateEntity(group);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest); throw;
            }
        }

        [HttpPost]
        [Route("UpdateGroup")]
        public IActionResult EditGroup(ShowGroupDTO showGroupDTO)
        {
            try
            {
                Group group = _chipGroupRegistrationService.GetAllGroups().Where(x => x.GroupID == showGroupDTO.GroupId).SingleOrDefault();
                group.GroupName = showGroupDTO.GroupName;
                group.IsDeleted = showGroupDTO.IsDeleted;
                _crudService.UpdateEntity(group);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest); throw;
            }
        }

        [HttpDelete]
        [Route("DeleteGroup/{id}")]
        public IActionResult DeleteGroup(int id)
        {
            try
            {
                Group group = _chipGroupRegistrationService.GetAllGroups().Where(x => x.GroupID == id).FirstOrDefault();
                _crudService.DeleteEntity(group);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest); throw;
            }
        }
        [HttpGet]
        public IActionResult GetAllGroups()
        {
            try
            {
                List<Group> groups = _chipGroupRegistrationService.GetAllGroups();

                List<ShowGroupDTO> showGroupDTOs = new List<ShowGroupDTO>();

                foreach (Group group in groups)
                {
                    ShowGroupDTO showGroupDTO = new ShowGroupDTO()
                    {
                        GroupName = group.GroupName,
                        GroupId = group.GroupID,
                        IsDeleted = group.IsDeleted,
                    };
                    showGroupDTOs.Add(showGroupDTO);
                }
                return Ok(showGroupDTOs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GroupExists(string name)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GroupExists(name));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("GroupPage/{Pages}/{totalItem}")] //for some reason i get status code 500 on all API calls if specifically this Route has "page" and not "pages"
        public IActionResult GroupPagination(int Pages, int totalItem)
        {
            try
            {
                List<Group> groups = _chipGroupRegistrationService.GroupPagination(Pages, totalItem);

                List<ShowGroupDTO> showGroupDTOs = new List<ShowGroupDTO>();

                foreach (Group group in groups)
                {
                    ShowGroupDTO showGroupDTO = new ShowGroupDTO()
                    {
                        GroupName = group.GroupName,
                        GroupId = group.GroupID,
                        IsDeleted = group.IsDeleted,
                    };
                    showGroupDTOs.Add(showGroupDTO);
                }
                return Ok(showGroupDTOs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("GrouppageSearch/{Pages}/{totalItem}/{search}")] //for some reason i get status code 500 on all API calls if specifically this Route has "page" and not "pages"
        public IActionResult SearchGroup(int Pages, int totalItem, string search)
        {
            try
            {
                List<Group> groups = _chipGroupRegistrationService.SearchGroup(Pages, totalItem, search);

                List<ShowGroupDTO> showGroupDTOs = new List<ShowGroupDTO>();

                foreach (Group group in groups)
                {
                    ShowGroupDTO showGroupDTO = new ShowGroupDTO()
                    {
                        GroupName = group.GroupName,
                        GroupId = group.GroupID,
                        IsDeleted = group.IsDeleted,
                    };
                    showGroupDTOs.Add(showGroupDTO);
                }
                return Ok(showGroupDTOs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
