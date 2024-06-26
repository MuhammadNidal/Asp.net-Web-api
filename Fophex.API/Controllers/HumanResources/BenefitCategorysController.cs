using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys.Dto;
using Fophex.Application.HumanResourse.Master;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class BenefitCategorysController : ControllerBase
    {
        private IBenefitCategoryAppService _benefitCategoryAppService;
        ResponseOutputDto _response;

        public BenefitCategorysController(IBenefitCategoryAppService benefitCategoryAppService)
        {
            _benefitCategoryAppService = benefitCategoryAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateBenefitCategoryDto CreateBenefitCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _benefitCategoryAppService.Add(CreateBenefitCategoryDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _benefitCategoryAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _benefitCategoryAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBenefitCategoryDto updateBenefitCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _benefitCategoryAppService.Update(id, updateBenefitCategoryDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _benefitCategoryAppService.Delete(id);
            return Ok(_response);
        }
    }
}
