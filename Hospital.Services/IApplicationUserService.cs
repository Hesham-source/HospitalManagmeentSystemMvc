﻿using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll (int PageNumber,int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctors(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize);
    }
}
