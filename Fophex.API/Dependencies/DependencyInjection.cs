using Fophex.Application;

using Fophex.Application.Shared.HumanResource.Master.TeamTypes;
using Fophex.Application.Accounts.Master.Categories;
using Fophex.Application.Shared.Accounts.Master.Categories;
using Fophex.Application.Shared.Tenant;
using Fophex.Application.Shared.Test;
using Fophex.Core.AccessManagment.Master.SubModules;
using Fophex.Core.Shared.Interfaces;
using Fophex.Core.Shared.Services;
using Fophex.Application.Shared.HumanResource.Master.Teams;
using Fophex.Application.HumanResourse.Master.Teams;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes;
using Fophex.Application.HumanResourse.Master.GroupTypes;
using Fophex.Application.Shared.HumanResource.Master.Groups;
using Fophex.Application.HumanResourse.Master.Groups;
using Fophex.Application.Shared.AccessManagement.Master.Forms;
using Fophex.Application.AccessManagment.Master;
using Fophex.Application.Shared.AccessManagement.Master.SubModules;
using Fophex.Application.Shared.AccessManagement.Master.Modules;
using Fophex.Application.Shared.Role;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Fophex.Application.Shared.HumanResource.Master.Designations;
using Fophex.Application.HumanResourse.Master.Designations;
using Fophex.Application.Shared.HumanResource.Master.Qualifications;
using Fophex.Application.HumanResourse.Master.Qualifications;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Fophex.Application.HumanResourse.Master;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles;
using Fophex.Application.AccessManagment.Detail;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights;
using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities;
using Fophex.Application.Shared.HumanResource.Master.PayGrades;
using Fophex.Application.Shared.Accounts.Master.Classifications;
using Fophex.Application.Accounts.Master.Classifications;
using Fophex.Application.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads;
using Fophex.Application.Accounts.Detail.AccountHeads;
using Fophex.Application.Accounts.Master.Sub_Categories;
using Fophex.Application.Shared.HumanResource.Master.VisaCategorys;
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys;
using Fophex.Application.Shared.HumanResource.Master.Trainers;
using Fophex.Application.Accounts.Detail.FinancialYears;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears;
using Fophex.Application.Shared.Accounts.Detail.Banks;
using Fophex.Application.Accounts.Detail.Banks;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes;
using Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses;
using Fophex.Application.Shared.Accounts.Detail.VoucherSettings;
using Fophex.Application.Accounts.Detail.VoucherSettings;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes;
using Fophex.Application.Accounts.Master.InstrumentTypes;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements;
using CategoryAppService = Fophex.Application.HumanResourse.Master.CategoryAppService;
using Fophex.Application.Shared.HumanResource.Master.Sections;
using Fophex.Application.Shared.Accounts.Master.SubCategories;
using Fophex.Application.Shared.AccessManagement.Detail.Auths;


namespace Fophex.API.Dependencies
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection collection)
        {
            collection.AddTransient<IConnectionString, ConnectionString>();
            //collection.AddTransient<IClaimsService, ClaimsService>();
            collection.AddTransient<IDateTimeService, DateTimeService>();


            collection.AddTransient<ITestAppService, TestAppService>();


            collection.AddTransient<ITeamTypeAppService, TeamTypeAppService>();

            collection.AddTransient<ITenantService, TenantService>();

            collection.AddTransient<IRoleAppService, RoleAppService>();

            collection.AddTransient<IModuleAppService, ModuleAppService>();

            collection.AddTransient<ISubModuleAppService, SubModuleAppService>();

            collection.AddTransient<IFormAppService, FormAppService>();

            collection.AddTransient<IRoleRightAppService, RoleRightAppService>();

            collection.AddTransient<ITeamAppService, TeamAppService>();
            collection.AddTransient<IGroupTypeAppService, GroupTypeAppService>();
            collection.AddTransient<IGroupAppService, GroupAppService>();

            collection.AddTransient<IDesignationAppServices, DesignationAppService>();

            collection.AddTransient<IQualificationAppService, qualificationAppService>();

            collection.AddTransient<ICadreAppService, CadreAppService>();



            collection.AddTransient<IUserAppService, UserAppService>();
            collection.AddTransient<IUserRoleAppService, UserRoleAppService>();
            collection.AddTransient<IBusinessActivityAppService, BusinessActivityAppService>();

            collection.AddTransient<IAuthAppService, AuthAppService>();

            collection.AddTransient<IPayGradeAppService, PayGradeAppService>();

            collection.AddTransient<ICategoryAppService, Application.Accounts.Master.Categories.CategoryAppService>();
            collection.AddTransient<ISubCategoryAppService, SubCategoryAppService>();
            collection.AddTransient<IClassificationAppService, ClassificationAppService>();
            collection.AddTransient<ISubClassificationAppService, SubClassificationAppService>();
            collection.AddTransient<IAccountHeadAppService, AccountHeadAppService>();
            collection.AddTransient<IFinancialYearAppService, FinancialYearAppService>();
            collection.AddTransient<IBankAppService, BankAppService>();
            collection.AddTransient<IVoucherSettingAppService, VoucherSettingAppService>();
            collection.AddTransient<IInstrumentTypeAppService, InstrumentTypeAppService>();

            collection.AddTransient<IVisaCategoryAppService, VisaCategoryAppService>();

            collection.AddTransient<IEmployeeCategoryAppService, EmployeeCategoryAppService>();

            collection.AddTransient<IBenefitCategoryAppService, BenefitCategoryAppService>();

            collection.AddTransient<ITrainerAppService, TrainerAppService>();
            collection.AddTransient<ITrainingTypeAppService, TrainingTypeAppService>();
            collection.AddTransient<ITrainingFundedByAppService, TrainingFundedByAppService>();

            collection.AddTransient<ITrainingLocationAppService, TrainingLocationAppService>();

            collection.AddTransient<ITravelClassAppService, TravelClassAppService>();

            collection.AddTransient<ITravelHotelAppService, TravelHotelAppService>();

            collection.AddTransient<IHiringTypeAppService, HiringTypeAppService>();

            collection.AddTransient<IPlanTypeAppService, PlanTypeAppService>();

            collection.AddTransient<IClubMembershipAppService, ClubMembershipAppService>();

            collection.AddTransient<INatureOfIncrementAppService, NatureOfIncrementAppService>();

            collection.AddTransient<ICategoryAppService, CategoryAppService>();
            collection.AddTransient<ISectionAppService, SectionAppService>();



        }
        
    }
}
/*
 * Singleton
Lifetime: The service is created once and shared across the entire application.
Use Case: Suitable for services that maintain state or perform expensive initialization. Example: Configuration services, logging services.
Implementation: The instance is created the first time it is requested and all subsequent requests use the same instance.
csharp
Copy code
services.AddSingleton<IMyService, MyService>();
Scoped
Lifetime: The service is created once per client request (or per scope).
Use Case: Suitable for services that should be unique per request but can be shared within a single request. Example: Database context in a web application.
Implementation: A new instance is created for each request and is shared within that request.
csharp
Copy code
services.AddScoped<IMyService, MyService>();
Transient
Lifetime: A new instance of the service is created each time it is requested.
Use Case: Suitable for lightweight, stateless services. Example: Small utility services.
Implementation: A new instance is created every time the service is requested.
csharp
Copy code
services.AddTransient<IMyService, MyService>();
Summary Table
Lifetime	Instance Creation	Use Case	Example
Singleton	Once per application	State maintenance, expensive init	Configuration services, logging services
Scoped	Once per request	Unique per request, shared in request	Database context in web apps
Transient	Each time requested	Lightweight, stateless	Small utility services
These lifetimes help manage resource usage and ensure that services are used appropriately within the application context.
 */