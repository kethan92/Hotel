using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace HotelManager_MVC.Models
{
    public class RoomStatusClient
    {
        private string Base_URL = "http://localhost:51148/api/";

        public RoomStatus getRoomStatus()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress=new Uri(Base_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            // HttpResponseMessage response=client.GetAsync("Roo")
            return null;
        }
    }
}