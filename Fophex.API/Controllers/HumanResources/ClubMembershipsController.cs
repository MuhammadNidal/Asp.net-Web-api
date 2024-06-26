using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Microsoft.AspNetCore.Mvc;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships.Dto;

namespace Fophex.API.Controllers.HumanResources
{

    [Route("api/hr/[controller]")]
    [ApiController]
    public class ClubMembershipsController : ControllerBase
    {
        private IClubMembershipAppService _clubMembershipAppService;
        ResponseOutputDto _response;

        public ClubMembershipsController(IClubMembershipAppService clubMembershipAppService)
        {
            _clubMembershipAppService = clubMembershipAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        [HttpPost]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> Add(CreateClubMembershipDto createClubMembershipDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _response = await _clubMembershipAppService.Add(createClubMembershipDto);
            return Ok(_response);
        }
        [HttpGet]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetAll()
        {
            _response = await _clubMembershipAppService.GetAll();
            return Ok(_response);
        }
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOutputDto))]
        public async Task<IActionResult> GetById(long id)
        {
            _response = await _clubMembershipAppService.GetById(id);
            return Ok(_response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateClubMembershipDto updateClubMembershipDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _response = await _clubMembershipAppService.Update(id, updateClubMembershipDto);
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            _response = await _clubMembershipAppService.Delete(id);
            return Ok(_response);
        }
    }
}
