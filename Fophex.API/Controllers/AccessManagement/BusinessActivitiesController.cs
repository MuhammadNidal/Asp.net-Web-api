using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities;
using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.AccessManagement
{
    // Define RolesController class as an API controller
    [Route("api/access-manag/[controller]")]
    [ApiController]
    public class BusinessActivitiesController : ControllerBase
    {
        // Declare private fields
        IBusinessActivityAppService _businessActivityAppService;
        ResponseOutputDto _response;
        // Constructor for RolesController
        public BusinessActivitiesController(IBusinessActivityAppService businessActivityAppService)
        {
            _businessActivityAppService = businessActivityAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        //Create BusinessActivity Entity.
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateBusinessActivityDto createBusinessActivityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _businessActivityAppService.Add(createBusinessActivityDto);
            return Ok(_response);
        }
        //Get All BusinessActivity Entity.
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _businessActivityAppService.GetAll();
            return Ok(_response);
        }
        //GetById BusinessActivity Entity.
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _businessActivityAppService.GetById(id);
            return Ok(_response);
        }
        //Update BusinessActivity Entity
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBusinessActivityDto updateBusinessActivityDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _businessActivityAppService.Update(id, updateBusinessActivityDto);
            return Ok(_response);
        }
        // delete BusinessActivity Entity
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _businessActivityAppService.Delete(id);
            return Ok(_response);
        }
    }
}
