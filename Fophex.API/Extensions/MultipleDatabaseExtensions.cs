using Fophex.Core.Tenant;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

namespace Fophex.API.Extensions
{
    public static class MultipleDatabaseExtensions
    {
        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services, IConfiguration configuration)
        {

            // Tenant Db Context (reference context) - get a list of tenants
            using IServiceScope scopeTenant = services.BuildServiceProvider().CreateScope();
            FophexDbContext tenantDbContext = scopeTenant.ServiceProvider.GetRequiredService<FophexDbContext>();

            if (tenantDbContext.Database.GetPendingMigrations().Any())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Applying Fophex Db Migrations.");
                Console.ResetColor();
                tenantDbContext.Database.Migrate(); // apply migrations on baseDbContext
            }
            using IServiceScope scopeApplication = services.BuildServiceProvider().CreateScope();
            ApplicationDbContext dbContext = scopeApplication.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //dbContext.Database.SetConnectionString(connectionString);
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                //Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine($"Applying Fophex Db Migrations.");
                //Console.ResetColor();
                //dbContext.Database.Migrate();

                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Applying Migrations for Fophex tenant.");
                    Console.ResetColor();
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"=========Fophex - Error==========");
                    Console.WriteLine($"Failed Migrations for Fophex. '{ex.Message}'");

                }
            }


            List<Tenant> tenantsInDb = tenantDbContext.Tenants.ToList();

            string defaultConnectionString = configuration.GetConnectionString("DefaultConnection")!; // read default connection string from appsettings.json

            foreach (Tenant tenant in tenantsInDb) // loop through all tenants, apply migrations on applicationDbContext
            {
                string connectionString = string.IsNullOrEmpty(tenant.ConnectionString) ? defaultConnectionString : tenant.ConnectionString;

                // Application Db Context (app - per tenant)
                //using IServiceScope scopeApplication = services.BuildServiceProvider().CreateScope();
                //ApplicationDbContext dbContext = scopeApplication.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.SetConnectionString(connectionString);
                
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Applying Migrations for '{tenant.Id}' tenant.");
                        Console.ResetColor();
                        dbContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"=========Error==========");
                        Console.WriteLine($"Failed Migrations for '{tenant.Id}' tenant. '{ex.Message}'");

                    }
                    
                }
            }

            return services;
        }

    }
}