using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Application.Shared.HumanResource.Master.Groups.Dto;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.Teams.Dto;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;
using Fophex.Application.Shared.Test.Dto;
using Fophex.Core.AccessManagment.Master.Forms;
using Fophex.Core.AccessManagment.Master.Modules;
using Fophex.Core.AccessManagment.Master.Role;
using Fophex.Core.AccessManagment.Master.SubModules;
using Fophex.Core.HumanResource.Master.Groups;
using Fophex.Core.HumanResource.Master.GroupTypes;
using Fophex.Core.HumanResource.Master.Teams;
using Fophex.Core.HumanResource.Master.TeamTypes;
using Fophex.Core.Test;
using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;

using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Core.Accounts.Master.Categories;
using Fophex.Core.Accounts.Master.Classifications;
using Fophex.Core.Accounts.Master.Sub_Categories;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.Core.HumanResource.Master.Designations;
using Fophex.Application.Shared.HumanResource.Master.Designations.Dto;
using Fophex.Core.HumanResource.Master.Qualifications;
using Fophex.Application.Shared.HumanResource.Master.Qualifications.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Core.AccessManagment.Detail.Users;
using Fophex.Core.AccessManagment.Detail.UserRoles;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Master.BusinessActivities;
using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities.Dto;
using Fophex.Core.HumanResource.Master.PayGrades;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Core.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;

using Fophex.Application.Shared.HumanResource.Master.VisaCategorys.Dto;
using Fophex.Core.HumanResource.Master.VisaCategorys;
using Fophex.Application.Shared.Accounts.Master.SubCategories.Dto;
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys.Dto;
using Fophex.Core.HumanResource.Master.EmployeeCategorys;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys.Dto;
using Fophex.Core.HumanResource.Master.BenefitCategorys;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;
using Fophex.Core.HumanResource.Master.Trainers;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using Fophex.Core.HumanResource.Master.TrainingTypes;
using Fophex.Core.Accounts.Detail.FinancialYears;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto;
using Fophex.Core.Accounts.Detail.Banks;
using Fophex.Application.Shared.Accounts.Detail.Banks.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys.Dto;
using Fophex.Core.HumanResource.Master.TrainingFundedBys;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations.Dto;
using Fophex.Core.HumanResource.Master.TrainingLocations;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;
using Fophex.Core.HumanResource.Master.TravelClasss;
using Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto;
using Fophex.Core.Accounts.Detail.VoucherSettings;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels.Dto;
using Fophex.Core.HumanResource.Master.TravelHotels;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto;
using Fophex.Core.HumanResource.Master.HiringTypes;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes.Dto;
using Fophex.Core.HumanResource.Master.PlanTypes;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships.Dto;
using Fophex.Core.HumanResource.Master.ClubMemberships;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto;
using Fophex.Core.Accounts.Master.InstrumentTypes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements.Dto;
using Fophex.Core.HumanResource.Master.NatureOfIncrements;
using Fophex.Application.Shared.HumanResource.Master.Sections.Dto;
using Fophex.Core.HumanResource.Master.Sections;
using Fophex.Application.Shared.AccessManagement.Detail.Auths.Dto;



namespace Fophex.Application.Mapper
{
    public class DtoToEntityMapper : Profile
    {
        public DtoToEntityMapper()
        {
            CreateMap<CreateTestDto, Test>();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateSubCategoryDto, SubCategory>();
            CreateMap<CreateClassificationDto, Classification>();
            CreateMap<CreateSubClassificationDto, SubClassification>();
            CreateMap<CreateAccountHeadDto, AccountHead>();
            CreateMap<CreateFinancialYearDto, FinancialYear>();
            CreateMap<CreateBankDto, Bank>();
            CreateMap<CreateVoucherSettingDto, VoucherSetting>();
            CreateMap<CreateInstrumentTypeDto, InstrumentType>();


            CreateMap<UpdateTestDto, Test>();

            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();




            CreateMap<CreateModuleDto, Module>();
            CreateMap<UpdateModuleDto, Module>();

            CreateMap<CreateSubModuleDto, SubModule>();
            CreateMap<UpdateSubModuleDto, SubModule>();

            CreateMap<CreateFormDto, Form>();
            CreateMap<UpdateFormDto, Form>();

            CreateMap<CreateRoleRightDto, RoleRight>();
            CreateMap<UpdateRoleRightDto, RoleRight>();

            CreateMap<CreateTeamTypeDto, TeamType>(); // Corrected here
            CreateMap<UpdateTeamTypeDto, TeamType>();

            CreateMap<CreateTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();

            CreateMap<CreateGroupTypeDto, GroupType>();

            CreateMap<UpdateGroupTypeDto, GroupType>();

            CreateMap<CreateGroupDto, Group>(); // Corrected here

            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<UpdateSubCategoryDto, SubCategory>();
            CreateMap<UpdateClassificationDto, Classification>();
            CreateMap<UpdateSubClassificationDto, SubClassification>();
            CreateMap<UpdateAccountHeadDto, AccountHead>();
            CreateMap<UpdateFinancialYearDto, FinancialYear>(); 
            CreateMap<UpdateBankDto, Bank>();
            CreateMap<UpdateVoucherSettingDto, VoucherSetting>();
            CreateMap< UpdateInstrumentTypeDto, InstrumentType>();

          
            CreateMap<UpdateGroupDto, Group>();

            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<CreateUserRoleDto, UserRole>();

            CreateMap<CreateDesignationDto, Designation>();
            CreateMap<UpdateDesignationDto, Designation>();
            CreateMap<CreateQualificationDto, Qualification>();
            CreateMap<UpdateQualificationDto, Qualification>();

            CreateMap<CreateCadreDto, Cadre>();
            CreateMap<UpdateCadreDto, Cadre>();


            CreateMap<CreatePayGradeDto, PayGrade>();
            CreateMap<UpdatePayGradeDto, PayGrade>();


            CreateMap<CreateVisaCategoryDto, VisaCategory>();
            CreateMap<UpdateVisaCategoryDto, VisaCategory>();

            CreateMap<CreateEmployeeCategoryDto, EmployeeCategory>();
            CreateMap<UpdateEmployeeCategoryDto, EmployeeCategory>();

            CreateMap<CreateBenefitCategoryDto, BenefitCategory>();
            CreateMap<UpdateBenefitCategoryDto, BenefitCategory>();


            CreateMap<CreateTrainerDto, Trainer>();
            CreateMap<UpdateTrainerDto, Trainer>();
            CreateMap<CreateTrainingTypeDto, TrainingType>();
            CreateMap<UpdateTrainingTypeDto, TrainingType>();

            CreateMap<CreateBusinessActivityDto, BusinessActivity>();
            CreateMap<UpdateBusinessActivityDto, BusinessActivity>();

            CreateMap<CreateTrainingFundedByDto, TrainingFundedBy>();
            CreateMap<UpdateTrainingFundedByDto, TrainingFundedBy>();
            CreateMap<CreateTrainingLocationDto, TrainingLocation>();
            CreateMap<CreateTravelClassDto, TravelClass>();
            CreateMap<UpdateTravelClassDto, TravelClass>();

            CreateMap<CreateTravelHotelDto, TravelHotel >();
            CreateMap<UpdateTravelHotelDto, TravelHotel>();

            CreateMap<CreateHiringTypeDto, HiringType>();
            CreateMap<UpdateHiringTypeDto, HiringType>();

            CreateMap<CreatePlanTypeDto, PlanType>();
            CreateMap<UpdatePlanTypeDto, PlanType>();
            CreateMap<CreateClubMembershipDto, ClubMembership>();
            CreateMap<UpdateClubMembershipDto, ClubMembership>();

            CreateMap<CreateNatureOfIncrementDto, NatureOfIncrement>();
            CreateMap<UpdateNatureOfIncrementDto, NatureOfIncrement>();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<CreateSectionDto, Section>();
            CreateMap<UpdateSectionDto, Section>();







            CreateMap<LoginUserAuthDto, User>();
        }
    }
}