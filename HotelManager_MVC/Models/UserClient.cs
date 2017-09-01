using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace HotelManager_MVC.Models
{
    public class UserClient
    {
        private string Base_URL = "http://localhost:51148/api/";

        public User checkUser(LoginUser user)
        {
           // List<User> user_ = new List<User>();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // HttpResponseMessage respone=client.GetAsync("User/")
                var a = user.username;
                HttpResponseMessage response = client.GetAsync("Users/UserLogin?username=" + user.username + "&password=" + user.password).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<User>().Result;
                }

                return null;
            }
            catch
            {
                return null;
            }

        }
        public IEnumerable<User> findAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Base_URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Users").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            return null;
        }
    }
}