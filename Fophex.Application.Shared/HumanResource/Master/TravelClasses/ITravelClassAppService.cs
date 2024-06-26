using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelClasses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TravelClasses
{
    
        public interface ITravelClassAppService
        {
            public Task<ResponseOutputDto> Add(CreateTravelClassDto createTravelClassDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateTravelClassDto updateTravelClassDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

