using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.FinancialYears
{
    public interface IFinancialYearAppService
    {
        public Task<ResponseOutputDto> Add(CreateFinancialYearDto createFinancialYearDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateFinancialYearDto updateFinancialYearDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
