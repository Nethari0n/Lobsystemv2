using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;
using SBO.LobSystem.Services.Services;
using System.Security.Claims;

namespace Lobsystem.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded)
                return BadRequest("Invalid password");
            await _signInManager.SignInAsync(user, request.RememberMe);

            var IsAuthenticated = User.Identity.IsAuthenticated;
            var UserName = User.Identity.Name;
            var Claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest parameters)
        {
            var user = new User() { UserName = parameters.UserName, Email = parameters.Email, IsDeleted = false, EmailConfirmed = true, Name = parameters.Name };
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            //return await Login(new LoginRequest
            //{
            //    UserName = parameters.UserName,
            //    Password = parameters.Password
            //});
            return Ok();
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(RegisterRequest parameters)
        {
            try
            {

                var user = _userService.GetAllUsers().Where(x => x.Id == parameters.Id).FirstOrDefault();

                if (user == null)
                    return BadRequest("User not Found");
                user.Email = parameters.Email;

                user.Name = parameters.Name;


                user.UserName = parameters.UserName;
                if (parameters.Password != null)
                {
                    var hasher = new PasswordHasher<User>();
                    user.PasswordHash = hasher.HashPassword(user, parameters.Password);
                }

                await _userManager.UpdateAsync(user);
                user = new();
                return Ok();


            }
            catch (Exception)
            {

                throw;
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {
            CurrentUser cu = new()
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                Claims = User.Claims
                .ToDictionary(c => c.Type, c => c.Value)
            };
            return cu;
        }
    }


}
