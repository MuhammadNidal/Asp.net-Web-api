using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades;
using Fophex.Core.HumanResource.Master.PayGrades;
using Fophex.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes;
using Fophex.Application.Shared.HumanResource.Master.PlanTypes.Dto;
using Fophex.Core.HumanResource.Master.PlanTypes;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{
   
        public class PlanTypeAppService : IPlanTypeAppService
    {
            ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            ResponseOutputDto _response;
            public PlanTypeAppService(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                if (_response == null)
                {
                    _response = new ResponseOutputDto();
                }
            }
            public async Task<ResponseOutputDto> Add(CreatePlanTypeDto createPlanTypeDto)
            {
                var PlanTypeEntity = _mapper.Map<PlanType>(createPlanTypeDto);
                _dbContext.Add(PlanTypeEntity);
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(PlanTypeEntity);
                return _response;
            }
            public async Task<ResponseOutputDto> GetAll()
            {
                var PlanTypeEntity = await _dbContext.PlanTypes.ToListAsync();
                _response.Success(PlanTypeEntity);
                return _response;
            }
            public async Task<ResponseOutputDto> GetById(long id)
            {
                var PlanTypeEntity = await _dbContext.PlanTypes.SingleOrDefaultAsync(x => x.Id == id);
                if (PlanTypeEntity != null)
                {
                    _response.Success(PlanTypeEntity!);
                }
                else
                {
                    _response.Invalid($"Entity not found for id {id}");
                }
                return _response;
            }
            public async Task<ResponseOutputDto> Update(long id, UpdatePlanTypeDto updatePlanTypeDto)
            {
                var PlanTypeEntity = await _dbContext.PlanTypes.SingleOrDefaultAsync(x => x.Id == id);
                if (PlanTypeEntity != null)
                {
                PlanTypeEntity!.Name = updatePlanTypeDto.Name;
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
                var PlanTypeEntity = await _dbContext.PlanTypes.SingleOrDefaultAsync(x => x.Id == id);
                if (PlanTypeEntity != null)
                {


                PlanTypeEntity!.IsDeleted = true;
                    var result = await _dbContext.SaveChangesAsync();
                    _response.Success(result.ToString());
                    return _response;
                }
                _response.Invalid($"Entity not found for id {id}");
                return _response;
            }
        }
}
