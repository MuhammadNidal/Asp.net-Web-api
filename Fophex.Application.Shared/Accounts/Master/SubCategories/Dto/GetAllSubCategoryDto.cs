using Fophex.Application.Shared.Accounts.Master.Categories.Dto;
using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.SubCategories.Dto
{
    public class GetAllSubCategoryDto : AuditedDto
    {
        public long Id { get; set; }
        public  string Name { get; set; }
        public int Code { get; set; }
        public long? TenantId { get; set; }

        public GetAllCategoryDto Category { get; set; }
    }
}
