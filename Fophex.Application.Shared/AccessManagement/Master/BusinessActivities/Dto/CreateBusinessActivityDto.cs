using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Master.BusinessActivities.Dto
{
    public class CreateBusinessActivityDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
