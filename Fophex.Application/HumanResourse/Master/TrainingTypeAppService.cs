using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers;
using Fophex.Core.HumanResource.Master.Trainers;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using Fophex.Core.HumanResource.Master.TrainingTypes;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{

    public class TrainingTypeAppService : ITrainingTypeAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public TrainingTypeAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateTrainingTypeDto createTrainingTypeDto)
        {
            var TrainingTypeEntity = _mapper.Map<TrainingType>(createTrainingTypeDto);
            _dbContext.Add(TrainingTypeEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(TrainingTypeEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var TrainingTypeEntity = await _dbContext.TrainingTypes.ToListAsync();
            _response.Success(TrainingTypeEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var TrainingTypeEntity = await _dbContext.TrainingTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (TrainingTypeEntity != null)
            {
                _response.Success(TrainingTypeEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateTrainingTypeDto updateTrainingTypeDto)
        {
            var TrainingTypeEntity = await _dbContext.TrainingTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (TrainingTypeEntity != null)
            {
                TrainingTypeEntity!.Name = updateTrainingTypeDto.Name;
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
            var TrainingTypeEntity = await _dbContext.TrainingTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (TrainingTypeEntity != null)
            {


                TrainingTypeEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
