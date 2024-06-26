using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys.Dto;
using Fophex.Application.Shared.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.EmployeeCategorys
{
   
        public interface IEmployeeCategoryAppService
        {
            public Task<ResponseOutputDto> Add(CreateEmployeeCategoryDto createEmployeeCategoryDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdateEmployeeCategoryDto updateEmployeeCategoryDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }
