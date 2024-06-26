using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.HumanResource.Master.Trainers;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;
using Fophex.Core.HumanResource.Master.Trainers;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{

        public class TrainerAppService : ITrainerAppService
        {
            ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            ResponseOutputDto _response;
            public TrainerAppService(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                if (_response == null)
                {
                    _response = new ResponseOutputDto();
                }
            }
            public async Task<ResponseOutputDto> Add(CreateTrainerDto createTrainerDto)
            {
                var TrainerEntity = _mapper.Map<Trainer>(createTrainerDto);
                _dbContext.Add(TrainerEntity);
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(TrainerEntity);
                return _response;
            }
            public async Task<ResponseOutputDto> GetAll()
            {
                var TrainerEntity = await _dbContext.Trainers.ToListAsync();
                _response.Success(TrainerEntity);
                return _response;
            }

            public async Task<ResponseOutputDto> GetById(long id)
            {
                var TrainerEntity = await _dbContext.Trainers.SingleOrDefaultAsync(x => x.Id == id);
                if (TrainerEntity != null)
                {
                    _response.Success(TrainerEntity!);
                }
                else
                {
                    _response.Invalid($"Entity not found for id {id}");
                }
                return _response;
            }
            public async Task<ResponseOutputDto> Update(long id, UpdateTrainerDto updateTrainerDto)
            {
                var TrainerEntity = await _dbContext.Trainers.SingleOrDefaultAsync(x => x.Id == id);
                if (TrainerEntity != null)
                {
                TrainerEntity!.Name = updateTrainerDto.Name;
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
                var TrainerEntity = await _dbContext.Trainers.SingleOrDefaultAsync(x => x.Id == id);
                if (TrainerEntity != null)
                {


                TrainerEntity!.IsDeleted = true;
                    var result = await _dbContext.SaveChangesAsync();
                    _response.Success(result.ToString());
                    return _response;
                }
                _response.Invalid($"Entity not found for id {id}");
                return _response;
            }
        }
}
