using bankroll.Binders;
using bankroll.domain.context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace bankroll
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.CreateAutoMapperMappings();
            ModelBinders.Binders.Add(typeof(decimal), new ModelBinder.DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new ModelBinder.DecimalModelBinder());

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (CurrentContext != null)
                CurrentContext.Dispose();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Regex.IsMatch(Request.Url.AbsolutePath, "\\.\\w{1,3}") == false)
                CurrentContext = new BankrollContext();
        }

        public static BankrollContext CurrentContext
        {
            get { return (BankrollContext)HttpContext.Current.Items["current.context"]; }
            set { HttpContext.Current.Items["current.context"] = value; }
        }
    }
}
