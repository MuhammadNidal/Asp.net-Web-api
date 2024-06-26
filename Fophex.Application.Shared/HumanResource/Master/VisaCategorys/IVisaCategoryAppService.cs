using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.VisaCategorys.Dto;
using Fophex.Application.Shared.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.VisaCategorys
{
    public interface IVisaCategoryAppService
    {
        public Task<ResponseOutputDto> Add(CreateVisaCategoryDto createVisaCategoryDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateVisaCategoryDto updateVisaCategoryDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
