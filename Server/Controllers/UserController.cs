using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;
using SBO.LobSystem.Services.Services;

namespace Lobsystem.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICRUDService _crudService;

        public UserController(IUserService userService, ICRUDService crudService)
        {
            _userService = userService;
            _crudService = crudService;
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

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = _userService.GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
                user.IsDeleted = true;

                await _crudService.UpdateEntity(user);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(RegisterRequest parameters)
        {
            try
            {

                var user = _userService.GetAllUsers().Where(x => x.Id == parameters.Id).FirstOrDefault();

                if (user == null)
                    return BadRequest("User not Found");
                user.Email = parameters.Email;

                user.Name = parameters.Name;

                user.NormalizedEmail = user.Email.ToUpper();

                user.UserName = parameters.UserName;
                user.NormalizedUserName = user.UserName.ToUpper();
                if (parameters.Password != null)
                {
                    var hasher = new PasswordHasher<User>();
                    user.PasswordHash = hasher.HashPassword(user, parameters.Password);
                }

                await _crudService.UpdateEntity(user);

                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                List<string> roleNames = new List<string>();
                var roles = await _userService.GetAllRoles();
                foreach (var item in roles)
                {
                    roleNames.Add(item.Name);
                }
                return Ok(roleNames);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

    }
}
