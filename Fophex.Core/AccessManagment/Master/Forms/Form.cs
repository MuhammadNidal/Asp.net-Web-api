using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Master.SubModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.Forms
{
    [Table(name: "Forms", Schema = "access_manag")]
    public class Form : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
        public long? TenantId { get; set; }
        // Foreign key property
        public long SubModuleId { get; set; }

        // Navigation property
        public SubModule? SubModule { get; set; }
        public ICollection<RoleRight> RoleRights { get; set; }
    }
}
