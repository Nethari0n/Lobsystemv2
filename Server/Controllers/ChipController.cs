using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChipController : ControllerBase
    {
        private readonly IChipGroupRegistrationService _chipGroupRegistrationService;
        private readonly ICreateService _createService;

        public ChipController(IChipGroupRegistrationService chipGroupRegistrationService, ICreateService createService)
        {
            _chipGroupRegistrationService = chipGroupRegistrationService;
            _createService = createService;
        }

        #region Get
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
        [Route("{search}/Search")]
        public IActionResult GetAllChipsSearch(string search)
        {
            try
            {
                return Ok(_chipGroupRegistrationService.GetAllChips().Where(x => x.UID.Contains(search) ||x.LaanerID.Contains(search)));
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

        #endregion

        #region Post
        

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateChip(ChipHandlingDTO chip)
        {
            try
            {
                Chip chipObj = new() { LaanerID = chip.LaanerID, UID = chip.UID };
                await _createService.CreateEntity(chipObj);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("CreateList")]
        public async Task<IActionResult> CreateChip(List<ChipHandlingDTO> chips)
        {
            try
            {
                foreach (var chip in chips)
                {
                    Chip chipObj = new() { LaanerID = chip.LaanerID, UID = chip.UID };
                    await _createService.CreateEntity(chipObj);
                }
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateChip(ChipHandlingDTO chip)
        {
            try
            {
                Chip chipObj = _chipGroupRegistrationService.GetChipByID((int)chip.ChipID);
                chipObj.UID = chip.UID;
                chipObj.LaanerID = chip.LaanerID;
                chipObj.Aktive = chip.Aktive;
                await _createService.UpdateEntity(chipObj);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
