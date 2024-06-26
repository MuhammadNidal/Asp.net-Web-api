using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.UserRoles
{
    public interface IUserAppService
    {
        Task<ResponseOutputDto> Add(CreateUserDto createUserRoleDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateUserDto updateUserRoleDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
