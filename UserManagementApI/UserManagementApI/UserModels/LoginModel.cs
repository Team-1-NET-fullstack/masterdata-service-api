using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementApI.UserModels
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public int? Id { get; set; }
        public string roleId { get; set; }
        public string Token { get; set; }
    }
}
