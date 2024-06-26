using Fophex.Application.AccessManagment.Master;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Forms;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.AccessManagement
{
    // Define RoleRightController class as an API controller
    [Route("api/access-manag/[controller]")]
    [ApiController]
    public class RoleRightsController : ControllerBase
    {
        // Declare private fields
        IRoleRightAppService _roleRightAppService;
        ResponseOutputDto _response;
        // Constructor for RoleRightController
        public RoleRightsController(IRoleRightAppService roleRightAppService)
        {
            _roleRightAppService = roleRightAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        /// <summary>
        /// Create RoleRight Entity
        /// </summary>
        /// <param name="createRoleRightDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateRoleRightDto createRoleRightDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _roleRightAppService.Add(createRoleRightDto);
            return Ok(_response);
        }
        /// <summary>
        /// Get all available RoleRight
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _roleRightAppService.GetAll();
            return Ok(_response);

        }
        /// <summary>
        /// Get single roleright by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _roleRightAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRoleRightDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRoleRightDto updateRoleRightDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _roleRightAppService.Update(id, updateRoleRightDto);
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
            _response = await _roleRightAppService.Delete(id);
            return Ok(_response);
        }

    }
}
