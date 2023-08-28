using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IUserService _userService;

        public RoleController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //public IActionResult GetAllRoles()
        //{
        //    try
        //    {
        //        return Ok(_userService.GetAllRoles());
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest);
        //    }
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetRoleByRoleID(string id)
        //{
        //    try
        //    {
        //        return Ok(_userService.GetRoleByRoleID(id));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest);
        //    }
        //}
    }
}
