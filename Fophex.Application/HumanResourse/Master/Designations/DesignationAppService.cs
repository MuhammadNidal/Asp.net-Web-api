using AutoMapper;
using Azure;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Designations;
using Fophex.Application.Shared.HumanResource.Master.Designations.Dto;

using Fophex.Core.HumanResource.Master.Designations;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master.Designations
{
    public class DesignationAppService : IDesignationAppServices
    { 
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        ResponseOutputDto _response;
        public DesignationAppService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }


        public async Task<ResponseOutputDto> Add(CreateDesignationDto createDesignationDto)
        {
            var designationEntity = _mapper.Map<Designation>(createDesignationDto);
            _dbContext.Add(designationEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(designationEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var designationEntity = await _dbContext.Designations.ToListAsync();
                _response.Success(designationEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var designationEntity = await _dbContext.Designations.SingleOrDefaultAsync(x => x.Id == id);
            if (designationEntity != null)
            {
                _response.Success(designationEntity);
            }
            else
            {
                _response.Invalid($"The id is not found {id}");
            }
            return _response;
        }


        public async Task<ResponseOutputDto> Update(long id, UpdateDesignationDto updateDesignationDto)
        {
            var designationEntity = await _dbContext.Designations.SingleOrDefaultAsync(x=>x.Id == id); 
            if(designationEntity != null)
            {
                designationEntity!.Name= updateDesignationDto.Name;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"invalid id is {id}");

            }
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
         var designationEntity = await _dbContext.Designations.SingleOrDefaultAsync(x=>x.Id == id);
            if(designationEntity != null)
            {
                designationEntity!.IsDeleted = true;
                 var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            else
            {
                _response.Invalid($"the id is invalid {id}");
            }
            return _response;
        }
    }
}
