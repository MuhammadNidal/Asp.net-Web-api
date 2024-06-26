using Fophex.Application.Shared.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Accounts.Detail.Banks
{
    [Table(name: "Banks", Schema = "account")]

    public class Bank : AuditedEntity, IMustHaveTenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public long?  TenantId { get; set; }

        //public IMustHaveTenant? Tenant { get; set; }

    }
}
