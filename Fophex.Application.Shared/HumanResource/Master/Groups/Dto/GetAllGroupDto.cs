using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto;


namespace Fophex.Application.Shared.HumanResource.Master.Groups.Dto
{
    public class GetAllGroupDto : AuditedDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? TenantId { get; set; }
        public GetByIdGroupTypeDto GroupType { get; set; }
    }
}
