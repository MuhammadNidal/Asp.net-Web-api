using AutoMapper;
using Azure;
using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities;
using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Role.Dto;
using Fophex.Core.AccessManagment.Master.BusinessActivities;
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
    public class BusinessActivityAppService : IBusinessActivityAppService
    {
        private readonly FophexDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ResponseOutputDto _response;

        // Constructor
        public BusinessActivityAppService(FophexDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _response = new ResponseOutputDto();
        }
        // metho to add BusinessActivity new 

        public async Task<ResponseOutputDto> Add(CreateBusinessActivityDto createBusinessActivityDto)
        {
            var baEntity = _mapper.Map<BusinessActivity>(createBusinessActivityDto);
            _dbContext.Add(baEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(baEntity);
            return _response;
        }
        //Method to get all BusinessActivity 
        public async Task<ResponseOutputDto> GetAll()
        {
            var baEntity = await _dbContext.BusinessActivities.ToArrayAsync();
            _response.Success(baEntity);
            return _response;
        }
        //Method to get by id 
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var baEntity = await _dbContext.BusinessActivities.FindAsync(id);
            if(baEntity != null) { 
                _response.Success(baEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        // Method Update Business Activity
        public async Task<ResponseOutputDto> Update(long id, UpdateBusinessActivityDto updateBusinessActivityDto)
        {
            var baEntity = await _dbContext.BusinessActivities.FindAsync(id);
            if(baEntity != null)
            {
                baEntity.Name = updateBusinessActivityDto.Name; // Updating role name.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var baEntity = await _dbContext.BusinessActivities.FindAsync(id);
            if(baEntity != null)
            {
                baEntity.IsDeleted = true; // Marking role as deleted.
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }

    }
}
