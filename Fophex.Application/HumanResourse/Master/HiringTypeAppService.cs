using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes;
using Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto;
using Fophex.Application.Shared.HumanResource.Master.TravelHotels.Dto;
using Fophex.Core.HumanResource.Master.HiringTypes;
using Fophex.Core.HumanResource.Master.TravelHotels;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.HumanResourse.Master
{
    public class HiringTypeAppService : IHiringTypeAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public HiringTypeAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateHiringTypeDto createHiringTypeDto)
        {
            var HiringTypeEntity = _mapper.Map<HiringType>(createHiringTypeDto);
            _dbContext.Add(HiringTypeEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(HiringTypeEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var HiringTypeEntity = await _dbContext.HiringTypes.ToListAsync();
            _response.Success(HiringTypeEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var HiringTypeEntity = await _dbContext.HiringTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (HiringTypeEntity != null)
            {
                _response.Success(HiringTypeEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateHiringTypeDto updateHiringTypeDto)
        {
            var HiringTypeEntity = await _dbContext.HiringTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (HiringTypeEntity != null)
            {
                HiringTypeEntity!.Name = updateHiringTypeDto.Name;
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
            var HiringTypeEntity = await _dbContext.HiringTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (HiringTypeEntity != null)
            {
                HiringTypeEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
