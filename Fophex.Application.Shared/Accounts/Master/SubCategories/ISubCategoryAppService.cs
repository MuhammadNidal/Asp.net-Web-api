using Fophex.Application.Shared.Accounts.Master.SubCategories.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.SubCategories
{
     public interface ISubCategoryAppService
    {
        public Task<ResponseOutputDto> Add(CreateSubCategoryDto creatSubCategoryDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateSubCategoryDto updateSubCategoryDto);
        public Task<ResponseOutputDto> Delete(long id);

    }
}
