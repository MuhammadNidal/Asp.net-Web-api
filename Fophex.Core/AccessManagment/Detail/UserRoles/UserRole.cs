using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.AccessManagment.Detail.Users;
using Fophex.Core.AccessManagment.Master.Forms;
using Fophex.Core.AccessManagment.Master.Role;
using Fophex.Core.AccessManagment.Master.SubModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Detail.UserRoles
{
    [Table(name: "UserRoles", Schema = "access_manag")]
    public class UserRole : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public long? TenantId { get; set; }

        // Foreign key property of user
        public long UserId { get; set; }
        public User? User { get; set; }

        // Foreign key property of role
        public long RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
