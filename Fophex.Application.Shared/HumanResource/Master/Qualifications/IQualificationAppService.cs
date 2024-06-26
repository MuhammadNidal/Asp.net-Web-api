﻿using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.Qualifications.Dto;
using Fophex.Application.Shared.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Qualifications
{
    public interface IQualificationAppService
    {
        public Task<ResponseOutputDto> Add(CreateQualificationDto CreateQualificationDto);
        public Task<ResponseOutputDto> GetAll();
        public Task<ResponseOutputDto> GetById(long id);
        public Task<ResponseOutputDto> Update(long id, UpdateQualificationDto UpdateQualificationDto);
        public Task<ResponseOutputDto> Delete(long id);
    }
}
