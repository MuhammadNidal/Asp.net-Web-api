using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.Modules
{
    public interface IModuleAppService
    {
        Task<ResponseOutputDto> Add(CreateModuleDto createModuleDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateModuleDto updateModuleDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
