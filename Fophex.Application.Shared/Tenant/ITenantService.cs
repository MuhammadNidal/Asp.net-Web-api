using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Tenant.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Tenant
{
    public interface ITenantService
    {
        ResponseOutputDto CreateTenant(CreateTenantDto createTenantDto);
    }
}
