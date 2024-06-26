using Fophex.Application.AccessManagment.Detail;
using Fophex.Application.Shared.AccessManagement.Detail.Auths;
using Fophex.Application.Shared.AccessManagement.Detail.Auths.Dto;
using Fophex.Application.Shared.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fophex.API.Controllers.AccessManagement
{
    [Route("api/access-manag/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthAppService _authAppService;
        ResponseOutputDto _response;


        public AuthsController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserAuthDto loginUserAuthDto)
        {
            var response = await _authAppService.Login(loginUserAuthDto);
            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
