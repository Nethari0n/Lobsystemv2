using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly ICRUDService _crudService;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager, IUserService userService, ICRUDService crudService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _crudService = crudService;
            _roleManager = roleManager;
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
            var roleResult = await _userManager.AddToRoleAsync(user, parameters.Role);
            if (!result.Succeeded && !roleResult.Succeeded)
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


        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole roleName)
        {
            //IdentityRole identityRole = new() { Name = roleName };

            var result = await _roleManager.CreateAsync(roleName);

            if (!result.Succeeded)
                return BadRequest(result.Errors.FirstOrDefault()?.Description);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _roleManager.Roles.ToListAsync();

            if (result.Count == 0)
                return BadRequest("No roles");

            return Ok(result);
        }

        [HttpGet]
        [Route("Pagination/{page}/{totalPages}")]
        public async Task<IActionResult> RolesPagination(int page, int totalPages)
        {
            var result = await _userService.RolePagination(page, totalPages);

            if (result.Count == 0)
                return BadRequest("No roles");

            return Ok(result);
        }
       
    }


}
