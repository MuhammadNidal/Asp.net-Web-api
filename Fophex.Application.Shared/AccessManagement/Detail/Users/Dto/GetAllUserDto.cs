using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto
{
    public class GetAllUserDto : AuditedDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public long? TenantId { get; set; }
    }
}
