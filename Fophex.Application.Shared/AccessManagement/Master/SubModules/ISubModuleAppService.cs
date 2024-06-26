using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.SubModules
{
    public interface ISubModuleAppService
    {
        Task<ResponseOutputDto> Add(CreateSubModuleDto createSubModuleDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateSubModuleDto updateSubModuleDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
