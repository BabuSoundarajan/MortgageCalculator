using System.Web.Http;

namespace MortgageCalculator.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
