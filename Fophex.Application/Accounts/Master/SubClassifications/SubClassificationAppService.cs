using AutoMapper;
using Fophex.Application.Shared.Accounts.Master.Classifications.Dto;
using Fophex.Application.Shared.Accounts.Master.SubClassifications;
using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Core.Accounts.Master.Classifications;
using Fophex.Core.Accounts.Master.SubClassifications;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Accounts.Master.SubClassifications
{
    public class SubClassificationAppService : ISubClassificationAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public SubClassificationAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }

        public async Task<ResponseOutputDto> Add(CreateSubClassificationDto createSubClassificationDto)
        {
            var subclassificationEntity = _mapper.Map<SubClassification>(createSubClassificationDto);
            _dbContext.Add(subclassificationEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(subclassificationEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetAll()
        {
            var subclassificationEntities = await _dbContext.SubClassifications.Include(child => child.Classification).ToListAsync();
            _response.Success(subclassificationEntities);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var subclassificationEntity = await _dbContext.SubClassifications.SingleOrDefaultAsync(x => x.Id == id);
            if (subclassificationEntity != null)
            {
                _response.Success(subclassificationEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Update(long id, UpdateSubClassificationDto updateSubClassificationDto)
        {
            var subclassificationEntity = await _dbContext.SubClassifications.FindAsync(id);
            if (subclassificationEntity != null)
            {
                subclassificationEntity!.Name = updateSubClassificationDto.Name;
                subclassificationEntity!.Code = updateSubClassificationDto.Code;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(subclassificationEntity);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }

        public async Task<ResponseOutputDto> Delete(long id)
        {
            var subclassificationEntity = await _dbContext.SubClassifications.FindAsync(id);
            if (subclassificationEntity != null)
            {
                //subcategoryEntity!.IsDeleted = false;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(subclassificationEntity);
                return _response;
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
                return _response;
            }
        }

        public Task<ResponseOutputDto> Add(CreateClassificationDto createClassificationDto)
        {
            throw new NotImplementedException();
        }
    }
}
