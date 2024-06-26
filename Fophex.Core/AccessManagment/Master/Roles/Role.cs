using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Detail.UserRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.Role
{
    [Table(name: "Roles", Schema = "access_manag")] 
    public class Role : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? TenantId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleRight> RoleRights { get; set; }
    }
}
