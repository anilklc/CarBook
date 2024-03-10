using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.Role
{
    public class ResultUserWithRoleDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
