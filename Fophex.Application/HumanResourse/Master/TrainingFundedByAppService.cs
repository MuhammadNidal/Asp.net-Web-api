using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys;
using Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys.Dto;

using Fophex.Core.HumanResource.Master.TrainingFundedBys;

using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Fophex.Application.HumanResourse.Master
{
    public class TrainingFundedByAppService : ITrainingFundedByAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        ResponseOutputDto _response;
        public TrainingFundedByAppService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if(_response == null)
            {
                _response = new ResponseOutputDto();    
            }            
        }
        public async Task<ResponseOutputDto> Add(CreateTrainingFundedByDto createTrainingFundedByDto)
        {
            var TrainingTypeEntity = _mapper.Map<TrainingFundedBy>(createTrainingFundedByDto);
            _dbContext.Add(TrainingTypeEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(TrainingTypeEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetaAll()
        {
            var TrainingFundedByEntity = await _dbContext.TrainingFundedBys.ToListAsync();
            _response.Success(TrainingFundedByEntity);
            return _response;
        }

        public  async Task<ResponseOutputDto> GetById(long id)
        {
            var TrainingFundedByEntity = await _dbContext.TrainingFundedBys.SingleOrDefaultAsync(x => x.Id == id);

            if (TrainingFundedByEntity != null)
            {
                _response.Success(TrainingFundedByEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
      
            public async Task<ResponseOutputDto> Update(long id, UpdateTrainingFundedByDto updateTrainingFundedByDto)
            {
                var TrainingFundedByEntity = await _dbContext.TrainingFundedBys.SingleOrDefaultAsync(x => x.Id == id);
                if (TrainingFundedByEntity != null)
                {
                TrainingFundedByEntity!.Name = updateTrainingFundedByDto.Name;
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
                var TrainingFundedByEntity = await _dbContext.TrainingFundedBys.SingleOrDefaultAsync(x => x.Id == id);
                if (TrainingFundedByEntity != null)
                {


                TrainingFundedByEntity!.IsDeleted = true;
                    var result = await _dbContext.SaveChangesAsync();
                    _response.Success(result.ToString());
                    return _response;
                }
                _response.Invalid($"Entity not found for id {id}");
                return _response;
            }

      
    }
    }
