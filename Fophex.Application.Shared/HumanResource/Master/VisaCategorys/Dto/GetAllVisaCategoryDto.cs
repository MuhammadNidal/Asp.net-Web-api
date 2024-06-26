using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.VisaCategorys.Dto
{
    public class GetAllVisaCategoryDto : AuditedDto
    {
        public string Name { get; set; }
    }
}
