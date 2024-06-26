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
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys;
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys.Dto;
using Fophex.Core.HumanResource.Master.EmployeeCategorys;
using Microsoft.EntityFrameworkCore;

namespace Fophex.Application.HumanResourse.Master
{

    public class EmployeeCategoryAppService : IEmployeeCategoryAppService
    {
        ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        ResponseOutputDto _response;
        public EmployeeCategoryAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            if (_response == null)
            {
                _response = new ResponseOutputDto();
            }
        }
        public async Task<ResponseOutputDto> Add(CreateEmployeeCategoryDto createEmployeeCategoryDto)
        {
            var EmployeeCategoryEntity = _mapper.Map<EmployeeCategory>(createEmployeeCategoryDto);
            _dbContext.Add(EmployeeCategoryEntity);
            var result = await _dbContext.SaveChangesAsync();
            _response.Success(EmployeeCategoryEntity);
            return _response;
        }
        public async Task<ResponseOutputDto> GetAll()
        {
            var EmployeeCategoryEntity = await _dbContext.EmployeeCategorys.ToListAsync();
            _response.Success(EmployeeCategoryEntity);
            return _response;
        }

        public async Task<ResponseOutputDto> GetById(long id)
        {
            var EmployeeCategoryEntity = await _dbContext.EmployeeCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (EmployeeCategoryEntity != null)
            {
                _response.Success(EmployeeCategoryEntity!);
            }
            else
            {
                _response.Invalid($"Entity not found for id {id}");
            }
            return _response;
        }
        public async Task<ResponseOutputDto> Update(long id, UpdateEmployeeCategoryDto updateEmployeeCategoryDto)
        {
            var EmployeeCategoryEntity = await _dbContext.EmployeeCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (EmployeeCategoryEntity != null)
            {
                EmployeeCategoryEntity!.Name = updateEmployeeCategoryDto.Name;
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
            var EmployeeCategoryEntity = await _dbContext.EmployeeCategorys.SingleOrDefaultAsync(x => x.Id == id);
            if (EmployeeCategoryEntity != null)
            {


                EmployeeCategoryEntity!.IsDeleted = true;
                var result = await _dbContext.SaveChangesAsync();
                _response.Success(result.ToString());
                return _response;
            }
            _response.Invalid($"Entity not found for id {id}");
            return _response;
        }
    }

}