using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.Sections;
using Fophex.Application.Shared.HumanResource.Master.Sections.Dto;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private ISectionAppService _sectionAppService;
        ResponseOutputDto _response;

        public SectionsController(ISectionAppService sectionAppService)
        {
            _sectionAppService = sectionAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateSectionDto createSectionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _sectionAppService.Add(createSectionDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _sectionAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _sectionAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSectionDto updateSectionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _sectionAppService.Update(id, updateSectionDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _sectionAppService.Delete(id);
            return Ok(_response);
        }
    }
}
