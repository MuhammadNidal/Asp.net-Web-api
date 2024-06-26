using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.HumanResource.Master.Trainers.Dto
{
   
        public class CreateTrainerDto
    {
            [Required]
            [MinLength(3)]
            [MaxLength(50)]
            public required string Name { get; set; }
        }
    }

