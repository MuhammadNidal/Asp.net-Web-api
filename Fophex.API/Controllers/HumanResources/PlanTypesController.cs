using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes.Dto;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class PlanTypesController : ControllerBase
    {
        private IPlanTypeAppService _planTypeAppService;
        ResponseOutputDto _response;

        public PlanTypesController(IPlanTypeAppService planTypeAppService)
        {
            _planTypeAppService = planTypeAppService;
            if (_response == null)

            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreatePlanTypeDto createPlanTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _planTypeAppService.Add(createPlanTypeDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _planTypeAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _planTypeAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePlanTypeDto updatePlanTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _planTypeAppService.Update(id, updatePlanTypeDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _planTypeAppService.Delete(id);
            return Ok(_response);
        }
    }
}
