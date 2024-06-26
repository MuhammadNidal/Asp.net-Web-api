using Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.Modules.Dto
{
    public class GetAllModuleDto : AuditedDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
        public long? TenantId { get; set; }
        public List<GetAllSubModuleDto> SubModules { get; set; }
    }
}
