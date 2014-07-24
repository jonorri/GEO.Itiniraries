﻿// <copyright file="Global.asax.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web
{
    using System.Timers;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using log4net.Config;
    using WhatToDoInIceland.Web.Common.Storage;
    using Geo.Itineraries.Web.Common.Storage;

    /// <summary>
    /// The MVC application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The application start method
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure();

            InMemoryStorage.PrimeProcessWithVenues();

            Timer primeCacheTimer = new Timer();
            primeCacheTimer.Interval = 3600000;
            primeCacheTimer.Elapsed += this.PrimeCacheTimer_Elapsed;
            primeCacheTimer.Start();

            this.PrimeCacheTimer_Elapsed(null, null);
        }

        /// <summary>
        /// The prime cache timer elapsed event handler
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The elapsed event argument</param>
        private void PrimeCacheTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            InMemoryStorage.PrimeCache();
            
            // TODO: KRAPP CREATE A TIMER WHICH SENDS OUT EMAILS BASED ON THE MISSING VENUES.
        }
    }
}
