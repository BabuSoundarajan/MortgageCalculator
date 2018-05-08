using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator.Web.Controllers;
using System.Web.Mvc;

namespace MortgageCalculator.UnitTest
{

    [TestClass]
    public class UnitTest1
    {
        [Ignore] // Ignored since the ip is refused to create a connection with the host
        [TestMethod]
        public void HomeController_Valid()
        {
            HomeController controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            //Assert.AreEqual("Index", result.ViewName);

        }
    }

}
