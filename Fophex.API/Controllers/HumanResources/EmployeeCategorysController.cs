using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys;
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys.Dto;
using Fophex.Application.HumanResourse.Master;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class EmployeeCategorysController : ControllerBase
    {
        private IEmployeeCategoryAppService _employeeCategoryAppService;
        ResponseOutputDto _response;

        public EmployeeCategorysController(IEmployeeCategoryAppService employeeCategoryAppService)
        {
            _employeeCategoryAppService = employeeCategoryAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateEmployeeCategoryDto createEmployeeCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _employeeCategoryAppService.Add(createEmployeeCategoryDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _employeeCategoryAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _employeeCategoryAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCategoryDto updateEmployeeCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _employeeCategoryAppService.Update(id, updateEmployeeCategoryDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _employeeCategoryAppService.Delete(id);
            return Ok(_response);
        }
    }
}
