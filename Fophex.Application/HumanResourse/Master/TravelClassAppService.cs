using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes;
using Fophex.Core.HumanResource.Master.TrainingTypes;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses;
using Fophex.Core.HumanResource.Master.TravelClasss;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;
using Microsoft.EntityFrameworkCore;


namespace Fophex.Application.HumanResourse.Master
{

    public class TravelClassAppService : ITravelClassAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public TravelClassAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateTravelClassDto createTravelClassDto)
        {
            var travelClassEntity = _mapper.Map<TravelClass>(createTravelClassDto);
            _dbContext.Add(travelClassEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(travelClassEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var travelClassEntity = await _dbContext.TravelClasses.ToListAsync();
            _response.Success(travelClassEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var travelClassEntity = await _dbContext.TravelClasses.SingleOrDefaultAsync(x => x.Id == id);
            if (travelClassEntity != null)
            {
                _response.Success(travelClassEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateTravelClassDto updateTravelClassDto)
        {
            var travelClassEntity = await _dbContext.TravelClasses.SingleOrDefaultAsync(x => x.Id == id);
            if (travelClassEntity != null)
            {
                travelClassEntity!.Name = updateTravelClassDto.Name;
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
            var travelClassEntity = await _dbContext.TravelClasses.SingleOrDefaultAsync(x => x.Id == id);
            if (travelClassEntity != null)
            {


                travelClassEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
