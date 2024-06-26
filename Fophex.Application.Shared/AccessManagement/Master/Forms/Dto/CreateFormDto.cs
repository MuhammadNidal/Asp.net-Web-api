using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.Forms.Dto
{
    public class CreateFormDto 
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Url { get; set; }
        [Required]
        public int Sequence { get; set; }
        [Required]
        public long SubModuleId { get; set; }

  
    }
}
