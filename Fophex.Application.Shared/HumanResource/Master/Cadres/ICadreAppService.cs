using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Qualifications.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Cadres
{
    public interface ICadreAppService
    {
        public Task<ResponseOutputDto> Add(CreateCadreDto CreateCadreDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateCadreDto UpdateCadreDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
