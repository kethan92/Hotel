using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager_MVC.Models
{
    public class Rooms
    {
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "nameRoom not is required")]
        public string nameRoom { get; set; }
        [Required(ErrorMessage = "RoomStatus not is required")]
        public int RoomStatus_id { get; set; }
        [Required(ErrorMessage = "RoomType not is required")]
        public int RoomType_id { get; set; }
        public virtual Room_Status room_Status { get; set; }
        public virtual Room_Type room_Type { get; set; }
       
    }
}