 using Fophex.Application.Shared.Accounts.Master.Categories;
using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Test.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryAppService _categoryAppService;
        ResponseOutputDto _response;

        public CategoriesController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
            if(_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }
        /// <summary>
        /// Create Category Entity
        /// </summary>
        /// <param name="createCategoryDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _categoryAppService.Add(createCategoryDto);
            return Ok(_response);
        }
        /// <summary>
        /// Get all available categories
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _categoryAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single category by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _categoryAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCategoryDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto updateCategoryDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _categoryAppService.Update(id, updateCategoryDto);
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
            _response = await _categoryAppService.Delete(id);
            return Ok(_response);
        }

    }

}
