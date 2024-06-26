using Fophex.Application;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Application.Shared.Test;
using Fophex.Application.Shared.Test.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.AccessManagement
{
    // Define RolesController class as an API controller
    [Route("api/access-manag/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // Declare private fields
        IRoleAppService _roleAppService;
        ResponseOutputDto _response;
        // Constructor for RolesController
        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        /// <summary>
        /// Create Role Entity
        /// </summary>
        /// <param name="createRoleDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateRoleDto createRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _roleAppService.Add(createRoleDto);
            return Ok(_response);
        }
        /// <summary>
        /// Get all available roles
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _roleAppService.GetAll();
            return Ok(_response);

        }
        /// <summary>
        /// Get single role by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _roleAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRoleDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRoleDto updateRoleDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _roleAppService.Update(id, updateRoleDto);
            return Ok(_response);
        }
        /// <summary>
        /// Delete single entity for the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _roleAppService.Delete(id);
            return Ok(_response);
        }

    }
}
