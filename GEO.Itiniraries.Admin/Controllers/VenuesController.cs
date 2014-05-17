// <copyright file="VenuesController.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace GEO.Itiniraries.Admin.Controllers
{
    using System.Web.Mvc;
    using Geo.Itineraries.Web.Common.Storage;

    /// <summary>
    /// The controller for all venues in the system
    /// </summary>
    public class VenuesController : Controller
    {
        // GET: Venues
        public ActionResult Index()
        {
            var venueList = RedisStorage.GetVenues();
            return View(venueList);
        }

        public ActionResult MissingVenues()
        {
            var missingVenueList = RedisStorage.GetMissingVenues();
            return View("missingVenues", missingVenueList);
        }
    }
}