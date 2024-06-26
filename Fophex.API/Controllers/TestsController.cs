using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Test;
using Fophex.Application.Shared.Test.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        ITestAppService _testAppService;
        ResponseOutputDto _response;
        public TestsController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        /// <summary>
        /// Create Test Entity
        /// </summary>
        /// <param name="createTestDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateTestDto createTestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _testAppService.Add(createTestDto);
            return Ok(_response);
        }

        /// <summary>
        /// Get all available tests
        /// </summary>
        /// <returns>ResponseOutputDto List Object</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _testAppService.GetAll();
            return Ok(_response);

        }

        /// <summary>
        /// Get single test by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto single object</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _testAppService.GetById(id);
            return Ok(_response);

        }

        /// <summary>
        /// Update single provided entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTestDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTestDto updateTestDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _response = await _testAppService.Update(id, updateTestDto);
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
            _response = await _testAppService.Delete(id);
            return Ok(_response);
        }
    }
}
