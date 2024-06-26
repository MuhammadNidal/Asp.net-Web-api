using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Core.Accounts.Detail.AccountHeads;
using Fophex.Core.Accounts.Detail.Banks;
using Fophex.Core.Accounts.Detail.FinancialYears;
using Fophex.Core.Tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.VoucherSettings
{
    [Table(name: "VoucherSettings", Schema = "account")]
    public class VoucherSetting : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public long? CashHeadId { get; set; }
        public long BankHeadId { get; set; }
        public long? TenantId { get; set; }
        
      










    }
}
