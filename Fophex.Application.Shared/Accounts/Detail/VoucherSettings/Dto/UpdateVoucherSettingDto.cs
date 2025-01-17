﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto
{
    public class UpdateVoucherSettingDto
    {
        [Required]
        public long CashHeadId { get; set; }

        [Required]
        public long BankHeadId { get; set; }

        public long? TenantId { get; set; }
    }
}
