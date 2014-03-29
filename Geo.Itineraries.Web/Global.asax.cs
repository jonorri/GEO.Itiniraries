using Geo.Itineraries.Web.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Geo.Itineraries.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Timer primeCacheTimer = new Timer();
            primeCacheTimer.Interval = 3600000;
            primeCacheTimer.Elapsed += primeCacheTimer_Elapsed;
            primeCacheTimer.Start();

            primeCacheTimer_Elapsed(null, null);
        }

        void primeCacheTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ItineraryStorage storage = new ItineraryStorage();
            storage.PrimeCache();
        }
    }
}
