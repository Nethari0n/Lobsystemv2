using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IEventPostTypesService _eventPostTypesService;
        private readonly ICRUDService _createService;
        public PostController(IEventPostTypesService eventPostTypesService, ICRUDService createService)
        {
            _eventPostTypesService = eventPostTypesService;
            _createService = createService;
        }

        [HttpPost]
        public IActionResult AddPostFromList(List<Post> list, int id)
        {
            try
            {
                _eventPostTypesService.AddPostFromList(list, id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAllPostByEventID(int id)
        {
            try
            {
                return Ok(_eventPostTypesService.GetAllPostByEventID(id).ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{typeName}/exists")]
        public IActionResult TypeExists(string typeName)
        {
            try
            {
                return Ok(_eventPostTypesService.TypeExists(typeName));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                _eventPostTypesService.DeletePost(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdatePost(EditPostDTO editPostDTO)
        {
            try
            {
                Post post = new()
                {
                    PostID = editPostDTO.PostId,
                    PostNum = editPostDTO.PostNum,
                    EventID = editPostDTO.EventId,
                    Distance = editPostDTO.Distance,
                    Multiplyer = editPostDTO.Multiplyer,
                };
                await _createService.UpdateEntity(post);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(EditPostDTO editPostDTO)
        {
            try
            {
                Post post = new()
                {
                    PostNum = editPostDTO.PostNum,
                    EventID = editPostDTO.EventId,
                    Distance = editPostDTO.Distance,
                    Multiplyer = editPostDTO.Multiplyer,
                    IsDeleted = false
                };
               await  _createService.CreateEntity(post);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
