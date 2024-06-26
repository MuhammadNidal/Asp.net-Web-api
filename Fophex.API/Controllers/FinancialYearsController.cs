using Fophex.Application.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/financialyears")]
    [ApiController]
    public class FinancialYearsController : ControllerBase
    {
        private readonly IFinancialYearAppService _financialyearAppService;
        ResponseOutputDto _response;
        public FinancialYearsController(IFinancialYearAppService financialyearAppService)
        {
            _financialyearAppService = financialyearAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }

        /// <summary>
        /// Create FinancialYearEntity
        /// </summary>
        /// <param name="createFinancialYearDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateFinancialYearDto createFinancialYearDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _financialyearAppService.Add(createFinancialYearDto);
            return Ok(_response);
        }



        /// <summary>
        /// Get all available financialyear
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _financialyearAppService.GetAll();
            return Ok(_response);

        }
        // method get by id financialyear
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _financialyearAppService.GetById(id);
            return Ok(_response);
        }

        /// method to upadte financialyear

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFinancialYearDto updateFinancialYearDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _financialyearAppService.Update(id, updateFinancialYearDto);
            return Ok(_response);
        }
        /// <summary>
        /// Delete single entity for the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _financialyearAppService.Delete(id);
            return Ok(_response);
        }
    }

}
