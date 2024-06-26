using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class TravelClassesController : ControllerBase
    {
        private ITravelClassAppService _travelClassAppService;
        ResponseOutputDto _response;

        public TravelClassesController(ITravelClassAppService travelClassAppService)
        {
            _travelClassAppService = travelClassAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateTravelClassDto createTravelClassDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            _response = await _travelClassAppService.Add(createTravelClassDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _travelClassAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _travelClassAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTravelClassDto updateTravelClassDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _travelClassAppService.Update(id, updateTravelClassDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _travelClassAppService.Delete(id);
            return Ok(_response);
        }
    }
}
