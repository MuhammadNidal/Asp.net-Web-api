using Fophex.Application.Shared.Common.Dto;

using Microsoft.AspNetCore.Mvc;

using Fophex.Application.Shared.HumanResource.Master.Categorys;

using Fophex.Application.Shared.Accounts.Master.Categories.Dto;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class CategroysController : ControllerBase
    {
        private ICategoryAppService _categoryAppService;
        ResponseOutputDto _response;

        public CategroysController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
            if (_response == null)

            {
                _response = new ResponseOutputDto();
            }
        }
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
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _categoryAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _categoryAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _categoryAppService.Update(id, updateCategoryDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _categoryAppService.Delete(id);
            return Ok(_response);
        }
    }
}
