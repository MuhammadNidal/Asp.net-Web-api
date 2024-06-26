using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Master.SubCategories.Dto
{
    public class UpdateSubCategoryDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public long CategoryId { get; set; }
    }
}
