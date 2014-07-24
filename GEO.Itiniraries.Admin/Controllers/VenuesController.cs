// <copyright file="VenuesController.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace GEO.Itiniraries.Admin.Controllers
{
    using System.Web.Mvc;
    using WhatToDoInIceland.Web.Common.Storage;
    using System.Collections.Generic;
    using WhatToDoInIceland.Web.Common.Models;
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
            return null;
            // TODO: KRAPP
            //var venueList = RedisStorage.GetVenues();
            //return this.View(venueList);
        }

        public ActionResult MissingVenues()
        {
            return null;
            // TODO: KRAPP
            //var missingVenueList = RedisStorage.GetMissingVenues();
            //return View("missingVenues", missingVenueList);
        }

        public ActionResult Create(string missingVenue)
        {
            this.ViewBag.VenueKey = missingVenue;
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VenueKey,VenueId,VenueName,Latitude,Longitude,Location")]VenueModel venue)
        {
            if (ModelState.IsValid)
            {
                // TODO: KRAPP
                //RedisStorage.CreateVenue(venue);
                return this.Redirect(Request.UrlReferrer.ToString());
            }

            return this.View(venue);
        }

        public ActionResult Edit(Guid venueId)
        {
            if (venueId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //VenueModel venue = RedisStorage.GetVenue(venueId);
            //if (venue == null)
            //{
            //    return this.HttpNotFound();
            //}

            //return this.View(venue);

            // TODO: KRAPP
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VenueKey,VenueId,VenueName,Latitude,Longitude,Location")]VenueModel venue)
        {
            if (ModelState.IsValid)
            {
                // TODO: KRAPP
                //RedisStorage.EditVenue(venue);
                return this.Redirect(Request.UrlReferrer.ToString());
            }

            return this.View(venue);
        }

        public ActionResult DeleteMissingVenue(string missingVenueId)
        {
            if (string.IsNullOrWhiteSpace(missingVenueId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO: KRAPP
            //RedisStorage.DeleteMissingVenue(missingVenueId);

            return this.View();
        }

        [HttpPost, ActionName("DeleteMissingVenue")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMissingVenueConfirmed(string missingVenueId)
        {
            // TODO: KRAPP Delete the missing venue
            return this.Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Delete(Guid venueId)
        {
            if (venueId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO: KRAPP
            //RedisStorage.DeleteVenue(venueId);

            return this.View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid venueID)
        {
            // TODO: KRAPP Delete the venue
            return this.Redirect(Request.UrlReferrer.ToString());
        }
    }
}