using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto
{
   public class CreateInstrumentTypeDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
