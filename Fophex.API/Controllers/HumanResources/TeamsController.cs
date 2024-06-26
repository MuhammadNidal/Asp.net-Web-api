using Fophex.Application;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams;
using Fophex.Application.Shared.HumanResource.Master.Teams.Dto;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamAppService _teamAppService;

        public TeamsController(ITeamAppService teamAppService)
        {
            _teamAppService = teamAppService;
        }

        /// <summary>
        /// Create Team Type
        /// </summary>
        /// <param name="createTeamDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateTeamDto createTeamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _teamAppService.Add(createTeamDto);
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
            var response = await _teamAppService.GetAll();
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
            var response = await _teamAppService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Update Team Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTeamDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPut("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateTeamDto updateTeamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _teamAppService.Update(id, updateTeamDto);
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
            var response = await _teamAppService.Delete(id);
            return Ok(response);
        }
    }
}



