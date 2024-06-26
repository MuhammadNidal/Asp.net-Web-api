using Fophex.Application.Accounts.Master.Classifications;
using Fophex.Application.Shared.Accounts.Master.Classifications;
using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/subclassifications")]
    [ApiController]
    public class SubClassificationsController :ControllerBase
    {
        private readonly ISubClassificationAppService _subclassificationAppService;
        ResponseOutputDto _response;
        public SubClassificationsController(ISubClassificationAppService subclassificationAppService)
        {
            _subclassificationAppService = subclassificationAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }
        /// <summary>
        /// Create SubClassificationEntity
        /// </summary>
        /// <param name="createSubClassificationDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateSubClassificationDto createSubClassificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _subclassificationAppService.Add(createSubClassificationDto);

            return Ok(response);
        }
        /// <summary>
        /// Get all available SubClassification
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _subclassificationAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single SubClassification by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _subclassificationAppService.GetById(id);
            return Ok(_response);

        }

        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSubClassificationyDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubClassificationDto updateSubClassificationDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _subclassificationAppService.Update(id, updateSubClassificationDto);
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
            _response = await _subclassificationAppService.Delete(id);
            return Ok(_response);
        }
    }
}
