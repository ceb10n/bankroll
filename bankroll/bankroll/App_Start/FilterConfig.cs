using bankroll.Filters;
using System.Web;
using System.Web.Mvc;

namespace bankroll
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogonAuthorizeAttribute());
        }
    }
}
