﻿using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingTypes.Dto;
using Fophex.Application.Shared.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TrainingTypes
{
   
        public interface ITrainingTypeAppService
        {
            public Task<ResponseOutputDto> Add(CreateTrainingTypeDto createTrainingTypeDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateTrainingTypeDto updateTrainingTypeDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

