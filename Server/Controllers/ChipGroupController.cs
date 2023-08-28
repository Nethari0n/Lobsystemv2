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

        public ChipGroupController(IChipGroupRegistrationService chipGroupRegistrationService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
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
        [Route("{chipGroupDTO}/exists")]
        public IActionResult ChipGroupExists(ChipGroup chipGroupDTO)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.ChipGroupExists(chipGroupDTO));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{chipGroups}")]
        public IActionResult GetChipGroupIDByChipGroupObject(ChipGroup chipGroups)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetChipGroupIDByChipGroupObject(chipGroups));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
