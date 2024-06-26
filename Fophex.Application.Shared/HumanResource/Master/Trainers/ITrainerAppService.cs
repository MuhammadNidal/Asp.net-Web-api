using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Trainers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Trainers
{
  
        public interface ITrainerAppService
        {
            public Task<ResponseOutputDto> Add(CreateTrainerDto createTrainerDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateTrainerDto updateTrainerDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

