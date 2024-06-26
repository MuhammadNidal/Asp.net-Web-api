using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto
{
    public class GetByIdVoucherSettingDto : AuditedDto
    {
        public long CashHeadId { get; set; }
        public long BankHeadId { get; set; }
    }
}
