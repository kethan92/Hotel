using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.ViewModel
{
    public class List_Rooms
    {
        public string RoomNumber { get; set; }
        public string nameRoom { get; set; }
        public string id_RoomStatus { get; set; }
        public string room_Type_Code { get; set; }
        public string status { get; set; }
        public string room_Type_Description { get; set; }
        public string room_Standard_Rate { get; set; }
    }
}