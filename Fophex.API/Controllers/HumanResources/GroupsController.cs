
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.Groups.Dto;
using Fophex.Application.Shared.HumanResource.Master.Groups;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]

    public class GroupsController : ControllerBase
    {
        private readonly IGroupAppService _groupAppService;

        public GroupsController(IGroupAppService groupAppService)
        {
            _groupAppService = groupAppService;
        }
        /// Create Team Type
        /// </summary>
        /// <param name="createGroupDto"></param>
        /// <returns>ResponseOutputDto</returns>
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateGroupDto createGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _groupAppService.Add(createGroupDto);
            return Ok(response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _groupAppService.GetAll();
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
            var response = await _groupAppService.GetById(id);
            return Ok(response);
        }  /// <summary>
           /// Update Team Type
           /// </summary>
           /// <param name="id"></param>
           /// <param name="updateTeamDto"></param>
           /// <returns>ResponseOutputDto</returns>
        [HttpPut("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateGroupDto updateGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var response = await _groupAppService.Update(id, updateGroupDto);
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
            var response = await _groupAppService.Delete(id);
            return Ok(response);
        }

    }
}

