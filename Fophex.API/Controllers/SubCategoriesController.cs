using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Accounts.Master.SubCategories;
using Fophex.Application.Shared.Accounts.Master.SubCategories.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Tenant;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryAppService _subcategoryAppService;

        ResponseOutputDto _response;
        public SubCategoriesController(ISubCategoryAppService subcategoryAppService)
        {
            _subcategoryAppService = subcategoryAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }
        /// <summary>
        /// Create SubCategory Entity
        /// </summary>
        /// <param name="createSubCategoryDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateSubCategoryDto createSubCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _subcategoryAppService.Add(createSubCategoryDto);
            return Ok(_response);
        }

        /// <summary>
        /// Get all available Subcategories
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _subcategoryAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single subcategory by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _subcategoryAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSubCategoryDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubCategoryDto updateSubCategoryDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _subcategoryAppService.Update(id, updateSubCategoryDto);
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
            _response = await _subcategoryAppService.Delete(id);
            return Ok(_response);
        }
    }
}
