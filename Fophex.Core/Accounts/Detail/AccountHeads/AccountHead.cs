using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.Accounts.Master.Categories;
using Fophex.Core.Accounts.Master.Sub_Categories;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.Core.Tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.AccountHeads
{
    [Table(name: "AccountHeads", Schema = "account")]
    public class AccountHead : AuditedEntity, IMustHaveTenant
    {
        public long  Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public decimal OpeningBalance { get; set; }
        public bool IsControlAccount { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }

        public long? TenantId { get; set; }
        //public Tenant? Tenant { get; set; }
        public long? SubClassificationId { get; set; }
        public SubClassification? SubClassification { get; set; }
        //public object SubClassification { get; internal set; }
    }
}
