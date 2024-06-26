using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Test.Dto;
using Fophex.Application.Shared.Test;
using Fophex.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application
{
    public class TestAppService : ITestAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public TestAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateTestDto createTestDto)
        {
            var testEntity = _mapper.Map<Test>(createTestDto);
            _dbContext.Add(testEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(result.ToString());
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var testEntities = await _dbContext.Tests.ToListAsync();
            _response.Success(testEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var testEntity = await _dbContext.Tests.SingleOrDefaultAsync(x => x.Id == id);
            if (testEntity != null)
            {
                _response.Success(testEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateTestDto updateTestDto)
        {
            var testEntity = await _dbContext.Tests.SingleOrDefaultAsync(x => x.Id == id);
            if (testEntity != null)
            {
                testEntity!.Name = updateTestDto.Name;
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
            var testEntity = await _dbContext.Tests.SingleOrDefaultAsync(x => x.Id == id);
            if (testEntity != null)
            {


                testEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
