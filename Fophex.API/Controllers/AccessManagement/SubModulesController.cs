using Fophex.Application.AccessManagment.Master;
using Fophex.Application.Shared.AccessManagement.Master.Modules;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.AccessManagement
{
    // Define ModulesController class as an API controller
    [Route("api/access-manag/[controller]")]
    [ApiController]
    public class SubModulesController : ControllerBase
    {
        // Declare private fields
        ISubModuleAppService _submoduleAppService;
        ResponseOutputDto _response;
        // Constructor for ModulesController
        public SubModulesController(ISubModuleAppService submoduleAppService)
        {
            _submoduleAppService = submoduleAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        /// <summary>
        /// Create subModule Entity
        /// </summary>
        /// <param name="createSubModuleDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateSubModuleDto createsubModuleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _submoduleAppService.Add(createsubModuleDto);
            return Ok(_response);
        }
        /// <summary>
        /// Get all available submodules
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _submoduleAppService.GetAll();
            return Ok(_response);

        }
        /// <summary>
        /// Get single submodule by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _submoduleAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSubModuleDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubModuleDto updateSubModuleDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _submoduleAppService.Update(id, updateSubModuleDto);
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
            _response = await _submoduleAppService.Delete(id);
            return Ok(_response);
        }

    }
}
