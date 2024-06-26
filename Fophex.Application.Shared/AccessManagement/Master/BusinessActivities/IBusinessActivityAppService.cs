using Fophex.Application.Shared.AccessManagement.Master.BusinessActivities.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.BusinessActivities
{
    public interface IBusinessActivityAppService
    {

        public Task<ResponseOutputDto> Add(CreateBusinessActivityDto createBusinessActivityDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long  id);
        public Task<ResponseOutputDto> Update(long id, UpdateBusinessActivityDto updateBusinessActivityDto);
        public Task<ResponseOutputDto> Delete(long id);

    }
}
