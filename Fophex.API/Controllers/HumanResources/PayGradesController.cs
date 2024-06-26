using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.PayGrades;
using Fophex.Application.HumanResourse.Master;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class PayGradesController : ControllerBase
    {
        private IPayGradeAppService _payGradeAppService;
        ResponseOutputDto _response;

        public PayGradesController(IPayGradeAppService payGradeAppService)
        {
            _payGradeAppService = payGradeAppService;
            if (_response == null)

            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreatePayGradeDto createPayGradeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _payGradeAppService.Add(createPayGradeDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _payGradeAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _payGradeAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePayGradeDto updatePayGradeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _payGradeAppService.Update(id, updatePayGradeDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _payGradeAppService.Delete(id);
            return Ok(_response);
        }
    }
}
