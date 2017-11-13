using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WebApiClient.Models.Dto;
using Newtonsoft.Json;

namespace WebApiClient.Client
{
    public class RestClient
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://agl-developer-test.azurewebsites.net/people.json";

        public async Task<List<PersonDto>> GetPeopleAsync()
        {
            List<PersonDto> people = new List<PersonDto>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();   
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("http://agl-developer-test.azurewebsites.net/people.json");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var peopleResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    people = JsonConvert.DeserializeObject<List<PersonDto>>(peopleResponse);

                }
            }

            return people;
        }
    }
}