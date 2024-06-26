using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto
{
    public class GetByIdTeamTypeDto : AuditedDto
    {
        public required string Name { get; set; }
    }
}
