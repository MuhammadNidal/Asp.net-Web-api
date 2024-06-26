using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Detail.Auths;
using Fophex.Application.Shared.AccessManagement.Detail.Auths.Dto;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Core.AccessManagment.Detail.UserRoles;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Detail
{
    public class AuthAppService : IAuthAppService
    {
        private readonly FophexDbContext _dbContext;
        private readonly IMapper _mapper;
        private ResponseOutputDto _response;
        public AuthAppService(FophexDbContext dbContext,  IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto();
        }
        
        public async Task<ResponseOutputDto> Login(LoginUserAuthDto loginUserAuthDto)
        {
            // Find the user with the provided email address
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == loginUserAuthDto.Email && u.Password == loginUserAuthDto.Password);

            // If user is not found or password doesn't match, return error response
            if (user == null)
            {
                _response.Error("Invalid email or password.");
                return _response;
            }
            _response.Success(user);
            return _response;
            //var moduleEntities = await _dbContext.Modules
            //    .Include(module => module.SubModules) // Include the SubModules
            //    .Select(module => new GetAllModuleDto
            //    {
            //        Id = module.Id,
            //        Name = module.Name,
            //        Description = module.Description,
            //        Icon = module.Icon,
            //        Sequence = module.Sequence,
            //        CreatedBy = module.CreatedBy,
            //        CreatedDate = module.CreatedDate,
            //        UpdatedBy = module.UpdatedBy,
            //        UpdatedDate = module.UpdatedDate,
            //        SubModules = module.SubModules.Select(subModule => new GetAllSubModuleDto
            //        {
            //            Id = subModule.Id,
            //            Name = subModule.Name,
            //            Icon = subModule.Icon,
            //            Sequence = subModule.Sequence,
            //            TenantId = subModule.TenantId,
            //            CreatedBy = subModule.CreatedBy,
            //            CreatedDate = subModule.CreatedDate,
            //            UpdatedBy = subModule.UpdatedBy,
            //            UpdatedDate = subModule.UpdatedDate,
            //            Forms = subModule.Forms.Select(form => new GetAllFormDto
            //            {
            //                Id = form.Id,
            //                Name = form.Name,
            //                Url = form.Url,
            //                Sequence = form.Sequence,
            //                TenantId = form.TenantId,
            //                CreatedBy = form.CreatedBy,
            //                CreatedDate = form.CreatedDate,
            //                UpdatedBy = form.UpdatedBy,
            //                UpdatedDate = form.UpdatedDate,
            //                RoleRights = form.RoleRights.Select(role => new GetAllRoleRightDto
            //                {
            //                    Id = role.Id,
            //                    IsAdd = role.IsAdd,
            //                    IsUpdate = role.IsUpdate,
            //                    IsDelete = role.IsDelete,
            //                    IsView = role.IsView,
            //                    TenantId = role.TenantId,
            //                    CreatedBy = role.CreatedBy,
            //                    CreatedDate = role.CreatedDate,
            //                    UpdatedBy = role.UpdatedBy,
            //                    UpdatedDate = role.UpdatedDate,
            //                    Roles = new GetAllRoleDto
            //                    {
            //                        Id = role.Role.Id,
            //                        Name = role.Role.Name,
            //                        TenantId = role.Role.TenantId,
            //                        CreatedBy = role.Role.CreatedBy,
            //                        CreatedDate = role.Role.CreatedDate,
            //                        UpdatedBy = role.Role.UpdatedBy,
            //                        UpdatedDate = role.Role.UpdatedDate,
            //                        UserRoles = role.Role.UserRoles.Select(userRole => new GetAllUserRoleDto 
            //                        {
            //                            Id = userRole.Id,
            //                            TenantId = userRole.TenantId,
            //                            CreatedBy = userRole.CreatedBy,
            //                            CreatedDate = userRole.CreatedDate,
            //                            UpdatedBy = userRole.UpdatedBy,
            //                            UpdatedDate = userRole.UpdatedDate,
            //                            Users = new GetAllUserDto 
            //                            {
            //                                Id = userRole.User.Id,
            //                                FirstName = userRole.User.FirstName,
            //                                LastName = userRole.User.LastName,
            //                                MobileNumber = userRole.User.MobileNumber,
            //                                Email = userRole.User.Email,
            //                                Password = userRole.User.Password,
            //                                TenantId = userRole.User.TenantId,
            //                                CreatedBy = userRole.User.CreatedBy,
            //                                CreatedDate = userRole.User.CreatedDate,
            //                                UpdatedBy = userRole.User.UpdatedBy,
            //                                UpdatedDate = userRole.User.UpdatedDate,
            //                            }
            //                        }).ToList()
            //                    } 
            //                    // Map properties of GetFormDto from Form entity
            //                }).ToList()
            //                // Map properties of GetFormDto from Form entity
            //            }).ToList()
            //        }).ToList()
            //    }).ToListAsync();

            // User is authenticated, return success response with submodule data

        }


    }
}
//var submoduleEntities = await _dbContext.Modules.Include(row => row.SubModules)
//               .Select(row => new GetAllModuleDto
//               {
//                   Id = row.Id,
//                   Name = row.Name,
//                   Description = row.Description,
//                   Icon = row.Icon,
//                   Sequence = row.Sequence,
//                   CreatedBy = row.CreatedBy,
//                   CreatedDate = row.CreatedDate,
//                   UpdatedBy = row.UpdatedBy,
//                   UpdatedDate = row.UpdatedDate,
//                   //SubModules = new List<GetAllSubModuleDto>()
//                   SubModules = Modules.SubModules.Select(subModule => new GetAllSubModuleDto
//                   {
//                       // Map properties of GetAllSubModuleDto from SubModule entity
//                       Id = subModule.Id,
//                       Name = subModule.Name,
//                       // Map other properties as needed
//                   }).ToList()

/*
            {
               Module: [
                   {
                       Id: 1,
                       Name: "Real Estate",
                       SubModule: [
                           {
                               Id: 1,
                               Name: "Real Estate",
                               Form: [

                               ]
                           },
                           {
                               Id: 1,
                               Name: "Real Estate"
                           }
                       ]
                   },
                   {
                       Id: 1,
                       Name: "Real Estate"
                   }
               ]
            }
            */
//var moduleEntities = await _dbContext.Modules.Include(row => row.SubModules)
//    .Select(row => new GetAllModuleDto()
//    {
//        Id= row.Id,

//        SubModules:row.sub
//    })
//    .ToListAsync();