using System;
using System.Collections.Generic;

#nullable disable

namespace PatientModule.API.Models
{
    public partial class Medication
    {
        public int MedicationId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string MedicationDescription { get; set; }
        public int MedicationMasterId { get; set; }
        public int PatientId { get; set; }
        public int PatientVisitId { get; set; }
    }
}
