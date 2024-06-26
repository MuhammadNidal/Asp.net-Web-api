using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Application.Shared.HumanResource.Master.Sections;
using Fophex.Application.Shared.HumanResource.Master.Sections.Dto;
using Fophex.Core.HumanResource.Master.PayGrades;
using Fophex.Core.HumanResource.Master.Sections;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.HumanResourse.Master
{
    public class SectionAppService : ISectionAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public SectionAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateSectionDto createSectionDto)
        {
            var SectionEntity = _mapper.Map<Section>(createSectionDto);
            _dbContext.Add(SectionEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(SectionEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var SectionEntity = await _dbContext.Sections.ToListAsync();
            _response.Success(SectionEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var SectionEntity = await _dbContext.Sections.SingleOrDefaultAsync(x => x.Id == id);
            if (SectionEntity != null)
            {
                _response.Success(SectionEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateSectionDto updateSectionDto)
        {
            var SectionEntity = await _dbContext.Sections.SingleOrDefaultAsync(x => x.Id == id);
            if (SectionEntity != null)
            {
                SectionEntity!.Name = updateSectionDto.Name;
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
            var SectionEntity = await _dbContext.Sections.SingleOrDefaultAsync(x => x.Id == id);
            if (SectionEntity != null)
            {


                SectionEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    
}
}
