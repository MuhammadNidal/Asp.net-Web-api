using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.HiringTypes
{
  
        public interface IHiringTypeAppService
        {
            Task<ResponseOutputDto> Add(CreateHiringTypeDto createHiringTypeDto);
            Task<ResponseOutputDto> GetAll();
            Task<ResponseOutputDto> GetById(long id);
            Task<ResponseOutputDto> Update(long id, UpdateHiringTypeDto updateHiringTypeDto);
            Task<ResponseOutputDto> Delete(long id);
        }
    }

