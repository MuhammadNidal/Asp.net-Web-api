using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Groups.Dto;


namespace Fophex.Application.Shared.HumanResource.Master.Groups
{
    public interface IGroupAppService
    {
        Task<ResponseOutputDto> Add(CreateGroupDto createGroupDto);
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateGroupDto updateGroupDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}