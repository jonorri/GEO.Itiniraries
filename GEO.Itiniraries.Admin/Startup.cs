// <copyright file="Startup.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GEO.Itiniraries.Admin.Startup))]

namespace GEO.Itiniraries.Admin
{
    /// <summary>
    /// Partial startup class
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configuration for the startup class
        /// </summary>
        /// <param name="app">App builder</param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
