using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Timing
    {
        public int Id { get; set; }
        public Guid DoctorId { get; set; }  
        public ApplicationUser Doctor { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfterNoonShiftStartTime { get; set; }
        public int AfterNoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }

    }

}

namespace Hospital.Models
{
    public enum Status
    {
        avalable,pending,confirm
    }
}