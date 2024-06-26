using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto;
using Azure;
using Fophex.Application.Shared.Test.Dto;
using Fophex.Application.HumanResourse.Master.Teams;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class GroupTypesController : ControllerBase
    {
        private readonly IGroupTypeAppService _grouptypeAppService;

        public GroupTypesController(IGroupTypeAppService grouptypeAppService)
        {
            _grouptypeAppService = grouptypeAppService;
        }

        /// <summary>
        /// Create Team Type
        /// </summary>
        /// <param name="createGroupTypeDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateGroupTypeDto createGroupTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _grouptypeAppService.Add(createGroupTypeDto);
            return Ok(response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _grouptypeAppService.GetAll();
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
            var response = await _grouptypeAppService.GetById(id);
            return Ok(response);
        }  /// <summary>
           /// Update Team Type
           /// </summary>
           /// <param name="id"></param>
           /// <param name="updateTeamDto"></param>
           /// <returns>ResponseOutputDto</returns>
        [HttpPut("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateGroupTypeDto updateGroupTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _grouptypeAppService.Update(id, updateGroupTypeDto);
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
            var response = await _grouptypeAppService.Delete(id);
            return Ok(response);
        }
    }
}


