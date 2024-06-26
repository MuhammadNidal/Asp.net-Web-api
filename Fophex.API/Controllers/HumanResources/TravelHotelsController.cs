using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels.Dto;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class TravelHotelsController : ControllerBase
    {
        private ITravelHotelAppService _travelHotelAppService;
        ResponseOutputDto _response;

        public TravelHotelsController(ITravelHotelAppService travelHotelAppService)
        {
            _travelHotelAppService = travelHotelAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateTravelHotelDto createTravelHotelDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            _response = await _travelHotelAppService.Add(createTravelHotelDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _travelHotelAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _travelHotelAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTravelHotelDto updateTravelHotelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _travelHotelAppService.Update(id, updateTravelHotelDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _travelHotelAppService.Delete(id);
            return Ok(_response);
        }
    }
}
