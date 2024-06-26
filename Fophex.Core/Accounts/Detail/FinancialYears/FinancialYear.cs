using Fophex.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.FinancialYears
{
    [Table(name: "FinancialYears", Schema = "account")]

    public class FinancialYear : AuditedEntity , IMustHaveTenant
    {

        public long Id { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FromDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ToDate { get; set; }

        public bool IsClosed { get; set; }

        public long? TenantId { get; set; }
        //public IMustHaveTenant? Tenant { get; set; }


    }
}
