using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementApI.UserModels
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsFirstTimeUser { get; set; }
        public int? WorngAttempts { get; set; }
        public int ContactNo { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public List<PatientModel> Patient { get; set; }
    }
}
