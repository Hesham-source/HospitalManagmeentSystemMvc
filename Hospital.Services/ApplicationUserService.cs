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
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmlist = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludedRecord = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>()
                                           .GetAll()
                                           .Skip(ExcludedRecord)
                                           .Take(pageSize)
                                           .ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;


                vmlist = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<ApplicationUserViewModel>()
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,

            };
            return Result;
        }

        

        public PagedResult<ApplicationUserViewModel> GetAllDoctors(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmlist = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludedRecord = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>()
                                           .GetAll(x=>x.IsDoctor==true)
                                           .Skip(ExcludedRecord)
                                           .Take(pageSize)
                                           .ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).ToList().Count;


                vmlist = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<ApplicationUserViewModel>()
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,

            };
            return Result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }


        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x=>new ApplicationUserViewModel(x)).ToList();
        }
    }
}
