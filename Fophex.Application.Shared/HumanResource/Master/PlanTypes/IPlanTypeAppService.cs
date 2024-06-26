using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.PlanTypes
{
   

        public interface IPlanTypeAppService
        {
            public Task<ResponseOutputDto> Add(CreatePlanTypeDto createPlanTypeDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdatePlanTypeDto updatePlanTypeDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    
}
