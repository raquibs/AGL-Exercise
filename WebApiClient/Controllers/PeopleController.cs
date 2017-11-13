using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApiClient.Client;
using WebApiClient.Models.Dto;
using Newtonsoft.Json;

namespace WebApiClient.Controllers
{
    public class PeopleController : Controller
    {
        readonly RestClient _client = new RestClient();
        public List<PersonDto> People = new List<PersonDto>();
        // GET: People
        public async Task<ActionResult> Index()
        {
            
            People = await _client.GetPeopleAsync();
            return View(People);
        }

        public async Task<ActionResult> GetOwnerWithCat()
        {
            var result = await _client.GetPeopleAsync();

            result.Where(p => p.pets != null).ToList().ForEach(p=> p.pets.RemoveAll(e=> !e.Type.Equals("Cat")));
            //var grp = result.GroupBy(r => r.Gender).Select(g => new {g.Key, list = g.OrderBy(e=>e.Name).ToList()}).ToList();
           return View( "Index",result);
        }
    }
}