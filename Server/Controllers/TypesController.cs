using Lobsystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using SBO.LobSystem.Services.Interface;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Lobsystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypesController : ControllerBase
    {
        private readonly IEventPostTypesService _eventPostTypesService;
        private readonly ICRUDService _crudService;

        public TypesController(IEventPostTypesService eventPostTypesService, ICRUDService crudService)
        {
            _eventPostTypesService = eventPostTypesService;
            _crudService = crudService;
        }

        [HttpPost]
        [Route("CreateType")]
        public IActionResult CreateType(Types types)
        {
            try
            {
                return Ok(_crudService.CreateEntity(types));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("UpdateType")]
        public IActionResult UpdateTypes(Types types)
        {
            try
            {
                return Ok(_crudService.UpdateEntity(types));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
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


        [HttpGet]
        [Route("Exists/{id}")]
        public IActionResult TypeExists(int id)
        {
            try
            {
                return Ok(_eventPostTypesService.GetAllTypes().Any(x=> x.TypesID == id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("Exists/{typename}")]
        public IActionResult TypeExists(string typeName)
        {
            try
            {
                return Ok(_eventPostTypesService.GetAllTypes().Any(x => x.TypeName == typeName));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
