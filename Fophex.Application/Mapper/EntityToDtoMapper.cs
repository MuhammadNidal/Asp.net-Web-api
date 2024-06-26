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
using Fophex.Core.HumanResource.Master.GroupTypes;
using Fophex.Core.HumanResource.Master.Teams;
using Fophex.Core.HumanResource.Master.TeamTypes;
using Fophex.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Fophex.Core.AccessManagment.Detail.Users;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;

using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Core.Accounts.Master.Categories;
using Fophex.Core.Accounts.Master.Classifications;
using Fophex.Core.Accounts.Master.Sub_Categories;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.Core.AccessManagment.Master.BusinessActivities;
using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities.Dto;
using Fophex.Core.HumanResource.Master.Designations;
using Fophex.Application.Shared.HumanResource.Master.Designations.Dto;
using Fophex.Core.HumanResource.Master.Qualifications;
using Fophex.Application.Shared.HumanResource.Master.Qualifications.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.Core.HumanResource.Master.PayGrades;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Core.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;

using Fophex.Application.Shared.HumanResource.Master.VisaCategorys.Dto;
using Fophex.Core.HumanResource.Master.VisaCategorys;
using Fophex.Application.Shared.Accounts.Master.SubCategories.Dto;
using Fophex.Core.HumanResource.Master.EmployeeCategorys;
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys.Dto;
using Fophex.Core.HumanResource.Master.BenefitCategorys;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;
using Fophex.Core.HumanResource.Master.Trainers;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using Fophex.Core.HumanResource.Master.TrainingTypes;
using Fophex.Core.Accounts.Detail.FinancialYears;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto;
using Fophex.Core.Accounts.Detail.Banks;
using Fophex.Application.Shared.Accounts.Detail.Banks.Dto;
using Fophex.Core.HumanResource.Master.TrainingFundedBys;
using Fophex.Core.HumanResource.Master.TrainingLocations;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;
using Fophex.Core.HumanResource.Master.TravelClasss;
using Fophex.Core.Accounts.Detail.VoucherSettings;
using Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels.Dto;
using Fophex.Core.HumanResource.Master.TravelHotels;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto;
using Fophex.Core.HumanResource.Master.HiringTypes;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes.Dto;
using Fophex.Core.HumanResource.Master.PlanTypes;
using Fophex.Core.HumanResource.Master.ClubMemberships;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships.Dto;
using Fophex.Core.Accounts.Master.InstrumentTypes;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto;
using Fophex.Core.HumanResource.Master.NatureOfIncrements;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements.Dto;
using Fophex.Core.HumanResource.Master.Sections;
using Fophex.Application.Shared.HumanResource.Master.Sections.Dto;
using Fophex.Application.Shared.AccessManagement.Detail.Auths.Dto;

namespace Fophex.Application.Mapper
{
    public class EntityToDtoMapper : Profile
    {
        public EntityToDtoMapper()
        {
            CreateMap<Test, CreateTestDto>();
            CreateMap<Role, CreateRoleDto>();
            CreateMap<Module, CreateModuleDto>();
            CreateMap<SubModule, CreateSubModuleDto>();
            CreateMap<Form, CreateFormDto>();
            CreateMap<RoleRight, CreateRoleRightDto>();
            CreateMap<TeamType, CreateTeamTypeDto>();
            CreateMap<Team, CreateTeamDto>();
            CreateMap<GroupType, CreateGroupTypeDto>();
            CreateMap<Group, CreateGroupDto>();
            CreateMap<User, CreateUserDto>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<SubCategory, CreateSubCategoryDto>();
            CreateMap<Classification, CreateClassificationDto>();
            CreateMap<SubClassification, CreateSubClassificationDto>();
            CreateMap<BusinessActivity, CreateBusinessActivityDto>();
            CreateMap<AccountHead, CreateAccountHeadDto>();
            CreateMap<FinancialYear, CreateFinancialYearDto>();
            CreateMap<Bank, CreateBankDto>();
            CreateMap<VoucherSetting, CreateVoucherSettingDto>();
            CreateMap<InstrumentType, CreateInstrumentTypeDto>();


            CreateMap<Designation, CreateDesignationDto>();
            CreateMap<Qualification, CreateQualificationDto>();
            CreateMap<User, LoginUserAuthDto>();

            CreateMap<Cadre, CreateCadreDto>();
            CreateMap<PayGrade, CreatePayGradeDto>();
            CreateMap<VisaCategory, CreateVisaCategoryDto>();

            CreateMap<EmployeeCategory, CreateEmployeeCategoryDto>();

            CreateMap<BenefitCategory, CreateBenefitCategoryDto>();
            CreateMap<Trainer, CreateTrainerDto>();
            CreateMap<TrainingType, CreateTrainingTypeDto> ();
            CreateMap<TrainingFundedBy, CreateTrainingTypeDto>();

            CreateMap<TrainingLocation, CreateTrainingLocationDto>();

            CreateMap<TravelClass, CreateTravelClassDto>();
            CreateMap<TravelHotel, CreateTravelHotelDto>();

            CreateMap<HiringType, CreateHiringTypeDto>();

            CreateMap<PlanType, CreatePlanTypeDto>();

            CreateMap<ClubMembership, CreateClubMembershipDto>();

            CreateMap<NatureOfIncrement, CreateNatureOfIncrementDto>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Section, CreateSectionDto>();


        }
    }
}

