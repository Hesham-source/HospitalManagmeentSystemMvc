using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalInfoId { get; set; }
        public HospitalInfo hospitalInfo { get; set; }
        public RoomViewModel()
        {

        }

        public RoomViewModel(Room room)
        {

            RoomNumber = room.RoomNumber;
            Type = room.Type;
            Id = room.Id;
            Status = room.Stutus;
            HospitalInfoId = room.HospitalId;
            hospitalInfo = room.Hospital;

        }

        public Room ConvertViewModel(RoomViewModel room)
        {
            return new Room
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                Type = room.Type,
                Stutus = room.Status,
                HospitalId = room.HospitalInfoId,
                Hospital = room.hospitalInfo
            };
           


        }
    
}
}
