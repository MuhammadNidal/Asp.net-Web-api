using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Application.Shared.Test;
using Fophex.Application.Shared.Test.Dto;
using Fophex.Core.AccessManagment.Master.Role;
using Fophex.Core.Test;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Master
{
    // This class implements the IRoleAppService interface and handles operations related to roles.
    public class RoleAppService : IRoleAppService
    {
        private readonly FophexDbContext _dbContext; // Database context for interacting with the database.
        private readonly IMapper _mapper; // AutoMapper instance for object mapping.

        private ResponseOutputDto _response; // Response object to send back to the caller.

        // Constructor to initialize the RoleAppService.
        public RoleAppService(FophexDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto(); 
        }

        // Method to add a new role.
        public async Task<ResponseOutputDto> Add(CreateRoleDto createRoleDto)
        {
            var roleEntity = _mapper.Map<Role>(createRoleDto); // Mapping DTO to entity.
            _dbContext.Add(roleEntity); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync(); 
            _response.Success(roleEntity); 
            return _response; 
        }

        // Method to get all roles.
        public async Task<ResponseOutputDto> GetAll()
        {
            var roleEntities = await _dbContext.Roles.ToListAsync(); // Retrieving all roles from the database.
            _response.Success(roleEntities); 
            return _response; 
        }

        // Method to get a role by its ID.
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var roleEntity = await _dbContext.Roles.SingleOrDefaultAsync(x => x.Id == id); // Retrieving role by ID.
            if (roleEntity != null)
            {
                _response.Success(roleEntity); 
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}"); 
            }
            return _response; 
        }

        // Method to update a role.
        public async Task<ResponseOutputDto> Update(long id, UpdateRoleDto updateRoleDto)
        {
            var roleEntity = await _dbContext.Roles.SingleOrDefaultAsync(x => x.Id == id); // Retrieving role by ID.
            if (roleEntity != null)
            {
                roleEntity.Name = updateRoleDto.Name; // Updating role name.
                var result = await _dbContext.SaveChangesAsync(); 
                _response.Success(result.ToString()); 
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}"); 
            }
            return _response; 
        }

        // Method to delete a role.
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var roleEntity = await _dbContext.Roles.SingleOrDefaultAsync(x => x.Id == id); // Retrieving role by ID.
            if (roleEntity != null)
            {
                roleEntity.IsDeleted = true; // Marking role as deleted.
                var result = await _dbContext.SaveChangesAsync(); 
                _response.Success(result.ToString()); 
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}"); 
            return _response; 
        }
    }
}
