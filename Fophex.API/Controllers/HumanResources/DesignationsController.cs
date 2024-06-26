using Fophex.Application.HumanResourse.Master.Designations;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Designations;
using Fophex.Application.Shared.HumanResource.Master.Designations.Dto;
using Fophex.Application.Shared.Test.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private IDesignationAppServices _designationAppServices;
        ResponseOutputDto _response;

        public DesignationsController(IDesignationAppServices designationAppServices)
        {
            _designationAppServices = designationAppServices;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateDesignationDto createDesignationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _designationAppServices.Add(createDesignationDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _designationAppServices.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _designationAppServices.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDesignationDto updateDesignationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _designationAppServices.Update(id, updateDesignationDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _designationAppServices.Delete(id);
            return Ok(_response);
        }
    }
}
