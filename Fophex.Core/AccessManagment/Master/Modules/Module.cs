using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.AccessManagment.Master.SubModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.Modules
{
    [Table(name: "Modules", Schema = "access_manag")]
    public class Module : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
        public long? TenantId { get; set; }
        public ICollection<SubModule> SubModules { get; set; }
    }
}
