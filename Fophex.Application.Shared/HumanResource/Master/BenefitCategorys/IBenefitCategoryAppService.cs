using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.BenefitCategorys
{
    
        public interface IBenefitCategoryAppService
        {
            public Task<ResponseOutputDto> Add(CreateBenefitCategoryDto createBenefitCategoryDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateBenefitCategoryDto updateBenefitCategoryDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    
}
