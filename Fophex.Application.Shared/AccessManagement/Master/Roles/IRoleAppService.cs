using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Role
{
    public interface IRoleAppService
    {
        Task<ResponseOutputDto> Add(CreateRoleDto createRoleDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateRoleDto updateRoleDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
