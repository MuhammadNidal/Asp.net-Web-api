using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Shared.Interfaces
{
    public interface IClaimsService
    {
        string GetClaim(string key);
    }
}
