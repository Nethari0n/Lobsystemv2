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
        private readonly ICRUDService _CRUDService;

        public RegistrationController(IChipGroupRegistrationService chipGroupRegistrationService, ICRUDService crudService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
            _CRUDService = crudService;
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
        [Route("chipid/{id}/eventid/{eventId}")]
        public IActionResult GetRegistrationByChipAndEventId(int id, int eventId)
        {
            try
            {
                var response = _chipGroupRegistrationService.GetRegistrationByChipAndEventId(id, eventId);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        public IActionResult CreateRegistration(Registration registration)
        {
            try
            {
                _CRUDService.CreateEntity(registration);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public IActionResult UpdateRegistration(Registration registration)
        {
            try
            {
                _CRUDService.UpdateEntity(registration);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete]
        [Route("ChipId/{id}/EventId/{eventId}")]
        public IActionResult DeleteRegistration(int id, int eventId)
        {
            try
            {
                Registration registration = _chipGroupRegistrationService.GetRegistrationByChipAndEventId(id, eventId);
                _CRUDService.DeleteEntity(registration);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
