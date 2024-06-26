using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys
{
    public interface ITrainingFundedByAppService
    {
        public Task<ResponseOutputDto> Add(CreateTrainingFundedByDto createTrainingFundedByDto);
        public Task<ResponseOutputDto> GetaAll();

        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateTrainingFundedByDto updateTrainingFundedByDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
