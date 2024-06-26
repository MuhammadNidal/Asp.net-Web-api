using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations.Dto;
using Fophex.Application.HumanResourse.Master;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class TrainingLocations : ControllerBase
    {
        private ITrainingLocationAppService _trainingLocationAppService;
        ResponseOutputDto _response;

        public TrainingLocations(ITrainingLocationAppService trainingLocationAppService)
        {
            _trainingLocationAppService = trainingLocationAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateTrainingLocationDto createTrainingLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _trainingLocationAppService.Add(createTrainingLocationDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _trainingLocationAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _trainingLocationAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTrainingLocationDto updateTrainingLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _trainingLocationAppService.Update(id, updateTrainingLocationDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _trainingLocationAppService.Delete(id);
            return Ok(_response);
        }
    }
}
