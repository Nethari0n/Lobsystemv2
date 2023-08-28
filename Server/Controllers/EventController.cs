using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventPostTypesService _eventPostTypesService;

        public EventController(IEventPostTypesService eventPostTypesService)
        {
            _eventPostTypesService = eventPostTypesService;
        }

        [HttpPost]
        public IActionResult AddEvent(Event events)
        {
            try
            {
                _eventPostTypesService.AddEvent(events);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        //[HttpGet]
        //[Route("{time}/{name}")]
        //public IActionResult FindEvent(DateTime time, string name)
        //{
        //    try
        //    {
        //        return Ok(_eventPostTypesService.FindEvent(time, name));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest);
        //    }
        //}

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEventById(int id)
        {
            try
            {
                return Ok(_eventPostTypesService.GetEventByID(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            try
            {
                return Ok(_eventPostTypesService.GetAllEvents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
