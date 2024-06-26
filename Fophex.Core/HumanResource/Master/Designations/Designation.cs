using Fophex.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.Designations
{
    [Table(name: "Designations", Schema = "hr")]
    public class Designation : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? TenantId { get; set; }
    }
}
