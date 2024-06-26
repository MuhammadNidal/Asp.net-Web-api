using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Tenant;
using Fophex.Application.Shared.Tenant.Dto;
using Fophex.Core.Tenant;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application
{
    public class TenantService : ITenantService
    {

        private readonly FophexDbContext _context; // database context
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        ResponseOutputDto _response;

        public TenantService(FophexDbContext context, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _context = context;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public  ResponseOutputDto CreateTenant(CreateTenantDto request)
        {

            string newConnectionString = null;
            if (request.Isolated == true)
            {
                // generate a connection string for new tenant database
                string dbName = "Fophex-" + request.Name;
                string defaultConnectionString = _configuration.GetConnectionString("DefaultConnection")!;
                newConnectionString = defaultConnectionString.Replace("Fophex", dbName);

                // create a new tenant database and bring current with any pending migrations from ApplicationDbContext
                try
                {
                    using IServiceScope scopeTenant = _serviceProvider.CreateScope();
                    ApplicationDbContext dbContext = scopeTenant.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    dbContext.Database.SetConnectionString(newConnectionString);
                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Applying ApplicationDB Migrations for New '{request.Name}' tenant.");
                        Console.ResetColor();
                        dbContext.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            Tenant tenant = new() // create a new tenant entity
            {
                Id = 0,
                Name = request.Name,
                Description = request.Description!,
                ConnectionString = newConnectionString,
            };
            //Tenant tenant = tenant;

            _context.Add(tenant);
            var result  = _context.SaveChanges();            
            _response.Success(tenant);
            return _response;
            
        }
      
    }
}
