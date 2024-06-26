using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Detail.UserRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Detail.Users
{
    [Table(name: "Users", Schema = "access_manag")]
    public class User : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNumber { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public long? TenantId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
