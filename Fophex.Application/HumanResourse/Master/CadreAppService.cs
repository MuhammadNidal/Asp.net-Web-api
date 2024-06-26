using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.Test;
using Fophex.Application.Shared.Test.Dto;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.Core.Test;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.HumanResourse.Master
{
    public class CadreAppService : ICadreAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public CadreAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateCadreDto createCadreDto)
        {
            var cadreEntity = _mapper.Map<Cadre>(createCadreDto);
            _dbContext.Add(cadreEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(cadreEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var cadreEntities = await _dbContext.Cadres.ToListAsync();
            _response.Success(cadreEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var cadreEntity = await _dbContext.Tests.SingleOrDefaultAsync(x => x.Id == id);
            if (cadreEntity != null)
            {
                _response.Success(cadreEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateCadreDto updateCadreDto)
        {
            var cadreEntity = await _dbContext.Cadres.SingleOrDefaultAsync(x => x.Id == id);
            if (cadreEntity != null)
            {
                cadreEntity!.Name = updateCadreDto.Name;
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
            var cadreEntity = await _dbContext.Cadres.SingleOrDefaultAsync(x => x.Id == id);
            if (cadreEntity != null)
            {


                cadreEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
