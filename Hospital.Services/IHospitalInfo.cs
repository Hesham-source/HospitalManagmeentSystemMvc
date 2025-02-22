using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IHospitalInfo
    {

        PagedResult<HospitalInfoViewModel>  GetAll(int pageNumber,int pageSize);
        HospitalInfoViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInfo (HospitalInfoViewModel HospitalInfoViewModel);
        void DeleteHospitalInfo (int id);
        void InsertHospitalInfo(HospitalInfoViewModel HospitalInfoViewModel);
       List<HospitalInfoViewModel> GetAllItems();
    }
}
