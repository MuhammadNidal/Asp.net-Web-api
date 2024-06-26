using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Categorys.Dto
{
  
        public class CreateCategoryDto
        {
            [Required]
            [MinLength(3)]
            [MaxLength(50)]
            public string Name { get; set; }
        }
    }
