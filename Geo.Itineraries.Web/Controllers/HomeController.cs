// <copyright file="HomeController.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index view displays the home page
        /// </summary>
        /// <returns>The index view</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The about view displays information about this application
        /// </summary>
        /// <returns>The about view</returns>
        public ActionResult About()
        {
            return this.View();
        }

        /// <summary>
        /// The contact view displays contact information
        /// </summary>
        /// <returns>The contact view</returns>
        public ActionResult Contact()
        {
            return this.View();
        }
    }
}