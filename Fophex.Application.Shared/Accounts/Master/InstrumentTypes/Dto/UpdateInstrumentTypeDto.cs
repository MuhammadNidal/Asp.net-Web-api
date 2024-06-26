using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.InstrumentTypes.Dto
{
    public class UpdateInstrumentTypeDto
    {
        [Required]
        public string Name { get; set; }
    }
}
