using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.HumanResource.Master.GroupTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fophex.Core.HumanResource.Master.Groups
{
    [Table(name: "Groups", Schema = "hr")]
    public class Group : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? TenantId { get; set; }
        public long GroupTypeId { get; set; }
        public GroupType GroupType { get; set; }
    }
}
