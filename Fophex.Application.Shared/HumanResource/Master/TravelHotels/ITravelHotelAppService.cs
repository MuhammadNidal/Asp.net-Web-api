using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TravelHotels
{
  
        public interface ITravelHotelAppService
        {
            public Task<ResponseOutputDto> Add(CreateTravelHotelDto createTravelHotelDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateTravelHotelDto updateTravelHotelDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

