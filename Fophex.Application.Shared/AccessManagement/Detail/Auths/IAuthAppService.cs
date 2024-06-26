using Fophex.Application.Shared.AccessManagement.Detail.Auths.Dto;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.Auths
{
    public interface IAuthAppService
    {
      public  Task<ResponseOutputDto> Login(LoginUserAuthDto loginUserAuthDto);
    }
}
