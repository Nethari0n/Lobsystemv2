using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
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
        //[Route("CreateEvent")]
        public async Task<IActionResult> AddEvent(EventPostsDTO eventType)
        {
            try
            {
                List<Post> posts = new List<Post>();
                foreach (var item in eventType.PostList)
                {
                    Post post = new()
                    {
                        Multiplyer = item.Multiplyer,
                        IsDeleted = false,
                        Distance = item.Distance,
                        PostNum = item.PostNum

                    };

                    posts.Add(post);
                }
                Event newEvent = new()
                {
                    EventName = eventType.CreateEvent.EventName,
                    Description = eventType.CreateEvent.Description,
                    CreateDate = DateTime.Now,
                    EndDate = eventType.CreateEvent.EndDate,
                    StartDate = eventType.CreateEvent.StartDate,
                    CooldownTimer = eventType.CreateEvent.CooldownTimer,
                    IsDeleted = false,
                    TypesID = eventType.CreateEvent.TypesID,                    
                    Username = eventType.CreateEvent.Username,
                    Posts = posts
                };
              
                _eventPostTypesService.AddEvent(newEvent);
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
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var test = await _eventPostTypesService.GetAllEvents();
                List<EventTypeDTO> eventTypeDTOs = new List<EventTypeDTO>();
                foreach (var item in test)
                {
                    eventTypeDTOs
                        .Add(new EventTypeDTO
                        {
                            CooldownTimer = item.CooldownTimer,
                            Description = item.Description,
                            EndDate = item.EndDate,
                            StartDate = item.StartDate,
                            EventID = item.EventID,
                            EventName = item.EventName,
                            TypeName = item.Type.TypeName,
                            TypesID = item.TypesID,
                            Username = item.Username
                        });
                }
                return Ok(eventTypeDTOs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
