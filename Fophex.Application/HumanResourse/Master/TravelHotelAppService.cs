using AutoMapper;
using Fophex.Application.Shared.Common.Dto;

using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels.Dto;
using Fophex.Core.HumanResource.Master.TravelHotels;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{
    public class TravelHotelAppService : ITravelHotelAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public TravelHotelAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateTravelHotelDto createTravelHotelDto)
        {
            var travelHotelEntity = _mapper.Map<TravelHotel>(createTravelHotelDto);
            _dbContext.Add(travelHotelEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(travelHotelEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var travelHotelEntity = await _dbContext.TravelHotels.ToListAsync();
            _response.Success(travelHotelEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var travelHotelEntity = await _dbContext.TravelHotels.SingleOrDefaultAsync(x => x.Id == id);
            if (travelHotelEntity != null)
            {
                _response.Success(travelHotelEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateTravelHotelDto updateTravelHotelDto)
        {
            var travelHotelEntity = await _dbContext.TravelHotels.SingleOrDefaultAsync(x => x.Id == id);
            if (travelHotelEntity != null)
            {
                travelHotelEntity!.Name = updateTravelHotelDto.Name;
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
            var travelHotelEntity = await _dbContext.TravelHotels.SingleOrDefaultAsync(x => x.Id == id);
            if (travelHotelEntity != null)
            {
                travelHotelEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
