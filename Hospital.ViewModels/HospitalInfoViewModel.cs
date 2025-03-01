﻿using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
 public class HospitalInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string country { get; set; }


        public HospitalInfoViewModel()
        {

        }


        public HospitalInfoViewModel(HospitalInfo model)
        {
            Id = model.Id; 
            Name = model.Name;
            Type = model.Type;
            City = model.City;  
            PinCode = model.PinCode;
            country = model.country;    
                }

        public HospitalInfo ConvertViewModel(HospitalInfoViewModel model)
        {
            return new HospitalInfo
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                country = model.country,
            };
        }
        }
}

