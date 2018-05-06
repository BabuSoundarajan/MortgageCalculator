using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace MortgageCalculator.Web
{
    [ExcludeFromCodeCoverage]
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
