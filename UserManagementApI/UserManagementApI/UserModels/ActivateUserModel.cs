using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementApI.UserModels
{
    public class ActivateUserModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
    }
}
