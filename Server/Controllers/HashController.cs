using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HashController : ControllerBase
    {
        private readonly IUserService _userService;

        public HashController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult CreateSalt()
        {
            try
            {
                return Ok(_userService.CreateSalt());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{password}/{salt}")]
        public IActionResult GenerateHash(string password, string salt)
        {
            try
            {
                return Ok(_userService.GenerateHash(password, salt));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{plainTextPassword}/{hashedPassword}/{salt}")]
        public IActionResult PasswordAreEqual(string plainTextPassword, string hashedPassword, string salt)
        {
            try
            {
                return Ok(_userService.PasswordAreEqual(plainTextPassword, hashedPassword, salt));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
