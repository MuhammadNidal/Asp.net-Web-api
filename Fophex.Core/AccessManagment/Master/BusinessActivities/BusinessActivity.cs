using Fophex.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.AccessManagment.Master.BusinessActivities
{
    [Table(name: "BusinessActivities",Schema = "access_manag")]
    public class BusinessActivity : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? TenantId { get; set; }
    }
}
