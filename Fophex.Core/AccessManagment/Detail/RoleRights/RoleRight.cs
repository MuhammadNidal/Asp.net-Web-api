using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.AccessManagment.Master.Forms;
using Fophex.Core.AccessManagment.Master.Role;
using Fophex.Core.AccessManagment.Master.SubModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Detail.RoleRights
{
    [Table(name: "RoleRights", Schema = "access_manag")]
    public class RoleRight :AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public bool IsAdd { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public long? TenantId { get; set; }

        // Foreign key property of role
        public long RoleId { get; set; }
        public Role? Role { get; set; }

        // Foreign key property of form
        public long FormId { get; set; }
        public Form? Form { get; set; }

    }
}
