using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.SubModules.Dto
{
    public class CreateSubModuleDto
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Icon { get; set; }
        [Required]
        public int Sequence { get; set; }
        [Required]
        public  long ModuleId { get; set; }
    }
}
