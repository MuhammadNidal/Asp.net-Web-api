using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;

using Fophex.Application.Shared.Test.Dto;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TeamTypes
{
    public interface ITeamTypeAppService
    {
        Task<ResponseOutputDto> Add(CreateTeamTypeDto createTeamTypeDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateTeamTypeDto updateTeamTypeDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
