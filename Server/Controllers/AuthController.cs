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
        private readonly ICRUDService _crudService;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService, ICRUDService crudService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _crudService = crudService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || user.IsDeleted)
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
