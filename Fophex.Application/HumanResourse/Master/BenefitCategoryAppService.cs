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
using Fophex.Core.HumanResource.Master.BenefitCategorys;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys.Dto;
using Microsoft.EntityFrameworkCore;
using Fophex.Application.Shared.HumanResource.Master.BenefitCategorys;

namespace Fophex.Application.HumanResourse.Master
{
   
        public class BenefitCategoryAppService : IBenefitCategoryAppService
    {
            ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            ResponseOutputDto _response;
            public BenefitCategoryAppService(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                if (_response == null)
                {
                    _response = new ResponseOutputDto();
                }
            }
            public async Task<ResponseOutputDto> Add(CreateBenefitCategoryDto createBenefitCategoryDto)
            {
                var BenefitCategoryEntity = _mapper.Map<BenefitCategory>(createBenefitCategoryDto);
                _dbContext.Add(BenefitCategoryEntity);
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(BenefitCategoryEntity);
                return _response;
            }
            public async Task<ResponseOutputDto> GetAll()
            {
                var BenefitCategoryEntity = await _dbContext.BenefitCategorys.ToListAsync();
                _response.Success(BenefitCategoryEntity);
                return _response;
            }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var BenefitCategoryEntity = await _dbContext.BenefitCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (BenefitCategoryEntity != null)
            {
                _response.Success(BenefitCategoryEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateBenefitCategoryDto updateBenefitCategoryDto)
        {
            var BenefitCategoryEntity = await _dbContext.BenefitCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (BenefitCategoryEntity != null)
            {
                BenefitCategoryEntity!.Name = updateBenefitCategoryDto.Name;
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
            var BenefitCategoryEntity = await _dbContext.BenefitCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (BenefitCategoryEntity != null)
            {


                BenefitCategoryEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
