 using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.SubClassifications
{
    public interface ISubClassificationAppService
    {
        public Task<ResponseOutputDto> Add(CreateSubClassificationDto createSubClassificationDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateSubClassificationDto updateSubClassificationDto);
        public Task<ResponseOutputDto> Delete(long id);
      
    }
}
