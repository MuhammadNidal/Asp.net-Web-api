using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements
{
  
        public interface INatureOfIncrementAppService
        {
            public Task<ResponseOutputDto> Add(CreateNatureOfIncrementDto createNatureOfIncrementDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateNatureOfIncrementDto updateNatureOfIncrementDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

