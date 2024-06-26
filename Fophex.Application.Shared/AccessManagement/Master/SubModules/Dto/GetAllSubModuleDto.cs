using Fophex.Application.Shared.AccessManagement.Master.Forms.Dto;
using Fophex.Application.Shared.AccessManagement.Master.Modules.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto
{
    public class GetAllSubModuleDto : AuditedDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }

        public string Icon { get; set; }
      
        public int Sequence { get; set; }
        public long? TenantId { get; set; }
      
        public GetAllModuleDto Module { get; set; }
        public List<GetAllFormDto> Forms { get; set; }

    }
}
