﻿namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }  
        public ICollection<Appointment> Appointments { get; set; }
    }
}