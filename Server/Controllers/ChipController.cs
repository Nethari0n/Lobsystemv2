using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChipController : ControllerBase
    {
        private readonly IChipGroupRegistrationService _chipGroupRegistrationService;

        public ChipController(IChipGroupRegistrationService chipGroupRegistrationService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
        }

        [HttpGet]
        public IActionResult GetAllChips()
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetAllChips());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{page}/{totalItem}")]
        public IActionResult ChipPagination(int page, int totalItem)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.ChipPagination(page, totalItem));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{page}/{totalItem}/{search}")]
        public IActionResult SearchChip(int page, int totalItem, string search)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.SearchChip(page, totalItem, search));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> ToggleAktiveChip(int id)
        {
            try
            {
                await _chipGroupRegistrationService.ToggleAktiveChip(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{uid}/uid")]
        public IActionResult GetChipIDByUID(string uid)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetChipIDByUID(uid));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{uid}/chipuid")]
        public IActionResult GetChipIDByChipUID(string uid)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetChipIDByChipUID(uid));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}/event")]
        public IActionResult GetAllChipsFromEvent(int id)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetAllChipsFromEvent(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{uid}/exists")]
        public IActionResult ChipExists(string uid)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.ChipExists(uid));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
