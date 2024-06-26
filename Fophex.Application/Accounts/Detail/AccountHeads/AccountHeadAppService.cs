using AutoMapper;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Detail.AccountHeads;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Detail.AccountHeads
{
    public class AccountHeadAppService : IAccountHeadAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;

        public AccountHeadAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public async Task<ResponseOutputDto> Add(CreateAccountHeadDto createAccountHeadDto)
        {

            var accountheadEntity = _mapper.Map<AccountHead>(createAccountHeadDto);
            _dbContext.Add(accountheadEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(accountheadEntity);
            return _response;

        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var accountheadEntities = await _dbContext.AccountHeads.Include(child => child.SubClassification).ToListAsync();
            _response.Success(accountheadEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var accountheadEntity = await _dbContext.AccountHeads.SingleOrDefaultAsync(x => x.Id == id);
            if (accountheadEntity != null)
            {
                _response.Success(accountheadEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateAccountHeadDto updateAccountHeadDto)
        {
            var accountheadEntity = await _dbContext.AccountHeads.FindAsync(id);
            if (accountheadEntity != null)
            {
                accountheadEntity!.Name = updateAccountHeadDto.Name;
                accountheadEntity!.Code = updateAccountHeadDto.Code;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(accountheadEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var accountheadEntity = await _dbContext.AccountHeads.FindAsync(id);
            if (accountheadEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(accountheadEntity);
                return _response;
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
                return _response;
            }
        }
    }
}
