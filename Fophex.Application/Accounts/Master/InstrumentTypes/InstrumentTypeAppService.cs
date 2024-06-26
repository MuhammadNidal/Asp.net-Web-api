using AutoMapper;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes;
using Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Master.InstrumentTypes;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Master.InstrumentTypes
{
    public class InstrumentTypeAppService : IInstrumentTypeAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;

        public InstrumentTypeAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public async Task<ResponseOutputDto> Add(CreateInstrumentTypeDto createInstrumentTypeDto)
        {
            var instrumenttypeEntity = _mapper.Map<InstrumentType>(createInstrumentTypeDto);
            _dbContext.Add(instrumenttypeEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(instrumenttypeEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var instrumenttypeEntities = await _dbContext.InstrumentTypes.ToListAsync();
            _response.Success(instrumenttypeEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var instrumenttypeEntity = await _dbContext.InstrumentTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (instrumenttypeEntity != null)
            {
                _response.Success(instrumenttypeEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateInstrumentTypeDto updateInstrumentTypeDto)
        {
            var instrumenttypeEntity = await _dbContext.InstrumentTypes.FindAsync(id);
            if (instrumenttypeEntity != null)
            {
                instrumenttypeEntity!.Name = updateInstrumentTypeDto.Name;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(instrumenttypeEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var instrumenttypeEntity = await _dbContext.InstrumentTypes.FindAsync(id);
            if (instrumenttypeEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(instrumenttypeEntity);
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
