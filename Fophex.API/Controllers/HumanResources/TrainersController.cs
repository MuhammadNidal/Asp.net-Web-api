using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.Trainers;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private ITrainerAppService _trainerAppServices;
        ResponseOutputDto _response;

        public TrainersController(ITrainerAppService trainerAppServices)
        {
            _trainerAppServices = trainerAppServices;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateTrainerDto createTrainerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _trainerAppServices.Add(createTrainerDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _trainerAppServices.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _trainerAppServices.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTrainerDto UpdateTrainerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _trainerAppServices.Update(id, UpdateTrainerDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _trainerAppServices.Delete(id);
            return Ok(_response);
        }
    }
}
