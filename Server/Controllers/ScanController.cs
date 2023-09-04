using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScanController : ControllerBase
    {
        private readonly IScanService _scanService;
        private readonly ICreateService _createService;

        public ScanController(IScanService scanService, ICreateService createService)
        {
            _scanService = scanService;
            _createService = createService;
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

        [HttpPost]
        public IActionResult CreateScan(Scanning scanning)
        {
            try
            {
                return Ok(_createService.CreateEntity(scanning));
            }
            catch (Exception)
            {

                throw;
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
