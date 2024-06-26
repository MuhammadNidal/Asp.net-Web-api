using AutoMapper;
using Fophex.Application.Shared.Common.Dto;

using Fophex.EntityFrameworkCore;

using Fophex.Application.Shared.HumanResource.Master.VisaCategorys;
using Fophex.Core.HumanResource.Master.VisaCategorys;
using Fophex.Application.Shared.HumanResource.Master.VisaCategorys.Dto;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{
    public class VisaCategoryAppService : IVisaCategoryAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public VisaCategoryAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateVisaCategoryDto createVisaCategoryDto)
        {
            var visaCategoryEntity = _mapper.Map<VisaCategory>(createVisaCategoryDto);
            _dbContext.Add(visaCategoryEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(visaCategoryEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var visaCategoryEntity = await _dbContext.VisaCategorys.ToListAsync();
            _response.Success(visaCategoryEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var visaCategoryEntity = await _dbContext.VisaCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (visaCategoryEntity != null)
            {
                _response.Success(visaCategoryEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateVisaCategoryDto updateVisaCategoryDto)
        {
            var visaCategoryEntity = await _dbContext.VisaCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (visaCategoryEntity != null)
            {
                visaCategoryEntity!.Name = updateVisaCategoryDto.Name;
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
            var visaCategoryEntity = await _dbContext.VisaCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (visaCategoryEntity != null)
            {


                visaCategoryEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}