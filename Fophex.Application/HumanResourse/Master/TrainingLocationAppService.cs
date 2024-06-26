using AutoMapper;
using Fophex.Application.Shared.Common.Dto;

using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Core.HumanResource.Master.TrainingLocations;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations.Dto;
using Microsoft.EntityFrameworkCore;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations;

namespace Fophex.Application.HumanResourse.Master
{
    
        public class TrainingLocationAppService : ITrainingLocationAppService
    {
            ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            ResponseOutputDto _response;
            public TrainingLocationAppService(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                if (_response == null)
                {
                    _response = new ResponseOutputDto();
                }
            }
        public  async Task<ResponseOutputDto> Add(CreateTrainingLocationDto createTrainingLocationDto)
        {
            var TrainingLocationEntity = _mapper.Map<TrainingLocation>(createTrainingLocationDto);
            _dbContext.Add(TrainingLocationEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(TrainingLocationEntity);
            return _response;
        }

        public async  Task<ResponseOutputDto> GetAll()
        {
            var TrainingLocationEntity = await _dbContext.TrainingLocations.ToListAsync();
            _response.Success(TrainingLocationEntity);
            return _response;
        }
       

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var TrainingLocationEntity = await _dbContext.TrainingLocations.SingleOrDefaultAsync(x => x.Id == id);

            if (TrainingLocationEntity != null)
            {
                _response.Success(TrainingLocationEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public  async Task<ResponseOutputDto> Update(long id, UpdateTrainingLocationDto updateTrainingLocationDto)
        {

            var TrainingLocationEntity = await _dbContext.TrainingLocations.SingleOrDefaultAsync(x => x.Id == id);
            if (TrainingLocationEntity != null)
            {
                TrainingLocationEntity!.Name = updateTrainingLocationDto.Name;
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
            var TrainingLocationEntity = await _dbContext.TrainingLocations.SingleOrDefaultAsync(x => x.Id == id);
            if (TrainingLocationEntity != null)
            {


                TrainingLocationEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }

     
    }
}
