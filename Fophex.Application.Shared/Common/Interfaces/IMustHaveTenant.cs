using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Common.Interfaces
{
    public interface IMustHaveTenant
    {
        public long? TenantId { get; set; }
        
    }
}
