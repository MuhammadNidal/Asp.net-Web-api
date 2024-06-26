using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.Sections.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Sections
{
   
        public interface ISectionAppService
        {
            public Task<ResponseOutputDto> Add(CreateSectionDto createSectionDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateSectionDto updateSectionDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

