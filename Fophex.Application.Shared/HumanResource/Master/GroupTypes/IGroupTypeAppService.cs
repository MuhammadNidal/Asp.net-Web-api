using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.GroupTypes
{
    public interface IGroupTypeAppService
    {
        Task<ResponseOutputDto> Add(CreateGroupTypeDto createGroupTypeDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateGroupTypeDto updateGroupTypeDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
