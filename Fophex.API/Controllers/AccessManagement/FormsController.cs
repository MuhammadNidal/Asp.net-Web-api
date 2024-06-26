using Fophex.Application.Shared.AccessManagement.Master.Forms;
using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.AccessManagement
{
    // Define FormsController class as an API controller
    [Route("api/access-manag/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        // Declare private fields
        IFormAppService _formAppService;
        ResponseOutputDto _response;
        // Constructor for FormsController
        public FormsController(IFormAppService formAppService)
        {
            _formAppService = formAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        /// <summary>
        /// Create Form Entity
        /// </summary>
        /// <param name="createFormDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateFormDto createFormDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _formAppService.Add(createFormDto);
            return Ok(_response);
        }
        /// <summary>
        /// Get all available forms
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _formAppService.GetAll();
            return Ok(_response);

        }
        /// <summary>
        /// Get single form by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _formAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateFormDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFormDto updateFormDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _formAppService.Update(id, updateFormDto);
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
            _response = await _formAppService.Delete(id);
            return Ok(_response);
        }

    }
}
