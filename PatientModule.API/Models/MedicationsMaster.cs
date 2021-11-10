using System;
using System.Collections.Generic;

#nullable disable

namespace PatientModule.API.Models
{
    public partial class MedicationsMaster
    {
        public int MedicationMastersId { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Description { get; set; }
        public bool IsDeprecated { get; set; }
    }
}
