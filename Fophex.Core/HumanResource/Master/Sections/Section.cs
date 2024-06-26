using Fophex.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.Sections
{
   
        [Table(name: "Sections", Schema = "hr")]
        public class Section : AuditedEntity, IMustHaveTenant
        {
            public long Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public long? TenantId { get; set; }
        }
    }
