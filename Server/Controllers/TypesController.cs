using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypesController : ControllerBase
    {
        private readonly IEventPostTypesService _eventPostTypesService;

        public TypesController(IEventPostTypesService eventPostTypesService)
        {
            _eventPostTypesService = eventPostTypesService;
        }

        [HttpGet]
        public IActionResult GetAllTypes()
        {
            try
            {
                return Ok(_eventPostTypesService.GetAllTypes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{page}/{totalItem}")]
        public IActionResult TypesPagination(int page, int totalItem)
        {
            try
            {
                return Ok(_eventPostTypesService.TypesPagination(page, totalItem));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{page}/{totalItem}/{search}")]
        public IActionResult SearchType(int page, int totalItem, string search)
        {
            try
            {
                return Ok(_eventPostTypesService.SearchType(page, totalItem, search));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMultiRound(int id)
        {
            try
            {
                return Ok(_eventPostTypesService.GetMultiRound(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteType(int id)
        {
            try
            {
                _eventPostTypesService.DeleteType(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
