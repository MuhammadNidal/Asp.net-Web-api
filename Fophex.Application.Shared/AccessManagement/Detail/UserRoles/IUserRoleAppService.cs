using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.UserRoles
{
    public interface IUserRoleAppService
    {
        Task<ResponseOutputDto> Add(CreateUserRoleDto createUserRoleDto);
        Task<ResponseOutputDto> AddRange(List<CreateUserRoleDto> createUserRoleDtos);
    }
}
