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
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;
      
        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.save();
        }

        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmlist = new List<RoomViewModel>();
            try
            {
                int ExcludedRecord = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Room>()
                                           .GetAll(includeProperties:"Hospital")
                                           .Skip(ExcludedRecord)
                                           .Take(pageSize)
                                           .ToList();

                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;


                vmlist = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<RoomViewModel>()
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,

            };
            return Result;
        }

        public RoomViewModel GetRoomById(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            var vm = new RoomViewModel(model);
            return vm;
        }

        public void InsertRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);
            var ModelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
            ModelById.Type = room.Type;
            ModelById.RoomNumber = room.RoomNumber;
            ModelById.Stutus = room.Status;


            _unitOfWork.GenericRepository<Room>().Update(ModelById);
            _unitOfWork.save();
        }


        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> rooms)
        {
            return rooms.Select(Model => new RoomViewModel(Model)).ToList();
        }
    }
}
