using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericCRUDController : ControllerBase
    {
        private readonly ICRUDService _createService;
        public GenericCRUDController(ICRUDService createService)
        {
            _createService = createService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntityAsync<T>(T entity) where T : class
        {
            try
            {
                await _createService.CreateEntity(entity);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntityAsync<T>(T entity) where T : class
        {
            try
            {
                await _createService.UpdateEntity(entity);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEntityAsync<T>(T entity) where T : class
        {
            try
            {
                await _createService.DeleteEntity(entity);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}