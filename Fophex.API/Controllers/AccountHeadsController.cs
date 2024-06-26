using Fophex.Application.Accounts.Detail.AccountHeads;
using Fophex.Application.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/accountheads")]
    [ApiController]
    public class AccountHeadsController : ControllerBase
    {
        private readonly IAccountHeadAppService _accountheadAppService;
        ResponseOutputDto _response;
        public AccountHeadsController(IAccountHeadAppService accountheadAppService)
        {
            _accountheadAppService = accountheadAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

             }
        /// <summary>
        /// Create AccountHeadEntity
        /// </summary>
        /// <param name="createAccountHeadDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateAccountHeadDto createAccountHeadDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _accountheadAppService.Add(createAccountHeadDto);
            return Ok(_response);
        }

        /// <summary>
        /// Get all available AccountHead
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _accountheadAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single AccountHead by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _accountheadAppService.GetById(id);
            return Ok(_response);

        }

        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAccountHeadDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAccountHeadDto updateAccountHeadDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _accountheadAppService.Update(id, updateAccountHeadDto);
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
            _response = await _accountheadAppService.Delete(id);
            return Ok(_response);
        }

    }
}
