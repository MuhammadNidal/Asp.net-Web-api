using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Master.Modules;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Core.AccessManagment.Master.Modules;
using Fophex.Core.AccessManagment.Master.Role;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Master
{
    // This class implements the IModuleAppService interface and handles operations related to modules.
    public class ModuleAppService : IModuleAppService
    {
        private readonly FophexDbContext _dbContext; // Database context for interacting with the database.
        private readonly IMapper _mapper; // AutoMapper instance for object mapping.

        private ResponseOutputDto _response; // Response object to send back to the caller.

        // Constructor to initialize the ModuleAppService.
        public ModuleAppService(FophexDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto(); // Initializing the response object.
        }

        // Method to add a new module.
        public async Task<ResponseOutputDto> Add(CreateModuleDto createModuleDto)
        {
            var moduleEntity = _mapper.Map<Module>(createModuleDto); // Mapping DTO to entity.
            _dbContext.Add(moduleEntity); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync(); // Saving changes to the database.
            _response.Success(moduleEntity); 
            return _response; 
        }

        // Method to get all modules.
        public async Task<ResponseOutputDto> GetAll()
        {
            var moduleEntities = await _dbContext.Modules.Include(row => row.SubModules).ToListAsync(); // Retrieving all modules from the database.
            _response.Success(moduleEntities); 
            return _response; 
        }

        // Method to get a module by its ID.
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var moduleEntity = await _dbContext.Modules.SingleOrDefaultAsync(x => x.Id == id); // Retrieving module by ID.
            if (moduleEntity != null)
            {
                _response.Success(moduleEntity); 
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}"); 
            }
            return _response; 
        }

        // Method to update a module.
        public async Task<ResponseOutputDto> Update(long id, UpdateModuleDto updateModuleDto)
        {
            var moduleEntity = await _dbContext.Modules.SingleOrDefaultAsync(x => x.Id == id); // Retrieving module by ID.
            if (moduleEntity != null)
            {
                moduleEntity.Name = updateModuleDto.Name; // Updating module name.
                var result = await _dbContext.SaveChangesAsync(); 
                _response.Success(result.ToString()); 
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}"); 
            }
            return _response; 
        }

        // Method to delete a module.
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var moduleEntity = await _dbContext.Modules.SingleOrDefaultAsync(x => x.Id == id); // Retrieving module by ID.
            if (moduleEntity != null)
            {
                moduleEntity.IsDeleted = true; // Marking module as deleted.
                var result = await _dbContext.SaveChangesAsync(); 
                _response.Success(result.ToString()); 
                return _response; 
            }
            _response.Invalid($"Entity not found for id {id}"); 
            return _response; 
        }
    }
}
