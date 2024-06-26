using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.AccountHeads.Dto
{
    public class CreateAccountHeadDto
    {
        [Required]
        [MaxLength(50)]
        public string  Name { get; set; }
        public int Code { get; set; }


        public decimal OpeningBalance { get; set; }
        public bool IsControlAccount { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }

        [Required]
        public long? SubClassificationId { get; set; }

    }
}
