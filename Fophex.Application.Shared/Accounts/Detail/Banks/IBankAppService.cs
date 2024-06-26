using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Detail.Banks.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.Banks
{
     public interface IBankAppService
    {
        public Task<ResponseOutputDto> Add(CreateBankDto createBankDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateBankDto updateBankDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
