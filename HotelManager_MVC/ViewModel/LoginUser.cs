using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager_MVC.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage="Username không được bỏ trống!")]
        public string username { get; set; }
        [Required(ErrorMessage ="Password không được bỏ trống")]
        [DataType(DataType.Password)]
        public string password { get; set; }

      
    }
}