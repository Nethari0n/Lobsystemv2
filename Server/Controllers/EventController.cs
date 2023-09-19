using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.IdentityModel.Logging;
using SBO.LobSystem.Services.Interface;
using SBO.LobSystem.Services.Services;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventPostTypesService _eventPostTypesService;
        private readonly ICRUDService _createService;
        public EventController(IEventPostTypesService eventPostTypesService, ICRUDService createService)
        {
            _eventPostTypesService = eventPostTypesService;
            _createService = createService;
        }

        [HttpPost]        
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


        [HttpGet]
        [Route("GetEditEventPost/{id}")]
        public async Task<IActionResult> GetEditEventPost(int id)
        {
            try
            {
                var temp = _eventPostTypesService.GetEventByID(id);
                var templist = _eventPostTypesService.GetAllPostByEventID(id);
                
                List<EditPostDTO> editPostDTOs = new();
                EditEventDTO editEventDTO = new()
                {
                     StartDate = temp.StartDate,
                     EndDate=temp.EndDate,
                     EventId = id,
                     EventName = temp.EventName,
                     CooldownTimer=temp.CooldownTimer,
                     Description = temp.Description,
                     TypesID = temp.TypesID,
                     Username = temp.Username
                };

                foreach (var item in templist)
                {
                    EditPostDTO editPostDTO = new()
                    {
                        Distance = item.Distance,
                        EventId = item.EventID,
                        Multiplyer = item.Multiplyer,
                        PostId = item.PostID,
                        PostNum = item.PostNum
                    };
                    editPostDTOs.Add(editPostDTO);
                }

                EditEventPostDTO editEventPostDTO = new() { EditEventDTO = editEventDTO, EditPostDTOs = editPostDTOs };

                return Ok(editEventPostDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);

            }
        }

        [HttpPost]
        [Route("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(EditEventDTO editEventPostDTO)
        {
            try
            {
                var temp = _eventPostTypesService.GetEventByID(editEventPostDTO.EventId);

                temp.StartDate = editEventPostDTO.StartDate;
                temp.Username = editEventPostDTO.Username;
                temp.CooldownTimer = editEventPostDTO.CooldownTimer;
                temp.Description = editEventPostDTO.Description;
                temp.EndDate = editEventPostDTO.EndDate;
                temp.EventName = editEventPostDTO.EventName;
                temp.TypesID = editEventPostDTO.TypesID;

                await _createService.UpdateEntity(temp);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
