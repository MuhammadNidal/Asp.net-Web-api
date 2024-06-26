using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Master.Forms;
using Fophex.Core.AccessManagment.Master.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.SubModules
{
    [Table(name: "SubModules", Schema = "access_manag")]
    public class SubModule : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
        public long? TenantId { get; set; }
        // Foreign key property
        public long ModuleId { get; set; }

        // Navigation property
        public Module? Module { get; set; }
        public ICollection<Form> Forms { get; set; }
    }
}
