using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto
{
    public class GetAllFinancialYearDto : AuditedDto

    {
        public long Id { get; set; }
        public string  Description { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }



    }
}
