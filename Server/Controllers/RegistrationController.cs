using Microsoft.AspNetCore.Mvc;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.Interface;
using Lobsystem.Shared.DTO;

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
        public async Task<IActionResult> CreateRegistration(RegistrationDTO registrationDTO)
        {
            try
            {
                var newRegistration = new Registration() { ChipID = registrationDTO.ChipId, EventID = registrationDTO.EventId, CreateDate = DateTime.Now };
                await _CRUDService.CreateEntity(newRegistration);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        //TODO: WHAT IS THIS FOR?!
        [HttpPut]
        public async Task<IActionResult> UpdateRegistration(RegistrationDTO registrationDTO)
        {
            try
            {
                var editRegistration = await _chipGroupRegistrationService.GetRegistrationById((int)registrationDTO.RegistrationId);
                editRegistration.EventID = registrationDTO.EventId;
                editRegistration.CreateDate = DateTime.Now;
                editRegistration.ChipID = registrationDTO.ChipId;
                await _CRUDService.UpdateEntity(editRegistration);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete]
        [Route("ChipId/{id}/EventId/{eventId}")]
        public async Task<IActionResult> DeleteRegistration(int id, int eventId)
        {
            try
            {
                Registration registration = _chipGroupRegistrationService.GetRegistrationByChipAndEventId(id, eventId);
                await _CRUDService.DeleteEntity(registration);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
