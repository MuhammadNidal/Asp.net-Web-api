using AutoMapper;
using Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears;
using Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Detail.AccountHeads;
using Fophex.Core.Accounts.Detail.FinancialYears;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Detail.FinancialYears
{
   public class FinancialYearAppService : IFinancialYearAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;

        public FinancialYearAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public async Task<ResponseOutputDto> Add(CreateFinancialYearDto createFinancialYearDto)
        {
            var financialyearEntity = _mapper.Map<FinancialYear>(createFinancialYearDto);
            _dbContext.Add(financialyearEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(financialyearEntity);
            return _response;

        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var financialyearEntities = await _dbContext.FinancialYears.ToListAsync();
            _response.Success(financialyearEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var financialyearEntity = await _dbContext.FinancialYears.SingleOrDefaultAsync(x => x.Id == id);
            if (financialyearEntity != null)
            {
                _response.Success(financialyearEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateFinancialYearDto updateFinancialYearDto)
        {
            var financialyearEntity = await _dbContext.FinancialYears.FindAsync(id);
            if (financialyearEntity != null)
            {
                financialyearEntity!.Description = updateFinancialYearDto.Description;
                financialyearEntity!.FromDate = updateFinancialYearDto.FromDate;
                financialyearEntity!.ToDate = updateFinancialYearDto.ToDate;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(financialyearEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var financialyearEntity = await _dbContext.FinancialYears.FindAsync(id);
            if (financialyearEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(financialyearEntity);
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
