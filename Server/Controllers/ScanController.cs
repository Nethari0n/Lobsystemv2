using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScanController : ControllerBase
    {
        private readonly IScanService _scanService;

        public ScanController(IScanService scanService)
        {
            _scanService = scanService;
        }

        [HttpGet]
        public IActionResult GetAllScanningsPerUser(int id, int eventID)
        {
            try
            {
                return Ok(_scanService.GetAllScanningsPerUser(id, eventID));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{uid}/{id}/datetime")]
        public IActionResult FindScansDatetime(string uid, int id)
        {
            try
            {
                return Ok(_scanService.FindScansDatetime(uid, id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{uid}/{id}")]
        public IActionResult GetScan(string uid, int postID)
        {
            try
            {
                return Ok(_scanService.GetScan(uid, postID));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
