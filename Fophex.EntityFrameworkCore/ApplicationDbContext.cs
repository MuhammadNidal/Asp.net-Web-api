  using Fophex.Application.Shared.Common.Interfaces;
using Fophex.Application.Shared.Tenant;
using Fophex.Core;
using Fophex.Core.HumanResource.Master.TeamTypes;
using Fophex.Core.Accounts.Master.Categories;
using Fophex.Core.Shared.Interfaces;
using Fophex.Core.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using Fophex.Core.HumanResource.Master.Teams;
using Fophex.Core.HumanResource.Master.GroupTypes;
using Fophex.Core.HumanResource.Master.Groups;
using System.Linq.Expressions;
using Fophex.Core.Accounts.Master.Sub_Categories;
using Fophex.Core.Accounts.Master.Classifications;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.Core.HumanResource.Master.Designations;
using Fophex.Core.HumanResource.Master.Qualifications;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.Core.HumanResource.Master.PayGrades;
using Fophex.Core.Accounts.Detail.AccountHeads;
using Fophex.Core.HumanResource.Master.VisaCategorys;
using Fophex.Core.Accounts.Detail.FinancialYears;
using Fophex.Core.HumanResource.Master.EmployeeCategorys;
using Fophex.Core.HumanResource.Master.BenefitCategorys;
using Fophex.Core.HumanResource.Master.Trainers;
using Fophex.Core.HumanResource.Master.TrainingTypes;
using Fophex.Core.HumanResource.Master.TrainingFundedBys;
using Fophex.Core.Accounts.Detail.Banks;
using Fophex.Core.Accounts.Detail.VoucherSettings;
using Fophex.Core.HumanResource.Master.TrainingLocations;
using Fophex.Core.HumanResource.Master.TravelClasss;
using Fophex.Core.HumanResource.Master.TravelHotels;
using Fophex.Core.Accounts.Master.InstrumentTypes;
using Fophex.Core.HumanResource.Master.HiringTypes;
using Fophex.Core.HumanResource.Master.PlanTypes;
using Fophex.Core.HumanResource.Master.ClubMemberships;
using Fophex.Core.HumanResource.Master.NatureOfIncrements;
using Fophex.Core.HumanResource.Master.Sections;


namespace Fophex.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentTenantService _currentTenantService;
        private readonly IDateTimeService _dateTimeService;
        public long CurrentTenantId { get; set; }
        public string CurrentTenantConnectionString { get; set; }


        // Constructor 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            ICurrentTenantService currentTenantService, 
            IDateTimeService dateTimeService) : base(options)
        {
            _currentTenantService = currentTenantService;
            CurrentTenantId = _currentTenantService.Id;
            CurrentTenantConnectionString = _currentTenantService.ConnectionString;
            _dateTimeService = dateTimeService;

        }
        
        public DbSet<Test> Tests { get; set; }
        public DbSet<TeamType> TeamTypes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }

        #region Accounts Entities
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<SubClassification> SubClassifications { get; set; }
        public DbSet<AccountHead> AccountHeads { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<VoucherSetting> VoucherSettings { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        #endregion
        public DbSet<Group> Groups { get; set; }
  

        public DbSet<Designation> Designations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Cadre> Cadres { get; set; }
        public DbSet<PayGrade> PayGrades { get; set; }
        public DbSet<VisaCategory> VisaCategorys { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategorys { get; set; }
        public DbSet<BenefitCategory> BenefitCategorys { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<TrainingFundedBy> TrainingFundedBys { get; set; }
        public DbSet<TrainingLocation> TrainingLocations { get; set; }
        public DbSet<TravelClass> TravelClasses{get; set; }
        public DbSet<TravelHotel> TravelHotels { get; set; }
        public DbSet<HiringType> HiringTypes { get; set; }
        public DbSet<PlanType> PlanTypes { get; set; }
        public DbSet<ClubMembership> ClubMemberships { get; set; }
        public DbSet<NatureOfIncrement> NatureOfIncrements { get; set; }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Section> Sections { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Test>().HasQueryFilter(row => row.TenantId == CurrentTenantId);
        //}
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string tenantConnectionString = CurrentTenantConnectionString;
            if (!string.IsNullOrEmpty(tenantConnectionString)) // use tenant db if one is specified
            {
                _ = optionsBuilder.UseSqlServer(tenantConnectionString);
            }
        }
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
