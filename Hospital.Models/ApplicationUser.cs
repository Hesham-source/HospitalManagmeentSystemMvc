
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
   public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; } 
        public string City { get; set; }
        public string Description { get; set; } 
        public DateTime DoB { get; set; }
        public string  Specialist { get; set; }
        public bool IsDoctor { get; set; }
        public string PictureUrl { get; set; }  
        public ICollection<Appointment> Appointments { get; set; }
   
        public Department? Department { get; set; }
        public ICollection<Payroll> payrolls { get; set; }
        [NotMapped]
        public ICollection<PatientReport> patientReports { get; set; }
    }
}

namespace Hospital.Models
{
    public enum Gender
    {
        Male,Female
    }
}