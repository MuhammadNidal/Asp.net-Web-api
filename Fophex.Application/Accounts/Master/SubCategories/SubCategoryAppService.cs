using AutoMapper;
using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Accounts.Master.SubCategories;
using Fophex.Application.Shared.Accounts.Master.SubCategories.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Master.Categories;
using Fophex.Core.Accounts.Master.Sub_Categories;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Master.Sub_Categories
{
    public class SubCategoryAppService : ISubCategoryAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;

        public SubCategoryAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateSubCategoryDto createSubCategoryDto)
        {
            var subcategoryEntity = _mapper.Map<SubCategory>(createSubCategoryDto);
            _dbContext.Add(subcategoryEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(subcategoryEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var subcategoryEntities = await _dbContext.SubCategories.Include(row => row.Category)
                .Select(fields => new GetAllSubCategoryDto
                { 
                    Id = fields.Id,
                    Name = fields.Name,
                    Code = fields.Code,
                    TenantId = fields.TenantId,
                    CreatedBy = fields.CreatedBy,
                    CreatedDate = fields.CreatedDate,
                    UpdatedBy = fields.UpdatedBy,
                    UpdatedDate = fields.UpdatedDate,
                    Category = new GetAllCategoryDto
                    {
                        Id = fields.Category.Id,
                        Name = fields.Category.Name,
                        Code = fields.Category.Code,
                        TenantId = fields.Category.TenantId,
                        CreatedBy = fields.Category.CreatedBy,
                        CreatedDate  = fields.Category.CreatedDate,
                        UpdatedBy = fields.Category.UpdatedBy,
                        UpdatedDate = fields.Category.UpdatedDate
                    }

                }).ToListAsync();
            _response.Success(subcategoryEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var subcategoryEntity = await _dbContext.SubCategories.Select(fields => new GetAllSubCategoryDto
            {
                Id = fields.Id,
                Name = fields.Name,
                Code = fields.Code,
                TenantId = fields.TenantId,
                CreatedBy = fields.CreatedBy,
                CreatedDate = fields.CreatedDate,
                UpdatedBy = fields.UpdatedBy,
                UpdatedDate = fields.UpdatedDate,
                Category = new GetAllCategoryDto
                {
                    Id = fields.Category.Id,
                    Name = fields.Category.Name,
                    Code = fields.Category.Code,
                    TenantId = fields.Category.TenantId,
                    CreatedBy = fields.Category.CreatedBy,
                    CreatedDate = fields.Category.CreatedDate,
                    UpdatedBy = fields.Category.UpdatedBy,
                    UpdatedDate = fields.Category.UpdatedDate
                }

            }).SingleOrDefaultAsync();
            if (subcategoryEntity != null)
            {
                _response.Success(subcategoryEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateSubCategoryDto updateSubCategoryDto)
        {
            var subcategoryEntity = await _dbContext.SubCategories.FindAsync(id);
            if (subcategoryEntity != null)
            {
                subcategoryEntity!.Name = updateSubCategoryDto.Name;
                subcategoryEntity!.Code= updateSubCategoryDto.Code;
                subcategoryEntity!.CategoryId = updateSubCategoryDto.CategoryId;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(subcategoryEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Delete(long id)
        {
            var subcategoryEntity = await _dbContext.SubCategories.FindAsync(id);
            if (subcategoryEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(subcategoryEntity);
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
