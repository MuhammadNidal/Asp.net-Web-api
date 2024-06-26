using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.RoleRights
{
    public interface IRoleRightAppService
    {
        Task<ResponseOutputDto> Add(CreateRoleRightDto createRoleRightDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateRoleRightDto updateRoleRightDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
