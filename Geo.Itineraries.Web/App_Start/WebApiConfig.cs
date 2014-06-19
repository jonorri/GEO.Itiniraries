// <copyright file="WebApiConfig.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web
{
    using System.Web.Http;
    
    /// <summary>
    /// Web API config
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the HTTP config
        /// </summary>
        /// <param name="config">HTTP config to register</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });
        }
    }
}
