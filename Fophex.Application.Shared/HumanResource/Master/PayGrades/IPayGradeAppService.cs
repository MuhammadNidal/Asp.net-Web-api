using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.PayGrades.Dto;
using Fophex.Application.Shared.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.PayGrades
{
  
        public interface IPayGradeAppService
        {
            public Task<ResponseOutputDto> Add(CreatePayGradeDto createPayGradeDto);
            public Task<ResponseOutputDto> GetAll();
            public Task<ResponseOutputDto> GetById(long id);
            public Task<ResponseOutputDto> Update(long id, UpdatePayGradeDto updatePayGradeDto);
            public Task<ResponseOutputDto> Delete(long id);
        }
    }

