using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Tenant
{
    public interface ICurrentTenantService
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string ConnectionString { get; set; }


        public Task<bool> SetTenant(long tenantId);
        
    }
}