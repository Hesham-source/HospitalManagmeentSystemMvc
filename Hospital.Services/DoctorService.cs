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
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            _unitOfWork.GenericRepository<Timing>().Add(model);
            _unitOfWork.save();
        }

        public void DeleteTiming(int timingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(timingId);
            _unitOfWork.GenericRepository<Timing>().Delete(model);
            _unitOfWork.save();
        }

        public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimingViewModel();
            int totalCount;
            List<TimingViewModel> vmlist = new List<TimingViewModel>();
            try
            {
                int ExcludedRecord = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Timing>()
                                           .GetAll()
                                           .Skip(ExcludedRecord)
                                           .Take(pageSize)
                                           .ToList();

                totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().ToList().Count;


                vmlist = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<TimingViewModel>()
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,

            };
            return Result;
        }

        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimingViewModel(x)).ToList();
        }

        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(TimingList);
            return vmList;
        }

        public TimingViewModel GetTimingById(int timingid)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(timingid);
            var vm = new TimingViewModel(model);
            return vm;
        }

        public void UpdateTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            var ModelById = _unitOfWork.GenericRepository<Timing>().GetById(model.Id);
            ModelById.Id = timing.Id;

            ModelById.Status = timing.Status;
            ModelById.Duration = timing.Duration;
            ModelById.MorningShiftStartTime = timing.MorningShiftStartTime;
            ModelById.MorningShiftEndTime = timing.MorningShiftEndTime;
            ModelById.AfterNoonShiftEndTime = timing.AfterNoonShiftEndTime;
            ModelById.AfterNoonShiftStartTime = timing.AfterNoonShiftStartTime;
            _unitOfWork.GenericRepository<Timing>().Update(ModelById);
            _unitOfWork.save();
        }
    }
}
