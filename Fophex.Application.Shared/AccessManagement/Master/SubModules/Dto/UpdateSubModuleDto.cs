using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto
{
    public class UpdateSubModuleDto
    {
        public required string Name { get; set; }

        public string Icon { get; set; }

        public int Sequence { get; set; }

    }
}
