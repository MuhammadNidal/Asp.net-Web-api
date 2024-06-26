using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;

namespace Fophex.API.Controllers
{
    
        [Route("api/hr/[controller]")]
        [ApiController]
        public class TrainingTypesController : ControllerBase
        {
            private ITrainingTypeAppService _trainingTypeAppServices;
            ResponseOutputDto _response;

            public TrainingTypesController(ITrainingTypeAppService trainingTypeAppServices)
            {
            _trainingTypeAppServices = trainingTypeAppServices;
                if (_response == null)
                {
                    _response = new ResponseOutputDto();
                }
            }
            [HttpPost]
            [Produces(typeof(ResponseOutputDto))]
            public async Task<IActionResult> Add(CreateTrainingTypeDto createTrainingTypeDto)
            {
                if (!ModelState.IsValid)
            {
              
                    return BadRequest(ModelState);
                }
                _response = await _trainingTypeAppServices.Add(createTrainingTypeDto);
                return Ok(_response);
            }
            [HttpGet]
            [Produces(typeof(ResponseOutputDto))]
            public async Task<IActionResult> GetAll()
            {
                _response = await _trainingTypeAppServices.GetAll();
                return Ok(_response);
            }
            [HttpGet("{id}")]
            [Produces(typeof(ResponseOutputDto))]
            public async Task<IActionResult> GetById(long id)
            {
                _response = await _trainingTypeAppServices.GetById(id);
                return Ok(_response);
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, UpdateTrainingTypeDto updateTrainingTypeDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _response = await _trainingTypeAppServices.Update(id, updateTrainingTypeDto);
                return Ok(_response);

            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(long id)
            {
                _response = await _trainingTypeAppServices.Delete(id);
                return Ok(_response);
            }
        }
}
