using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fophex.API.Controllers.HumanResources
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class TeamTypesController : ControllerBase
    {
        private readonly ITeamTypeAppService _teamTypeAppService;

        public TeamTypesController(ITeamTypeAppService teamTypeAppService)
        {
            _teamTypeAppService = teamTypeAppService;
        }

        /// <summary>
        /// Create Team Type
        /// </summary>
        /// <param name="createTeamTypeDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateTeamTypeDto createTeamTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _teamTypeAppService.Add(createTeamTypeDto);
            return Ok(response);
        }

        /// <summary>
        /// Get All Team Types
        /// </summary>
        /// <returns>ResponseOutputDto</returns>
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _teamTypeAppService.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Get Team Type by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _teamTypeAppService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Update Team Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTeamTypeDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPut("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateTeamTypeDto updateTeamTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _teamTypeAppService.Update(id, updateTeamTypeDto);
            return Ok(response);
        }

        /// <summary>
        /// Delete Team Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpDelete("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _teamTypeAppService.Delete(id);
            return Ok(response);
        }
    }
}
