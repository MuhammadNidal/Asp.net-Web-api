using AutoMapper;
using Fophex.Application.Shared.Accounts.Detail.VoucherSettings;
using Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Detail.VoucherSettings;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Detail.VoucherSettings
{
    public class VoucherSettingAppService : IVoucherSettingAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public VoucherSettingAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public async Task<ResponseOutputDto> Add(CreateVoucherSettingDto createVoucherSettingDto)
        {
            var vouchersettingEntity = _mapper.Map<VoucherSetting>(createVoucherSettingDto);
            _dbContext.Add(vouchersettingEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(vouchersettingEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var vouchersettingEntities = await _dbContext.VoucherSettings.ToListAsync();
            _response.Success(vouchersettingEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var vouchersettingEntity = await _dbContext.VoucherSettings.SingleOrDefaultAsync(x => x.Id == id);
            if (vouchersettingEntity != null)
            {
                _response.Success(vouchersettingEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateVoucherSettingDto updateVoucherSettingrDto)
        {
            var vouchersettingEntity = await _dbContext.VoucherSettings.FindAsync(id);
            if (vouchersettingEntity != null)
            {
                vouchersettingEntity!.CashHeadId = updateVoucherSettingrDto.CashHeadId;
                vouchersettingEntity!.BankHeadId = updateVoucherSettingrDto.BankHeadId;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(vouchersettingEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var vouchersettingEntity = await _dbContext.VoucherSettings.FindAsync(id);
            if (vouchersettingEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(vouchersettingEntity);
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
