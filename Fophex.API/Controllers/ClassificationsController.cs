using Fophex.Application.Accounts.Master.Sub_Categories;
using Fophex.Application.Shared.Accounts.Master.Classifications;
using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;
using Fophex.Application.Shared.Accounts.Master.SubCategories;
using Fophex.Application.Shared.Accounts.Master.SubCategories.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/classifications")]
    [ApiController]
    public class ClassificationsController : ControllerBase
    {
        private readonly IClassificationAppService _classificationAppService;
        ResponseOutputDto _response;

        public ClassificationsController(IClassificationAppService classificationAppService)
        {
            _classificationAppService = classificationAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }
        /// <summary>
        /// Create Classification Entity
        /// </summary>
        /// <param name="createClassificationDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateClassificationDto createClassificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _classificationAppService.Add(createClassificationDto);
            return Ok(_response);
        }

        /// <summary>
        /// Get all available Classification
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _classificationAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single Classification by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _classificationAppService.GetById(id);
            return Ok(_response);

        }

        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateClassificationyDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateClassificationDto updateClassificationDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _classificationAppService.Update(id, updateClassificationDto);
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
            _response = await _classificationAppService.Delete(id);
            return Ok(_response);
        }

    }
}
