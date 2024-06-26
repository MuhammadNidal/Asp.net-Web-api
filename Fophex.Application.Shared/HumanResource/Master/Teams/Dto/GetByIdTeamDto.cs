using Fophex.Application.Shared.Common.Dto;
using Fophex.Application.Shared.HumanResource.Master.TeamTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Teams.Dto
{
    public class GetByIdTeamDto : AuditedDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? TenantId { get; set; }
        public GetByIdTeamTypeDto TeamType { get; set; }
    }
}
