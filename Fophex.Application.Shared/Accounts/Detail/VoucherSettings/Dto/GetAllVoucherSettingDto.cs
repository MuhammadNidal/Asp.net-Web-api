using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto
{
   public class GetAllVoucherSettingDto : AuditedDto
    {
        public long Id { get; set; }
        public long CashHeadId { get; set; }
        public long BankHeadId { get; set; }
        public long TenantId { get; set; }

    }
}
