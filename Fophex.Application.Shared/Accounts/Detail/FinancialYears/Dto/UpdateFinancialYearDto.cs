using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto
{
   public class UpdateFinancialYearDto
    {
        [Required]
        public string Description { get; set; }
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public long TenantId { get; set; }
    }
}
