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
        [Route("{id}/exists")]
        public async Task<IActionResult> ChipGroupExists(int id)
        {
            try
            {
                var temp =  _chipGroupRegistrationService.GetAllChipGroups().Where(x => x.ChipGroupID == id).FirstOrDefault();

                return Ok(_chipGroupRegistrationService.ChipGroupExists(temp));
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

        [HttpPost]
        public IActionResult CreateChipGroup(ChipGroup chipGroup)
        {
            try
            {
                _CRUDService.CreateEntity(chipGroup);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public IActionResult DeleteChipGroup(ChipGroup chipGroup)
        {
            try
            {
                _chipGroupRegistrationService.RemoveChipGroup(chipGroup);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpPut]
        public IActionResult UpdateChipGroup(ChipGroup chipGroup)
        {
            try
            {
                _CRUDService.UpdateEntity(chipGroup);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        
    }
}
