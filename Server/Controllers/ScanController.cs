﻿using Lobsystem.Shared.DTO;
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
        private readonly ICRUDService _createService;

        public ScanController(IScanService scanService, ICRUDService createService)
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
        [Route("CreateOne")]
        public async Task<IActionResult> CreateScan(ScanningDTO scanning)
        {
            try
            {
                Scanning scan = new() { ChipID = scanning.ChipID, IsDeleted = false, PostID = scanning.PostID, TimeStamp = scanning.TimeStamp };

                //_createService.CreateEntity(scanning);
                await _createService.CreateEntity<Scanning>(scan);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("CreateList")]
        public async Task<IActionResult> CreateScans(List<ScanningDTO> scanningDTOs)
        {

            try
            {

                foreach (var scanning in scanningDTOs)
                {
                    Scanning scan = new() { ChipID = scanning.ChipID, IsDeleted = false, PostID = scanning.PostID, TimeStamp = scanning.TimeStamp };

                    //_createService.CreateEntity(scanning);
                    await _createService.CreateEntity<Scanning>(scan);

                }
                return Ok();
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

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteScan(int id)
        {
            try
            {
                Scanning scanning = _scanService.GetScanById(id);
                await _createService.DeleteEntity(scanning);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
