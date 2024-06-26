using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.SubClassifications.Dto
{
   public class CreateSubClassificationDto
    {
        [Required]
        [MaxLength(50)]
        public string  Name { get; set; }

        
        public int Code { get; set; }

        [Required]
        public long? ClassificationId { get; set; }
    }
}
