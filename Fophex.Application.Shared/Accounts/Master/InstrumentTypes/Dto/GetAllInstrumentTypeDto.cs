using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto
{
    public class GetAllInstrumentTypeDto : AuditedDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
