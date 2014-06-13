// <copyright file="VenuesController.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace GEO.Itiniraries.Admin.Controllers
{
    using System.Web.Mvc;
    using Geo.Itineraries.Web.Common.Storage;
    using System.Collections.Generic;
    using Geo.Itineraries.Web.Common.Models;
    using System;
    using System.Net;

    /// <summary>
    /// The controller for all venues in the system
    /// </summary>
    public class VenuesController : Controller
    {
        // GET: Venues
        public ActionResult Index()
        {
            var venueList = RedisStorage.GetVenues();
            return this.View(venueList);
        }

        public ActionResult MissingVenues()
        {
            var missingVenueList = RedisStorage.GetMissingVenues();
            return View("missingVenues", missingVenueList);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        public ActionResult Edit(Guid venueId)
        {
            if (venueId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VenueModel venue = RedisStorage.GetVenue(venueId);
            if (venue == null)
            {
                return this.HttpNotFound();
            }

            return this.View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VenueKey,VenueId,VenueName,Latitude,Longitude,Location")]VenueModel venue)
        {
            if (ModelState.IsValid)
            {
                RedisStorage.EditVenue(venue);
                return this.Redirect(Request.UrlReferrer.ToString());
            }

            return this.View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VenueKey,VenueId,VenueName,Latitude,Longitude,Location")]VenueModel venue)
        {
            if (ModelState.IsValid)
            {
                RedisStorage.CreateVenue(venue);
                return this.Redirect(Request.UrlReferrer.ToString());
            }

            return this.View(venue);
        }

        public ActionResult Delete(Guid venueId)
        {
            if (venueId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RedisStorage.DeleteVenue(venueId);

            return this.View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Delete the venue
            return this.Redirect(Request.UrlReferrer.ToString());
        }
    }
}