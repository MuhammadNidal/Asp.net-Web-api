using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.Accounts.Master.Categories;
using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Core.Accounts.Master.Categories;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{

    public class CategoryAppService : ICategoryAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public CategoryAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateCategoryDto createCategoryDto)
        {
            var CategoryEntity = _mapper.Map<Category>(createCategoryDto);
            _dbContext.Add(CategoryEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(CategoryEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var CategoryEntity = await _dbContext.Categorys.ToListAsync();
            _response.Success(CategoryEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var CategoryEntity = await _dbContext.Categorys.SingleOrDefaultAsync(x => x.Id == id);
            if (CategoryEntity != null)
            {
                _response.Success(CategoryEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateCategoryDto updateCategoryDto)
        {
            var CategoryEntity = await _dbContext.Categorys.SingleOrDefaultAsync(x => x.Id == id);
            if (CategoryEntity != null)
            {
                CategoryEntity!.Name = updateCategoryDto.Name;
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
            var CategoryEntity = await _dbContext.Categorys.SingleOrDefaultAsync(x => x.Id == id);
            if (CategoryEntity != null)
            {


                CategoryEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }

    }
}
