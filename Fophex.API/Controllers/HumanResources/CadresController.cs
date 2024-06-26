using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;

using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class CadresController : ControllerBase
    {
        private ICadreAppService _cadreAppService;
        ResponseOutputDto _response;

        public CadresController(ICadreAppService cadreAppService)
        {
            _cadreAppService = cadreAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateCadreDto createCadreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _cadreAppService.Add(createCadreDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _cadreAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _cadreAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCadreDto updateCadreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _cadreAppService.Update(id, updateCadreDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _cadreAppService.Delete(id);
            return Ok(_response);
        }
    }
}
