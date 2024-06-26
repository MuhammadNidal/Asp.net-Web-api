using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.HumanResource.Master.TeamTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.HumanResource.Master.Teams
{

        [Table(name: "Teams", Schema = "hr")]
        public class Team : AuditedEntity, IMustHaveTenant
        {

          public long Id { get; set; }
            public required string Name { get; set; }
             public long? TenantId { get; set; }
             public long TeamTypeId { get; set; }
             public TeamType TeamType { get; set; }
    }
    
}
