using MortgageCalculator.Dto;
using MortgageCalculator.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    [OutputCache(CacheProfile = "Cache24Hrs")]
    public class MortgageController : Controller
    {

        HttpClient client = new HttpClient();
        public MortgageController()
        {
            client.BaseAddress = new Uri(Settings.BaseUrl);
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Mortgage
        public ActionResult Index()
        {
            IEnumerable<Dto.Mortgage> mortgageList = null;

            using (client)
            {
                var responseTask = client.GetAsync("Mortgage");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    mortgageList = JsonConvert.DeserializeObject<List<Dto.Mortgage>>(readTask.Result);
                }
                else //web api sent error response 
                {
                    mortgageList = Enumerable.Empty<Dto.Mortgage>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(mortgageList);
        }
    }
}