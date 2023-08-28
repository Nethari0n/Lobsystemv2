using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IEventPostTypesService _eventPostTypesService;

        public PostController(IEventPostTypesService eventPostTypesService)
        {
            _eventPostTypesService = eventPostTypesService;
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
                return Ok(_eventPostTypesService.GetAllPostByEventID(id));
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
    }
}
