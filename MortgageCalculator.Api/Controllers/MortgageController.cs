using MortgageCalculator.Api.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace MortgageCalculator.Api.Controllers
{
    public class MortgageController : ApiController
    {
        private MortgageService mortgageService;
        public MortgageController()
        {
            mortgageService = new MortgageService();
        }
        // GET: api/Mortgage
        public IEnumerable<Dto.Mortgage> Get()
        {
            return mortgageService.GetAllMortgages();
        }

        //GET: api/Mortgage/5
        public Dto.Mortgage Get(int id)
        {
            return mortgageService.Get(id);
        }


        // GET: api/MortgageDropDownList
        [Route("api/MortgageDropDownList")]
        public IEnumerable<Dto.MortgageDropDownList> GetMortgageDropDownList()
        {
            return mortgageService.GetMortgageDropDownList();
        }
    }
}
