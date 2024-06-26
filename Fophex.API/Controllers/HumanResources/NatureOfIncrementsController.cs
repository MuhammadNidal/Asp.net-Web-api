using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes;
using Fophex.Application.HumanResourse.Master;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements.Dto;

namespace Fophex.API.Controllers.HumanResources
{



    [Route("api/hr/[controller]")]
    [ApiController]
    public class NatureOfIncrementsController : ControllerBase
    {
        private INatureOfIncrementAppService _natureOfIncrementAppService;
        ResponseOutputDto _response;

        public NatureOfIncrementsController(INatureOfIncrementAppService natureOfIncrementAppService)
        {
            _natureOfIncrementAppService = natureOfIncrementAppService;
            if (_response == null)

            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateNatureOfIncrementDto createNatureOfIncrementDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            _response = await _natureOfIncrementAppService.Add(createNatureOfIncrementDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _natureOfIncrementAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _natureOfIncrementAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateNatureOfIncrementDto updateNatureOfIncrementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _natureOfIncrementAppService.Update(id, updateNatureOfIncrementDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _natureOfIncrementAppService.Delete(id);
            return Ok(_response);
        }
    }
}
