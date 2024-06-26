using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.RoleRights.Dto
{
    public class CreateRoleRightDto
    {
        [Required]
        public  bool IsAdd { get; set; }
        [Required]
        public bool IsUpdate { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Required]
        public bool IsView { get; set; }
        public long FormId { get; set; }
        public long RoleId { get; set; }

    }
}
