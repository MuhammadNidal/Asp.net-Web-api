using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto
{
    public class GetAllRoleRightDto :AuditedDto
    {
        public long Id { get; set; }
        public bool IsAdd { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public long? TenantId { get; set; }
        public GetByIdFormDto Form { get; set; }
        public GetByIdRoleDto Role { get; set; }
        public GetAllRoleDto Roles { get; set; }
        //public List<GetAllRoleDto>? Roles { get; set; }
    }
}
