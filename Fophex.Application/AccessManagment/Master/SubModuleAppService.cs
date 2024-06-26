using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.AccessManagement.Master.SubModules;
using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.AccessManagment.Master.SubModules;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Master
{
    // This class implements the ISubModuleAppService interface and handles operations related to Submodules.
    public class SubModuleAppService : ISubModuleAppService
    {
        private readonly FophexDbContext _dbContext; // Database context for interacting with the database.
        private readonly IMapper _mapper; // AutoMapper instance for object mapping.

        private ResponseOutputDto _response; // Response object to send back to the caller.

        // Constructor to initialize the SubModuleAppService.
        public SubModuleAppService(FophexDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto(); // Initializing the response object.
        }

        // Method to add a new Submodule.
        public async Task<ResponseOutputDto> Add(CreateSubModuleDto createSubModuleDto)
        {
            var submoduleEntity = _mapper.Map<SubModule>(createSubModuleDto); // Mapping DTO to entity.
            _dbContext.Add(submoduleEntity); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync(); // Saving changes to the database.
            _response.Success(submoduleEntity);
            return _response;
        }
        // Method to get all submodules.
        public async Task<ResponseOutputDto> GetAll()
        {
            var submoduleEntities = await _dbContext.SubModules.Include(row => row.Module)
                .Select(row => new GetAllSubModuleDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    Icon = row.Icon,
                    Sequence =row.Sequence,
                    TenantId =row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    Module = new GetAllModuleDto
                    {
                        Id = row.Module.Id,
                        Name = row.Module.Name,
                        Description = row.Module.Description,
                        Icon = row.Module.Icon,
                        Sequence = row.Module.Sequence,
                        CreatedBy = row.Module.CreatedBy,
                        CreatedDate = row.Module.CreatedDate,
                        UpdatedBy = row.Module.UpdatedBy,
                        UpdatedDate = row.Module.UpdatedDate,
                    }
                }) .ToListAsync(); // Retrieving all submodules from the database.
            _response.Success(submoduleEntities);
            return _response;
        }
        // Method to get a submodule by its ID.
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var submoduleEntity = await _dbContext.SubModules.Include(row => row.Module)
                .Select(row => new GetAllSubModuleDto
                {
                    Id = row.Id,
                    Name = row.Name,
                    Icon = row.Icon,
                    Sequence = row.Sequence,
                    TenantId = row.TenantId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                    Module = new GetAllModuleDto
                    {
                        Id = row.Module.Id,
                        Name = row.Module.Name,
                        Description = row.Module.Description,
                        Icon = row.Module.Icon,
                        Sequence = row.Module.Sequence,
                        CreatedBy = row.Module.CreatedBy,
                        CreatedDate = row.Module.CreatedDate,
                        UpdatedBy = row.Module.UpdatedBy,
                        UpdatedDate = row.Module.UpdatedDate,
                    }
                }).SingleOrDefaultAsync(x => x.Id == id); // Retrieving module by ID.
            if (submoduleEntity != null)
            {
                _response.Success(submoduleEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to update a submodule.
        public async Task<ResponseOutputDto> Update(long id, UpdateSubModuleDto updateSubModuleDto)
        {
            var submoduleEntity = await _dbContext.SubModules.SingleOrDefaultAsync(x => x.Id == id); // Retrieving submodule by ID.
            if (submoduleEntity != null)
            {
                submoduleEntity.Name = updateSubModuleDto.Name; // Updating submodule name.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to delete a submodule.
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var submoduleEntity = await _dbContext.SubModules.SingleOrDefaultAsync(x => x.Id == id); // Retrieving submodule by ID.
            if (submoduleEntity != null)
            {
                submoduleEntity.IsDeleted = true; // Marking submodule as deleted.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
