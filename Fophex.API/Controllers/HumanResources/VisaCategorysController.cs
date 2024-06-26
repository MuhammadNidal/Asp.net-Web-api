using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.VisaCategorys;
using Fophex.Application.Shared.HumanResource.Master.VisaCategorys.Dto;
using Fophex.Application.HumanResourse.Master;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class VisaCategorysController : ControllerBase
    {
        private IVisaCategoryAppService _visaCategoryAppService;
        ResponseOutputDto _response;

        public VisaCategorysController(IVisaCategoryAppService visaCategoryAppService)
        {
            _visaCategoryAppService = visaCategoryAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateVisaCategoryDto createVisaCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _visaCategoryAppService.Add(createVisaCategoryDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _visaCategoryAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _visaCategoryAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateVisaCategoryDto updateVisaCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _visaCategoryAppService.Update(id, updateVisaCategoryDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _visaCategoryAppService.Delete(id);
            return Ok(_response);
        }
    }
}
