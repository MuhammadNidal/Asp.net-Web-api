using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.Forms.Dto
{
    public class GetAllFormDto :AuditedDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
        public long? TenantId { get; set; }
        public GetByIdSubModuleDto SubModule { get; set; }
        public List<GetAllRoleRightDto> RoleRights { get; set; }
    }
}
