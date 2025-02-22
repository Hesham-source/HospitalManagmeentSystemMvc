using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital.ViewModels
{
public class TimingViewModel
    {
        public int Id { get; set; }
     
        public DateTime ScheduleDate { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfterNoonShiftStartTime { get; set; }
        public int AfterNoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        public ApplicationUser Doctor { get; set; }
        public List<SelectListItem> MorningShiftStart=new List<SelectListItem>();
        public List<SelectListItem> MorningShiftEnd = new List<SelectListItem>();
        public List<SelectListItem> AfterNoonShiftStart = new List<SelectListItem>();
        public List<SelectListItem> AfterNoonShiftEnd = new List<SelectListItem>();

        public TimingViewModel()
        {

        }

        public TimingViewModel(Timing timing)
        {
                Id = timing.Id; 
               ScheduleDate = timing.ScheduleDate; 
                MorningShiftStartTime = timing.MorningShiftStartTime;   
                MorningShiftEndTime = timing.MorningShiftEndTime;


                AfterNoonShiftStartTime = timing.AfterNoonShiftStartTime;
                AfterNoonShiftEndTime = timing.AfterNoonShiftEndTime;
                Duration = timing.Duration;
                Status = timing.Status;
               
                Status=timing.Status;   
                Duration=timing.Duration;    
        }

        public Timing ConvertViewModel (TimingViewModel timing)
        {
            return new Timing
            {
                Id = timing.Id,
                ScheduleDate = timing.ScheduleDate,
                MorningShiftStartTime = timing.MorningShiftStartTime,
                MorningShiftEndTime = timing.MorningShiftEndTime,


                AfterNoonShiftStartTime = timing.AfterNoonShiftStartTime,
                AfterNoonShiftEndTime = timing.AfterNoonShiftEndTime,
                Duration = timing.Duration,
                Status = timing.Status,
                Doctor = timing.Doctor
            };
           
        }
    }


    
}
