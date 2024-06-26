using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.ClubMemberships.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Categorys
{

    public interface ICategoryAppService
    {
        Task<ResponseOutputDto> Add(CreateCategoryDto CreateCategoryDto);

        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(long id);
        Task<ResponseOutputDto> Update(long id, UpdateCategoryDto updateCategoryDto);
        Task<ResponseOutputDto> Delete(long id);
    }
}
