using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementApI.UserModels
{
    public class PatientModel
    {
        public int? UserId { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string LanguagesKnown { get; set; }
        public string HomeAddress { get; set; }
        public int? Age { get; set; }
        public int PatientId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
