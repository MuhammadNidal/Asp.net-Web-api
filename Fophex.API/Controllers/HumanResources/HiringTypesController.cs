using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class HiringTypesController : ControllerBase
    {
        private IHiringTypeAppService _hiringTypeAppService;
        ResponseOutputDto _response;

        public HiringTypesController(IHiringTypeAppService hiringTypeAppService)
        {
            _hiringTypeAppService = hiringTypeAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateHiringTypeDto createHiringTypeDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            _response = await _hiringTypeAppService.Add(createHiringTypeDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _hiringTypeAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _hiringTypeAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateHiringTypeDto updateHiringTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _hiringTypeAppService.Update(id, updateHiringTypeDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _hiringTypeAppService.Delete(id);
            return Ok(_response);
        }
    }
}
