using Azure;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys;
using Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class TrainingFundedBysController : ControllerBase
    {
        private ITrainingFundedByAppService _trainingFundedByAppService;
        ResponseOutputDto _response;
        public TrainingFundedBysController(ITrainingFundedByAppService trainingFundedByAppService)
        {
            _trainingFundedByAppService = trainingFundedByAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]

        public async Task<IActionResult> Add(CreateTrainingFundedByDto createTrainingFundedByDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _trainingFundedByAppService.Add(createTrainingFundedByDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]

        public async Task<IActionResult> GetAll()
        {
            _response = await _trainingFundedByAppService.GetaAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _trainingFundedByAppService.GetById(id);
            return Ok(_response);


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTrainingFundedByDto updateTrainingFundedByDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            _response = await _trainingFundedByAppService.Update(id, updateTrainingFundedByDto);
            return Ok(_response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _trainingFundedByAppService.Delete(id);
            return Ok(_response);
        }
    }
}
