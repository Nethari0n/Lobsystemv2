using Microsoft.AspNetCore.Mvc;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IChipGroupRegistrationService _chipGroupRegistrationService;

        public GroupController(IChipGroupRegistrationService chipGroupRegistrationService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetAllGroups());
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

        //[HttpGet]
        //[Route("{Page}/{totalItem}")]
        //public IActionResult GroupPagination(int page, int totalItem)
        //{
        //    try
        //    {
        //        return Ok(_chipGroupRegistrationService.GroupPagination(page, totalItem));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest);
        //    }
        //}

        //[HttpGet]
        //[Route("{Page}/{totalItem}/{seatch}")]
        //public IActionResult SearchGroup(int page, int totalItem, string search)
        //{
        //    try
        //    {
        //        return Ok(_chipGroupRegistrationService.SearchGroup(page, totalItem, search));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest);
        //    }
        //}
    }
}
