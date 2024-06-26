using Fophex.Application.Shared.Tenant;
using Fophex.Application.Shared.Tenant.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fophex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public ITenantService TenantService { get; }

        // Create a new tenant
        [HttpPost]
        public IActionResult Post(CreateTenantDto request)
        {
            var result = _tenantService.CreateTenant(request);
            return Ok(result);
        }
    }
}
