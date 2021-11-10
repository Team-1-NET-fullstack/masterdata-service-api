using System;
using System.Collections.Generic;

#nullable disable

namespace PatientModule.API.Models
{
    public partial class Allergy
    {
        public int PatientAllergyId { get; set; }
        public int PatientId { get; set; }
        public int AllergyMastersId { get; set; }
        public int PatientVisitId { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
