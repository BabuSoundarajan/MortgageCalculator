using MortgageCalculator.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            IEnumerable<Mortgage> mortgageList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49608/api/");
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP GET
                var responseTask = client.GetAsync("Mortgage");
                responseTask.Wait();



                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();


                    mortgageList = JsonConvert.DeserializeObject<List<Mortgage>>(readTask.Result);
                }
                else //web api sent error response 
                {
                    mortgageList = Enumerable.Empty<Mortgage>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(mortgageList);
        }

        //public ActionResult GetAllMortgages()
        //{
        //    IEnumerable<Mortgage> mortgage = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:49608/api/");
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format  
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //HTTP GET
        //        var responseTask = client.GetAsync("Mortgage");
        //        responseTask.Wait();



        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsStringAsync();
        //            readTask.Wait();


        //            mortgage = JsonConvert.DeserializeObject<List<Mortgage>>(readTask.Result);
        //        }
        //        else //web api sent error response 
        //        {
        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    var response = new
        //    {
        //        data = mortgage
        //    };

        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
    }
}