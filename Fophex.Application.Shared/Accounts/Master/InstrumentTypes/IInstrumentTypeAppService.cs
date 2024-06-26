using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.InstrumentTypes
{
    public interface IInstrumentTypeAppService
    {
        public Task<ResponseOutputDto> Add(CreateInstrumentTypeDto createInstrumentTypeDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateInstrumentTypeDto updateInstrumentTypeDto);
        public Task<ResponseOutputDto> Delete(long id);
       
    }
}
