using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Tenant.Dto
{
    public class CreateTenantDto
    {        
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Isolated { get; set; }
    }
}
