using HotelManager_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace HotelManager_MVC.Models
{
    public class Room_TypeClient
    {
        private string Base_URL = "http://localhost:51148/api/";
        public IEnumerable<List_Rooms> searchRoom_Type(room_Type_DescriptionViewModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Base_URL);
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var a = model.room_Type_Description;
            HttpResponseMessage response = client.GetAsync(
                "Room_Type/searchRoom_Type?room_Type_Description=" + a).Result;
            if(response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<List_Rooms>>().Result;
            }
            return null;
        }
    }
}