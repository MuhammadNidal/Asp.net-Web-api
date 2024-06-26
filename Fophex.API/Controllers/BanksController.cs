using Fophex.Application.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Detail.Banks;
using Fophex.Application.Shared.Accounts.Detail.Banks.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/banks")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankAppService _bankAppService;
        ResponseOutputDto _response;

        public BanksController(IBankAppService bankAppService)
        {
            _bankAppService = bankAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }

        /// <summary>
        /// Create BankEntity
        /// </summary>
        /// <param name="createBankDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateBankDto createBankDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _bankAppService.Add(createBankDto);
            return Ok(_response);
        }

        /// <summary>
        /// Get all available Bank
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _bankAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single Bank by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _bankAppService.GetById(id);
            return Ok(_response);

        }

        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateBankDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBankDto updateBankDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _bankAppService.Update(id, updateBankDto);
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
            _response = await _bankAppService.Delete(id);
            return Ok(_response);
        }
    }
}
