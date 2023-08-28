using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Classes;
using SBO.LobSystem.Services.Interface;
using System.Net;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RapportController : ControllerBase
    {
        private readonly IRapportService _rapportService;

        public RapportController(IRapportService rapportService)
        {
            _rapportService = rapportService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLiveRapportByID(int id)
        {
            try
            {
                return Ok(_rapportService.GetLiveRapport(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}/endrapport")]
        public IActionResult GetEndRapportByID(int id)
        {
            try
            {
                return Ok(_rapportService.GetRapports(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
