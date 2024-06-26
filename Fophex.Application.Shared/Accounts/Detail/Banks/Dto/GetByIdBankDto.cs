using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.Banks.Dto
{
    public class GetByIdBankDto : AuditedDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
