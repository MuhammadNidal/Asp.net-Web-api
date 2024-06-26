using Fophex.Application.Shared.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.Categories.Dto
{
    public class GetByIdCategory : AuditedDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
