using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams.Dto;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;
using Fophex.Application.Shared.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Teams
{
    public interface ITeamAppService
    {
        Task<ResponseOutputDto> Add(CreateTeamDto createTeamDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateTeamDto updateTeamDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
