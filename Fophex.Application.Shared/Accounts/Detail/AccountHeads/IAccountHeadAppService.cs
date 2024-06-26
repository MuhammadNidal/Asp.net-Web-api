using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.AccountHeads
{
    public interface IAccountHeadAppService
    {
        public Task<ResponseOutputDto> Add(CreateAccountHeadDto createAccountHeadDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateAccountHeadDto updateAccountHeadDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
