using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Application.Shared.Tenant;
using Fophex.Core;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Detail.UserRoles;
using Fophex.Core.AccessManagment.Detail.Users;
using Fophex.Core.AccessManagment.Master.BusinessActivities;
using Fophex.Core.AccessManagment.Master.Forms;
using Fophex.Core.AccessManagment.Master.Modules;
using Fophex.Core.AccessManagment.Master.Role;
using Fophex.Core.AccessManagment.Master.SubModules;
using Fophex.Core.Shared.Interfaces;
using Fophex.Core.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Fophex.EntityFrameworkCore
{
    public class FophexDbContext : DbContext
    {
        //private readonly ICurrentTenantService _currentTenantService = new ICure;
        private readonly IDateTimeService _dateTimeService;
        public long CurrentTenantId { get; set; }
        public string CurrentTenantConnectionString { get; set; }
        public FophexDbContext(DbContextOptions<FophexDbContext> options) : base(options)
        {


        }
        public FophexDbContext(DbContextOptions<FophexDbContext> options,
           //ICurrentTenantService currentTenantService,
           IDateTimeService dateTimeService) : base(options)
        {
            //_currentTenantService = currentTenantService;
           // CurrentTenantId = _currentTenantService.Id;
            //CurrentTenantConnectionString = _currentTenantService.ConnectionString;
            _dateTimeService = dateTimeService;

        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<SubModule> SubModules { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<RoleRight> RoleRights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<BusinessActivity> BusinessActivities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Expression<Func<AuditedEntity, bool>> filterExpr = bm => !bm.IsDeleted;
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                // check if current entity type is child of BaseModel
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(AuditedEntity)))
                {
                    // modify expression to handle correct child type
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);

                    // Check if entity implements IMustHaveTenant
                    var mustHaveTenantInterface = typeof(IMustHaveTenant);
                    if (mustHaveTenantInterface.IsAssignableFrom(mutableEntityType.ClrType))
                    {
                        // Access the TenantId property
                        var tenantIdProperty = mutableEntityType.ClrType.GetProperty("TenantId");

                        // Create expression for TenantId == CurrentTenantID, handling nullability
                        var tenantIdEqualExpr = Expression.Equal(
                            Expression.Property(parameter, tenantIdProperty),
                            Expression.Constant(CurrentTenantId, typeof(long?)));

                        // Combine with existing body or create new body if none exists
                        body = body != null
                            ? Expression.AndAlso(body, tenantIdEqualExpr)
                            : tenantIdEqualExpr;
                    }



                    var lambdaExpression = Expression.Lambda(body, parameter);

                    // set filter
                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }

            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                // check if current entity type is child of BaseModel
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(AuditedEntity)))
                {
                    // modify expression to handle correct child type
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                    // set filter
                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
        }

        // On Configuring -- dynamic connection string, fires on every request
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string tenantConnectionString = CurrentTenantConnectionString;
        //    if (!string.IsNullOrEmpty(tenantConnectionString)) // use tenant db if one is specified
        //    {
        //        _ = optionsBuilder.UseSqlServer(tenantConnectionString);
        //    }
        //}
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var loggedInUserId = 1; // _claimsService.GetClaim("Id") == "" ? 0 : Convert.ToInt64(_claimsService.GetClaim("Id"));
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<AuditedEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = loggedInUserId;
                    entry.Entity.CreatedDate = _dateTimeService == null ? DateTime.Now : _dateTimeService.Now;

                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.IsDeleted == true)
                    {
                        entry.Property("CreatedBy").IsModified = false;
                        entry.Property("UpdatedBy").IsModified = false;
                        entry.Property("CreatedDate").IsModified = false;
                        entry.Property("UpdatedDate").IsModified = false;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.UpdatedBy = loggedInUserId;
                        entry.Entity.DeletedDate = _dateTimeService == null ? DateTime.Now : _dateTimeService.Now;
                    }
                    else
                    {
                        entry.Property("CreatedBy").IsModified = false;
                        entry.Property("CreatedDate").IsModified = false;
                        entry.Entity.UpdatedBy = loggedInUserId;
                        entry.Entity.UpdatedDate = _dateTimeService == null ? DateTime.Now : _dateTimeService.Now;
                    }
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedBy = loggedInUserId;
                    entry.Entity.DeletedDate = _dateTimeService == null ? DateTime.Now : _dateTimeService.Now;
                }
            }
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = CurrentTenantId;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
