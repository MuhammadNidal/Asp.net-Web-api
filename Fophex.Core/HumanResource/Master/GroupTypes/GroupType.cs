using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.HumanResource.Master.Groups;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fophex.Core.HumanResource.Master.GroupTypes
{
    [Table(name: "GroupTypes", Schema = "hr")]
    public class GroupType : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? TenantId { get; set; }
        public ICollection<Group> Groups { get; set; }  // Corrected property type
    }
}
