using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.Banks.Dto
{
   public class CreateBankDto
    {
        [Required]
        [MaxLength(50)]
        public string  Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string  ShortName { get; set; }


        [Required]
        public long? TenantId { get; set; }
    }
}
