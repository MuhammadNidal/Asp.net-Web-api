using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto
{
    public class CreateUserDto
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        //[MaxLength(20)]
        public int MobileNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }
        [Required]
        public List<long> RoleIds { get; set; }
       
    }
}
