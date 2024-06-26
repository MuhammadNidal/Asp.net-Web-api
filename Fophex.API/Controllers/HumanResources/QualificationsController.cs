using Fophex.Application.Shared.Common.Dto;

using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.Qualifications;

using Fophex.Application.Shared.HumanResource.Master.Qualifications.Dto;

namespace Fophex.API.Controllers.HumanResources
{
    // Define RolesController class as an API controller
    [Route("api/hr/[controller]")]
    [ApiController]
    public class QulaficationsController : ControllerBase
    {
        // Declare private fields
        IQualificationAppService _qualificationAppService;
        ResponseOutputDto _response;
        // Constructor for RolesController
        public QulaficationsController(IQualificationAppService qualificationAppService)
        {
            _qualificationAppService = qualificationAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateQualificationDto CreateQualificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _qualificationAppService.Add(CreateQualificationDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _qualificationAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _qualificationAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateQualificationDto UpdateQualificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _qualificationAppService.Update(id, UpdateQualificationDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _qualificationAppService.Delete(id);
            return Ok(_response);
        }
    }
}
