using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.Accounts.Detail.AccountHeads;
using Fophex.Core.Accounts.Master.Classifications;
using Fophex.Core.Accounts.Master.Sub_Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Master.SubClassifications
{
    [Table(name: "SubClassifications", Schema = "account")]
    public class SubClassification : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public long? TenantId { get; set; }
        public long? ClassificationId { get; set; }
        public Classification Classification { get; set; }
        public ICollection<AccountHead> AccountHeads { get; set; }


    }
}
