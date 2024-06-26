using Fophex.Application.Shared.Tenant;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application
{
    public class CurrentTenantService : ICurrentTenantService
    {
        private readonly FophexDbContext _context;
        public CurrentTenantService(FophexDbContext context)
        {
            _context = context;
        }


        public async Task<bool> SetTenant(long tenantId)
        {
            var tenantInfo = await _context.Tenants.Where(row => row.Id == tenantId).FirstOrDefaultAsync();
            if (tenantInfo != null)
            {
                Id = tenantInfo.Id;
                Name = tenantInfo.Name;
                Description = tenantInfo.Description;
                ConnectionString = tenantInfo.ConnectionString;
                return true;
            }
            else
            {
                throw new Exception("Tenant invalid");
            }
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ConnectionString { get; set; }
    }
}
