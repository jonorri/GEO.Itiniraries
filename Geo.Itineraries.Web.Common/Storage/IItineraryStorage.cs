// <copyright file="IItineraryStorage.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Device.Location;
    using WhatToDoInIceland.Web.Common.Models;

    /// <summary>
    /// The itinerary storage interface
    /// </summary>
    public interface IItineraryStorage
    {
        /// <summary>
        /// Gets all events from the itinerary storage
        /// </summary>
        /// <param name="position">GEO coordinate position</param>
        /// <param name="startDate">The start date to look for events</param>
        /// <param name="endDate">The end date to look for events</param>
        /// <param name="radiusRange">The radius in meters to search for events by</param>
        /// <param name="categories">Categories to get by</param>
        /// <returns>An event list model</returns>
        EventListModel GetEvents(GeoCoordinate position, DateTime startDate, DateTime? endDate, int radiusRange, IList<Categories> categories);

        void PrimeCache();
    }
}
