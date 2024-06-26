using Fophex.Application.Shared.Common.Interfaces;

using System.ComponentModel.DataAnnotations.Schema;

namespace Fophex.Core.HumanResource.Master.Qualifications
{
    

        [Table(name: "Qualifications", Schema = "hr")]
        public class Qualification : AuditedEntity, IMustHaveTenant
        {
            public long Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public long? TenantId { get; set; }
        }
    }

