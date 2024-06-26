using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.HumanResource.Master.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.Trainers
{
    [Table(name: "Trainers", Schema = "hr")]
    public class Trainer : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? TenantId { get; set; }
    }
}
