using AutoMapper;
using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Cadres;
using Fophex.Application.Shared.HumanResource.Master.Cadres.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Core.HumanResource.Master.Cadres;
using Fophex.Core.HumanResource.Master.PayGrades;
using Fophex.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.HumanResourse.Master
{
    public class PayGradeAppService : IPayGradeAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public PayGradeAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreatePayGradeDto createPayGradeDto)
        {
            var payGradeEntity = _mapper.Map<PayGrade>(createPayGradeDto);
            _dbContext.Add(payGradeEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(payGradeEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var payGradeEntity = await _dbContext.PayGrades.ToListAsync();
            _response.Success(payGradeEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetById(long id)
        {
            var payGradeEntity = await _dbContext.PayGrades.SingleOrDefaultAsync(x => x.Id == id);
            if (payGradeEntity != null)
            {
                _response.Success(payGradeEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdatePayGradeDto updatePayGradeDto)
        {
            var payGradeEntity = await _dbContext.PayGrades.SingleOrDefaultAsync(x => x.Id == id);
            if (payGradeEntity != null)
            {
                payGradeEntity!.Name = updatePayGradeDto.Name;
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
            var payGradeEntity = await _dbContext.PayGrades.SingleOrDefaultAsync(x => x.Id == id);
            if (payGradeEntity != null)
            {


                payGradeEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }
}
