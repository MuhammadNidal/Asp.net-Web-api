using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights;
using Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Core.AccessManagment.Detail.RoleRights;
using Fophex.Core.AccessManagment.Master.Forms;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Detail
{
    // This class implements the IRoleRightAppService interface and handles operations related to RoleRight.
    public class RoleRightAppService : IRoleRightAppService
    {
        private readonly FophexDbContext _dbContext; // Database context for interacting with the database.
        private readonly IMapper _mapper; // AutoMapper instance for object mapping.

        private ResponseOutputDto _response; // Response object to send back to the caller.
        // Constructor to initialize the ModuleAppService.
        public RoleRightAppService(FophexDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto(); // Initializing the response object.
        }
        // Method to add a new RoleRight.
        public async Task<ResponseOutputDto> Add(CreateRoleRightDto createRoleRightDto)
        {
            var roleRightEntity = _mapper.Map<RoleRight>(createRoleRightDto); // Mapping DTO to entity.
            _dbContext.Add(roleRightEntity); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync(); // Saving changes to the database.
            _response.Success(roleRightEntity);
            return _response;
        }
        // Method to get all roleRight.
        public async Task<ResponseOutputDto> GetAll()
        {
            var roleRightEntities = await _dbContext.RoleRights.Include(row => row.Form)
                .Select(row => new GetAllRoleRightDto
                {
                    Id = row.Id,
                    IsAdd = row.IsAdd,
                    IsUpdate = row.IsUpdate,
                    IsDelete = row.IsDelete,
                    IsView = row.IsView,
                    TenantId = row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    Form = new GetByIdFormDto
                    {
                        Id = row.Form.Id,
                        Name = row.Form.Name,
                        Url = row.Form.Url,
                        Sequence = row.Form.Sequence,
                        TenantId = row.Form.TenantId,
                        CreatedBy = row.Form.CreatedBy,
                        CreatedDate = row.Form.CreatedDate,
                        UpdatedBy = row.Form.UpdatedBy,
                        UpdatedDate = row.Form.UpdatedDate,
                    },
                    Role = new GetByIdRoleDto 
                    {
                        Id = row.Role.Id,
                        Name = row.Role.Name,
                        TenantId = row.Role.TenantId,
                        // Include other properties you need from the Role entity
                    }
                }).ToListAsync(); // Retrieving all RoleRight from the database.
            _response.Success(roleRightEntities);
            return _response;
        }
        // Method to get a roleRights by its ID.
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var roleRightEntity = await _dbContext.RoleRights.Include(row => row.Form)
                .Select(row => new GetAllRoleRightDto
                {
                    Id = row.Id,
                    IsAdd = row.IsAdd,
                    IsUpdate = row.IsUpdate,
                    IsDelete = row.IsDelete,
                    IsView = row.IsView,
                    TenantId = row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    Form = new GetByIdFormDto
                    {
                        Id = row.Form.Id,
                        Name = row.Form.Name,
                        Url = row.Form.Url,
                        Sequence = row.Form.Sequence,
                        TenantId = row.Form.TenantId,
                        CreatedBy = row.Form.CreatedBy,
                        CreatedDate = row.Form.CreatedDate,
                        UpdatedBy = row.Form.UpdatedBy,
                        UpdatedDate = row.Form.UpdatedDate,
                    },

                    Role = new GetByIdRoleDto
                    {
                        Id = row.Role.Id,
                        Name = row.Role.Name,
                        TenantId = row.Role.TenantId,
                        // Include other properties you need from the Role entity
                    }
                }).SingleOrDefaultAsync(x => x.Id == id); // Retrieving form by ID.
            if (roleRightEntity != null)
            {
                _response.Success(roleRightEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to get from a RoleRigts.
        public async Task<ResponseOutputDto> Update(long id, UpdateRoleRightDto updateRoleRightDto)
        {
            var roleRightEntity = await _dbContext.RoleRights.SingleOrDefaultAsync(x => x.Id == id); // Retrieving RoleRights by ID.
            if (roleRightEntity != null)
            {
                roleRightEntity.Id = updateRoleRightDto.Id; // Updating form name.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to delete a roleRights.
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var roleRightEntity = await _dbContext.RoleRights.FindAsync(id); // Retrieving RoleRights by ID.
            if (roleRightEntity != null)
            {
                roleRightEntity.IsDeleted = true; // Marking RoleRights as deleted.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
