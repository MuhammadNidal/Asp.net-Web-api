using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Core.Shared.Services
{
    public class ConnectionString : Interfaces.IConnectionString
    {
        protected readonly IConfiguration _configuration;
        public ConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
            string connectionString = string.Empty;
            connectionString = _configuration["AppSettings:ConnectionString"]!.ToString();
            return connectionString;
        }
    }
}
