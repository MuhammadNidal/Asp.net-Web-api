using Fophex.Application.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.VoucherSettings;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto;

namespace Fophex.API.Controllers
{
    [Route("api/vouchersettings")]
    [ApiController]
    public class VoucherSettingsController : ControllerBase
    {
        private readonly IVoucherSettingAppService _vouchersettingAppService;
        ResponseOutputDto _response;
        public VoucherSettingsController(IVoucherSettingAppService vouchersettingAppService)
        {
            _vouchersettingAppService = vouchersettingAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }
        /// <summary>
        /// Create VoucherSettingEntity
        /// </summary>
        /// <param name="createVoucherSettingDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateVoucherSettingDto createVoucherSettingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _vouchersettingAppService.Add(createVoucherSettingDto);
            return Ok(_response);
        }

        /// <summary>
        /// Get all available  VoucherSetting
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _vouchersettingAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single VoucherSetting by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _vouchersettingAppService.GetById(id);
            return Ok(_response);

        }

        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateVoucherSettingDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateVoucherSettingDto updateVoucherSettingDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _vouchersettingAppService.Update(id, updateVoucherSettingDto);
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
            _response = await _vouchersettingAppService.Delete(id);
            return Ok(_response);
        }
    }
}
