using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IRoomService
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber,int pageSize); 
        RoomViewModel GetRoomById(int id); 
        void UpdateRoom (RoomViewModel room);
        void DeleteRoom (int id);   
        void InsertRoom(RoomViewModel room);    
    }
}
