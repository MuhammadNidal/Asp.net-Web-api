﻿using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Cadres.Dto
{
    public class GetAllCadreDto : AuditedDto
    {
        public string Name { get; set; }
    }
}
