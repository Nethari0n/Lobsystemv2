using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{page}/{totalItem}")]
        public IActionResult UserPagination(int page, int totalItem)
        {
            try
            {
                return Ok(_userService.UserPagination(page, totalItem));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{page}/{totalItem}/{search}")]
        public IActionResult SearchUser(int page, int totalItem, string search)
        {
            try
            {
                return Ok(_userService.SearchUser(page, totalItem, search));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUsernameByID(string id)
        {
            try
            {
                return Ok(_userService.GetUsernameByID(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{username}/{name}/{oldUsername}/{oldName}/exists")]
        public IActionResult UserExists(string username, string name, string oldUsername, string oldName)
        {
            try
            {
                return Ok(_userService.UserExists(username, name, oldUsername, oldName));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{username}/{name}/exists")]
        public IActionResult UserExists(string username, string name)
        {
            try
            {
                return Ok(_userService.UserExists(username, name));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
