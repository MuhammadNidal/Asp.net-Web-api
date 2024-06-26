using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.AccessManagement.Detail.UserRoles.Dto
{
    public class UpdateUserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public int MobileNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
