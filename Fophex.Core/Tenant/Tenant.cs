using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fophex.Core.Accounts.Detail.AccountHeads;

namespace Fophex.Core.Tenant
{
    public class Tenant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public required string? ConnectionString { get; set; }
        

    }
}
