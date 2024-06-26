using AutoMapper;
using Fophex.Application.Shared.Accounts.Master.Classifications;
using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;
using Fophex.Application.Shared.Accounts.Master.SubCategories.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Master.Classifications;
using Fophex.Core.Accounts.Master.Sub_Categories;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Master.Classifications
{
    public class ClassificationAppService : IClassificationAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;

        public ClassificationAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public async Task<ResponseOutputDto> Add(CreateClassificationDto createClassificationDto)
        {
            var classificationEntity = _mapper.Map<Classification>(createClassificationDto);
            _dbContext.Add(classificationEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(classificationEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var classificationEntity = await _dbContext.Classifications.FindAsync(id);
            if (classificationEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(classificationEntity);
                return _response;
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
                return _response;
            }
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var classificationEntities = await _dbContext.Classifications
                .Include(child => child.SubClassifications)
                .Select(fields => new GetAllClassificationDto
                {
                    Id = fields.Id,
                    Name = fields.Name,
                    Code = fields.Code,
                    TenantId = fields.TenantId,
                    CreatedBy = fields.CreatedBy,
                    UpdatedBy = fields.UpdatedBy,
                    UpdatedDate = fields.UpdatedDate,
                    SubClassification = fields.SubClassifications
                    .Select(sub => new GetAllSubClassificationDto
                    {
                        Id = sub.Id,
                        Name = sub.Name,
                        Code = sub.Code,
                        TenantId = sub.TenantId,
                        CreatedBy = sub.CreatedBy,
                        CreatedDate = sub.CreatedDate,
                        UpdatedBy = sub.UpdatedBy,
                        UpdatedDate = sub.UpdatedDate
                    }).ToList()
                }).ToListAsync();

            _response.Success(classificationEntities);
            return _response;
        }


        public async Task<ResponseOutputDto> GetById(long id)
        {
            var classificationEntity = await _dbContext.Classifications.SingleOrDefaultAsync(x => x.Id == id);
            if (classificationEntity != null)
            {
                _response.Success(classificationEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateClassificationDto updateClassificationDto)
        {
            var classificationEntity = await _dbContext.Classifications.FindAsync(id);
            if (classificationEntity != null)
            {
                classificationEntity!.Name = updateClassificationDto.Name;
                classificationEntity!.Code = updateClassificationDto.Code;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(classificationEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
    }
}
