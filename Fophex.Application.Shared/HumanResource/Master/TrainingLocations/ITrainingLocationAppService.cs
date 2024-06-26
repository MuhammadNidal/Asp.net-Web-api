using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingLocations.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TrainingLocations
{
  
        public interface ITrainingLocationAppService
        {
            public Task<ResponseOutputDto> Add(CreateTrainingLocationDto createTrainingLocationDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateTrainingLocationDto updateTrainingLocationDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

