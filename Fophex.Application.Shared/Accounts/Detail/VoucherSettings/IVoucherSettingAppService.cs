using Fophex.Application.Shared.Accounts.Detail.VoucherSettings.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.VoucherSettings
{
  public interface IVoucherSettingAppService
    {
        public Task<ResponseOutputDto> Add(CreateVoucherSettingDto createVoucherSettingDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateVoucherSettingDto updateVoucherSettingrDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
