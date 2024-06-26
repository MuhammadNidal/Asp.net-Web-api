using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Designations.Dto;
using Fophex.Application.Shared.HumanResource.Master.Designations;
using Fophex.Core.HumanResource.Master.Designations;
using Fophex.EntityFrameworkCore;
using Fophex.Application.Shared.HumanResource.Master.Qualifications;
using Fophex.Application.Shared.HumanResource.Master.Qualifications.Dto;
using Fophex.Core.HumanResource.Master.Qualifications;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master.Qualifications
{
    public class qualificationAppService : IQualificationAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        ResponseOutputDto _response;
        public qualificationAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }


        public async Task<ResponseOutputDto> Add(CreateQualificationDto CreateQualificationDto)
        {
            var qualificationtionEntity = _mapper.Map<Qualification>(CreateQualificationDto);
            _dbContext.Add(qualificationtionEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(qualificationtionEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var qualificationtionEntity = await _dbContext.Qualifications.ToListAsync();
            _response.Success(qualificationtionEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var qualificationtionEntity = await _dbContext.Qualifications.SingleOrDefaultAsync(x => x.Id == id);
            if (qualificationtionEntity! == null)
            {
                _response.Success(qualificationtionEntity!);
            }
            else
            {
                _response.Invalid($"The id is not found {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateQualificationDto UpdateQualificationDto)
        {
            var qualificationtionEntity = await _dbContext.Qualifications.SingleOrDefaultAsync(x => x.Id == id);
            if (qualificationtionEntity != null)
            {
                qualificationtionEntity!.Name = UpdateQualificationDto.Name;
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
            var qualificationtionEntity = await _dbContext.Qualifications.SingleOrDefaultAsync(x => x.Id == id);
            if (qualificationtionEntity != null)
            {
                qualificationtionEntity!.IsDeleted = true;
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
