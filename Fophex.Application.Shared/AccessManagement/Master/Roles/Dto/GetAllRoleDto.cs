using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Role.Dto
{
    public class GetAllRoleDto : AuditedDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public long? TenantId { get; set; }
        public List<GetAllUserRoleDto>? UserRoles { get; set; }

    }
}
