using Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.Classifications.Dto
{
    public class GetAllClassificationDto : AuditedDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public long? TenantId { get; set; }
        public List<GetAllSubClassificationDto> SubClassification { get; set; }
    }
}
