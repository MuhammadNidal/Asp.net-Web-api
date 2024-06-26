using Fophex.Core.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Shared.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public string GetClaim(string key)
        {
            string? value = null;
            var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            if (claimsIdentity == null || claimsIdentity.Claims.Count() <= 0)
            {
                value = "";
            }
            else
            {
                value = key == "Name" ? claimsIdentity.Name : claimsIdentity.Claims.First(claim => claim.Type == "Id").Value;
            }
            return value == null ? "" : value;

        }


    }
}
