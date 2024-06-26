using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes;
using Fophex.Core.HumanResource.Master.HiringTypes;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements;
using Fophex.Core.HumanResource.Master.NatureOfIncrements;
using Fophex.Application.Shared.HumanResource.Master.NatureOfIncrements.Dto;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{
   
        public class NatureOfIncrementAppService : INatureOfIncrementAppService
        {
            ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            ResponseOutputDto _response;
            public NatureOfIncrementAppService(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                if (_response == null)
                {
                    _response = new ResponseOutputDto();
                }
            }
            public async Task<ResponseOutputDto> Add(CreateNatureOfIncrementDto createNatureOfIncrementDto)
            {
                var NatureOfIncrementEntity = _mapper.Map<NatureOfIncrement>(createNatureOfIncrementDto);
                _dbContext.Add(NatureOfIncrementEntity);
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(NatureOfIncrementEntity);
                return _response;
            }
        public async Task<ResponseOutputDto> GetAll()
        {
            var NatureOfIncrementEntity = await _dbContext.NatureOfIncrements.ToListAsync();
            _response.Success(NatureOfIncrementEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var NatureOfIncrementEntity = await _dbContext.NatureOfIncrements.SingleOrDefaultAsync(x => x.Id == id);
            if (NatureOfIncrementEntity != null)
            {
                _response.Success(NatureOfIncrementEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateNatureOfIncrementDto updateNatureOfIncrementDto)
        {
            var NatureOfIncrementEntity = await _dbContext.NatureOfIncrements.SingleOrDefaultAsync(x => x.Id == id);
            if (NatureOfIncrementEntity != null)
            {
                NatureOfIncrementEntity!.Name = updateNatureOfIncrementDto.Name;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }

            return _response;
        }
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var NatureOfIncrementEntity = await _dbContext.NatureOfIncrements.SingleOrDefaultAsync(x => x.Id == id);
            if (NatureOfIncrementEntity != null)
            {
                NatureOfIncrementEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
