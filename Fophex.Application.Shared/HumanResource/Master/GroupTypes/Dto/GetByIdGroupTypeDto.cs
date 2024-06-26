using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.GroupTypes.Dto
{
    public class GetByIdGroupTypeDto : AuditedDto
    {
        public string Name { get; set; }
    }
}
