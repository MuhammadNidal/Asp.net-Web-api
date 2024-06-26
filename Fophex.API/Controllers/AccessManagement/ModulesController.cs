using Fophex.Application.AccessManagment.Master;
using Fophex.Application.Shared.AccessManagement.Master.Modules;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role;
using Fophex.Application.Shared.Role.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.AccessManagement
{
    // Define ModulesController class as an API controller
    [Route("api/access-manag/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        // Declare private fields
        IModuleAppService _moduleAppService;
        ResponseOutputDto _response;
        // Constructor for ModulesController
        public ModulesController(IModuleAppService moduleAppService)
        {
            _moduleAppService = moduleAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        /// <summary>
        /// Create Module Entity
        /// </summary>
        /// <param name="createModuleDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateModuleDto createModuleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _moduleAppService.Add(createModuleDto);
            return Ok(_response);
        }
        /// <summary>
        /// Get all available modules
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _moduleAppService.GetAll();
            return Ok(_response);

        }
        /// <summary>
        /// Get single moduule by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _moduleAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateModuleDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateModuleDto updateModuleDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _moduleAppService.Update(id, updateModuleDto);
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
            _response = await _moduleAppService.Delete(id);
            return Ok(_response);
        }

    }
}
