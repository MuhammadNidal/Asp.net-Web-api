﻿using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.Classifications.Dto
{
    public class GetByIdClassificationDto : AuditedDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}