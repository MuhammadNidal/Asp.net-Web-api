using Fophex.Application.Shared.Tenant;

namespace Fophex.API.Middleware
{
    public class TenantResolver
    {
        private readonly  RequestDelegate _next;
        public TenantResolver(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
        {
            context.Request.Headers.TryGetValue("tenantId", out var tenantIdFromHeader);
            if(string.IsNullOrEmpty(tenantIdFromHeader) == false)
            {
                await currentTenantService.SetTenant(Convert.ToInt64(tenantIdFromHeader));
            }
            
            await _next(context);
        }
    }
}
