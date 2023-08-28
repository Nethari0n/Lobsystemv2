using Microsoft.AspNetCore.Mvc;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IChipGroupRegistrationService _chipGroupRegistrationService;

        public RegistrationController(IChipGroupRegistrationService chipGroupRegistrationService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
        }

        [HttpGet]
        public IActionResult GetAllRegistrations()
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetAllRegistrations());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("chipid/{id}/eventid{eventId}")]
        public IActionResult GetRegistrationByChipAndEventId(int id, int eventId)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetRegistrationByChipAndEventId(id, eventId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
