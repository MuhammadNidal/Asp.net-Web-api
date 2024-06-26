using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.TrainingFundedBys.Dto
{
    public class GetAllTrainingFundedByDto : AuditedDto
    {
        public required String Name { get; set; }
    }
}
