﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
   public class MedicineReport
    {
        public int Id { get; set; }
        public Supplier Supplier{ get; set; }
        public string Company { get; set; }
        public int Quantity { get;set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirateDate { get; set; }
        public string Country { get; set; } 
        public Medicine Medicine { get; set; }  
        
    }

}
