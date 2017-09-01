using HotelManager_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace HotelManager_MVC.Models
{
    public class RoomsClient
    {
        private string Base_URL = "http://localhost:51148/api/";

        public IEnumerable<List_Rooms> GetAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Rooms").Result;
                if(response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsAsync<IEnumerable<List_Rooms>>().Result;               
                    return a;
                }                  
                return null;
            }
            catch
            {
                return null;
            }
        }
        

    }
}