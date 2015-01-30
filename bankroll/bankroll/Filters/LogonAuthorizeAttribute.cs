using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bankroll.Filters
{
    public class LogonAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public LogonAuthorizeAttribute()
        {
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false))
            {
                return;
            }

            if (!SessionProfile.IsLogged)
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
        }
    }
}