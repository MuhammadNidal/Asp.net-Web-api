using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Core.AccessManagment.Detail.Users;
using Fophex.Core.AccessManagment.Master.Role;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Detail
{
    // This class implements the IUserAppService interface and handles operations related to RoleRight.
    public class UserAppService : IUserAppService
    {
        private readonly FophexDbContext _dbContext; // Database context for interacting with the database.
        private readonly IMapper _mapper; // AutoMapper instance for object mapping.
        private readonly IUserRoleAppService _userRoleAppService;
        private ResponseOutputDto _response; // Response object to send back to the caller.

        // Constructor to initialize the UserAppService.
        public UserAppService(FophexDbContext dbContext,IUserRoleAppService userRoleAppService,IMapper mapper)
        {
            _dbContext = dbContext;
            _userRoleAppService = userRoleAppService;
            _mapper = mapper;
            _response = new ResponseOutputDto();
        }
        // Method to add a new User.
        public async Task<ResponseOutputDto> Add(CreateUserDto createUserDto)
        {
            var userEntity = _mapper.Map<User>(createUserDto); // Mapping DTO to entity.
            _dbContext.Add(userEntity); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync();
            var createUserRoleDtos = new List<CreateUserRoleDto>();
            foreach(var role in createUserDto.RoleIds)
            {
                var createUserRoleDto = new CreateUserRoleDto()
                {
                    UserId = userEntity.Id,
                    RoleId = role
                };
                createUserRoleDtos.Add(createUserRoleDto);
            }
            
            var userRole = await _userRoleAppService.AddRange(createUserRoleDtos);
            _response.Success(userEntity);
            return _response;
        }
        // Method to get all User.
        public async Task<ResponseOutputDto> GetAll()
        {
            var userEntities = await _dbContext.Users.ToListAsync(); // Retrieving all User from the database.
            _response.Success(userEntities);
            return _response;
        }
        // Method to get a User by its ID.
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var userEntity = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id); // Retrieving User by ID.
            if (userEntity != null)
            {
                _response.Success(userEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to update a user.
        public async Task<ResponseOutputDto> Update(long id, UpdateUserDto updateUserDto)
        {
            var userEntity = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id); // Retrieving user by ID.
            if (userEntity != null)
            {
                userEntity.FirstName = updateUserDto.FirstName; // Updating User firstname.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method to delete a user. 
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var userEntity = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id); // Retrieving user by ID.
            if (userEntity != null)
            {
                userEntity.IsDeleted = true; // Marking user as deleted.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
