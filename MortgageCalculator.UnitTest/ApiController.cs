using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator.Api.Controllers;
using MortgageCalculator.Api.Services;
using System.Collections.Generic;

namespace MortgageCalculator.UnitTest
{
    [TestClass]
    public class ApiController
    {
        private readonly MortgageService mortgageService;
        public ApiController()
        {
            mortgageService = new MortgageService();
        }
        [TestMethod]
        public void GetAllMortgages_ValidTest()
        {
            var mortgageList = mortgageService.GetAllMortgages();
            var controller = new MortgageController();

            var result = controller.Get() as List<Dto.Mortgage>;


            Assert.AreEqual(mortgageList.Count, result.Count);
        }

        [TestMethod]
        public void GetMortgageById_ValidTest()
        {
            var mortgage = mortgageService.Get(5);
            var controller = new MortgageController();
            var result = controller.Get(5);

            Assert.AreEqual(mortgage.Name, result.Name);
        }

        [TestMethod]
        public void GetMortgageById_InValidTest()
        {
            var mortgage = mortgageService.Get(0);
            var controller = new MortgageController();
            var result = controller.Get(5);

            Assert.AreNotEqual(mortgage, result);
        }

        [TestMethod]
        public void GetMortgageDropDownList_ValidTest()
        {
            var mortgage = mortgageService.GetMortgageDropDownList();
            var controller = new MortgageController();
            var result = controller.GetMortgageDropDownList() as List<Dto.MortgageDropDownList>;

            Assert.AreEqual(mortgage.Count, result.Count);
        }
    }
}
