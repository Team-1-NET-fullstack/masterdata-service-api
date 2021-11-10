using System;
using System.Collections.Generic;

#nullable disable

namespace PatientModule.API.Models
{
    public partial class PatientVisit
    {
        public int PatientVisitId { get; set; }
        public int AppointmentId { get; set; }
        public string DiagnosisDescription { get; set; }
        public string MedicationDescription { get; set; }
        public string ProcedureDescription { get; set; }
        public string AllergyDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
