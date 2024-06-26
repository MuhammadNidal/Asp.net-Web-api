using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.Forms.Dto
{
    public class UpdateFormDto
    {
        public required string Name { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
    }
}
