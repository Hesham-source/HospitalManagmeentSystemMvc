using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
public class HospitalInfoService : IHospitalInfo
    {
        private readonly IUnitOfWork _unitOfWork;

        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHospitalInfo(int id)
        {
            var model= _unitOfWork.GenericRepository<HospitalInfo>().GetById(id);
            _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
            _unitOfWork.save();
        }

        public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
           var vm=new HospitalInfoViewModel();
            int totalCount;
            List<HospitalInfoViewModel> vmlist=new List<HospitalInfoViewModel>();
            try
            {
                int ExcludedRecord = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<HospitalInfo>()
                                           .GetAll()
                                           .Skip(ExcludedRecord)
                                           .Take(pageSize)
                                           .ToList();
                
totalCount=_unitOfWork.GenericRepository<HospitalInfo>().GetAll().ToList().Count;


                vmlist=ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<HospitalInfoViewModel>()
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,

            };
            return Result;  
        }

        public List<HospitalInfoViewModel > GetAllItems()
        {
            return _unitOfWork.GenericRepository<HospitalInfo>().GetAll().Select(model => new HospitalInfoViewModel(model)).ToList();
        }
        public HospitalInfoViewModel GetHospitalById(int HospitalId)
        {
       var model=  _unitOfWork.GenericRepository<HospitalInfo>().GetById(HospitalId);
            var vm=new HospitalInfoViewModel(model);
            return vm;
        }

        public void InsertHospitalInfo(HospitalInfoViewModel HospitalInfoViewModel)
        {
           var model=new HospitalInfoViewModel().ConvertViewModel(HospitalInfoViewModel);
            _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateHospitalInfo(HospitalInfoViewModel Vm)
        {
           var model=new HospitalInfoViewModel().ConvertViewModel(Vm);
            var ModelById = _unitOfWork.GenericRepository<HospitalInfo>().GetById(model.Id);
            ModelById.Name=Vm.Name;
            ModelById.City=Vm.City;
            ModelById.country = Vm.country;
            ModelById.PinCode = Vm.PinCode;
            ModelById.Type = Vm.Type;
            _unitOfWork.GenericRepository<HospitalInfo>().Update(ModelById);
            _unitOfWork.save();
        }

        private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> hospitalInfos)
        {
            return hospitalInfos.Select(Model => new HospitalInfoViewModel(Model)).ToList();
        }
    }
}
