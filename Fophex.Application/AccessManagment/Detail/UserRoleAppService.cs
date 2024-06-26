using AutoMapper;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles;
using Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.AccessManagment.Detail.UserRoles;
using Fophex.Core.AccessManagment.Detail.Users;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.AccessManagment.Detail
{
    public class UserRoleAppService : IUserRoleAppService
    {
        private readonly FophexDbContext _dbContext; // Database context for interacting with the database.
        private readonly IMapper _mapper; // AutoMapper instance for object mapping.

        private ResponseOutputDto _response; // Response object to send back to the caller.
        public UserRoleAppService(FophexDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto();
        }
        public async Task<ResponseOutputDto> Add(CreateUserRoleDto createUserRoleDto)
        {
            var userRoleEntity = _mapper.Map<UserRole>(createUserRoleDto); // Mapping DTO to entity.
            _dbContext.Add(userRoleEntity); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(userRoleEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> AddRange(List<CreateUserRoleDto> createUserRoleDtos)
        {
            var userRoleEntities = _mapper.Map<List<UserRole>>(createUserRoleDtos); // Mapping DTO to entity.
            _dbContext.AddRange(userRoleEntities); // Adding entity to the context.
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(userRoleEntities);
            return _response;
        }
    }
}
