using AutoMapper;
using Fophex.Application.Shared.Accounts.Detail.Banks;
using Fophex.Application.Shared.Accounts.Detail.Banks.Dto;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Detail.Banks;
using Fophex.Core.Accounts.Detail.FinancialYears;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Detail.Banks
{
    public class BankAppService : IBankAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public BankAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public async Task<ResponseOutputDto> Add(CreateBankDto createBankDto)
        {
            var bankEntity = _mapper.Map<Bank>(createBankDto);
            _dbContext.Add(bankEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(bankEntity);
            return _response;

        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var bankEntities = await _dbContext.Banks.ToListAsync();
            _response.Success(bankEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var bankEntity = await _dbContext.Banks.SingleOrDefaultAsync(x => x.Id == id);
            if (bankEntity != null)
            {
                _response.Success(bankEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateBankDto updateBankDto)
        {
            var bankEntity = await _dbContext.Banks.FindAsync(id);
            if (bankEntity != null)
            {
                bankEntity!.Name = updateBankDto.Name;
                bankEntity!.ShortName = updateBankDto.ShortName;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(bankEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var bankEntity = await _dbContext.Banks.FindAsync(id);
            if (bankEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(bankEntity);
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
