// <copyright file="IItineraryStorage.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Storage
{
    using System.Collections.Generic;
    using System.Device.Location;
    using Geo.Itineraries.Web.Models;

    /// <summary>
    /// The itinerary storage interface
    /// </summary>
    public interface IItineraryStorage
    {
        /// <summary>
        /// Gets all events from the itinerary storage
        /// </summary>
        /// <param name="position">GEO coordinate position</param>
        /// <param name="hourRange">Hour range to get by</param>
        /// <param name="radiusRange">Radius range</param>
        /// <param name="categories">Categories to get by</param>
        /// <returns>An event list model</returns>
        EventListModel GetEvents(GeoCoordinate position, TimeRanges hourRange, int radiusRange, IList<EventTypes> categories);

        /// <summary>
        /// Primes the REDIS cache
        /// </summary>
        void PrimeCache();
    }
}
