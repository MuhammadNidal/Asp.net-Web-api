using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto
{
    public class GetAllUserRoleDto : AuditedDto
    {
        public long Id { get; set; }
        public long? TenantId { get; set; }
        public GetAllUserDto Users { get; set; }
    }
}
