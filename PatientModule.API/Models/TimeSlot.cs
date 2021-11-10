using System;
using System.Collections.Generic;

#nullable disable

namespace PatientModule.API.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int TimeSlotId { get; set; }
        public DateTime Slots { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
