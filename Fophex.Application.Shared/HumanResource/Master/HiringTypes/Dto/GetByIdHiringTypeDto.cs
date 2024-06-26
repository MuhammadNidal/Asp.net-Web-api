using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.HiringTypes.Dto
{
   
        public class GetByIdHiringTypeDto : AuditedDto
        {
            public required string Name { get; set; }
        }
    }

