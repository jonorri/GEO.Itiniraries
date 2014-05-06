// <copyright file="RouteConfig.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Route config
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers routes
        /// </summary>
        /// <param name="routes">Routes to register</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
