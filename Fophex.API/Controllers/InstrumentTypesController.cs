using Fophex.Application.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/instrumenttypes")]
    [ApiController]
    public class InstrumentTypesController : ControllerBase
    {
        private readonly IInstrumentTypeAppService _instrumenttypeAppService;
        ResponseOutputDto _response;
        public InstrumentTypesController(IInstrumentTypeAppService instrumenttypeAppService)
        {
            _instrumenttypeAppService = instrumenttypeAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }

        }

        /// <summary>
        /// Create InstrumentTypes Entity
        /// </summary>
        /// <param name="createInstrumentTypeDto"></param>
        /// <returns>ResponseOutputDto</returns>
        /// 
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateInstrumentTypeDto createInstrumentTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _instrumenttypeAppService.Add(createInstrumentTypeDto);

            return Ok(response);
        }

        /// <summary>
        /// Get all available  InstrumentTypes 
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _instrumenttypeAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single InstrumentTypes by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _instrumenttypeAppService.GetById(id);
            return Ok(_response);

        }
        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSubClassificationyDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateInstrumentTypeDto updateInstrumentTypeDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _instrumenttypeAppService.Update(id, updateInstrumentTypeDto);
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
            _response = await _instrumenttypeAppService.Delete(id);
            return Ok(_response);
        }
    }
}
