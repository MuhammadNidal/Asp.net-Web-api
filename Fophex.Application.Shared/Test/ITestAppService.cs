using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Test
{
    public interface ITestAppService
    {
        public Task<ResponseOutputDto> Add(CreateTestDto createTestDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateTestDto updateTestDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
