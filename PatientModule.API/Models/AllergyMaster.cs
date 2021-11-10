using System;
using System.Collections.Generic;

#nullable disable

namespace PatientModule.API.Models
{
    public partial class AllergyMaster
    {
        public int AllergyMastersId { get; set; }
        public string Description { get; set; }
        public bool IsFatal { get; set; }
    }
}
