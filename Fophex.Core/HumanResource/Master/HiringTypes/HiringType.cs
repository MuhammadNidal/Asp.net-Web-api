using Fophex.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.HiringTypes
{
   
        [Table(name: "HiringTypes", Schema = "hr")]
        public class HiringType : AuditedEntity, IMustHaveTenant
        {
            public long Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public long? TenantId { get; set; }
        }
    }

