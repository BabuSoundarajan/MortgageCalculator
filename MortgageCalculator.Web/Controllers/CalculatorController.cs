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
    public class CalculatorController : Controller
    {
        HttpClient client = new HttpClient();
        public CalculatorController()
        {
            client.BaseAddress = new Uri(Settings.BaseUrl);
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Calculator
        public ActionResult Index()
        {
            IEnumerable<MortgageDropDownList> mortgageDropDownList = new List<MortgageDropDownList>();

            using (client)
            {
                var responseTask = client.GetAsync("MortgageDropDownList");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    mortgageDropDownList = JsonConvert.DeserializeObject<List<MortgageDropDownList>>(readTask.Result);
                }
                else //web api sent error response 
                {
                    mortgageDropDownList = Enumerable.Empty<MortgageDropDownList>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(mortgageDropDownList);
        }
    }
}