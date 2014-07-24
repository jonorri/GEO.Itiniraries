// <copyright file="VenueHelper.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Helpers
{
    using Geo.Itineraries.Web.Common.Storage;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Device.Location;
    using System.IO;
    using System.Linq;
    using WhatToDoInIceland.Web.Common.Models;
    using WhatToDoInIceland.Web.Common.Storage;
    
    /// <summary>
    /// The venue helper provides helper methods for venues
    /// </summary>
    public static class VenueHelper
    {
        /// <summary>
        /// All venues the system keeps track of
        /// </summary>
        private static ICollection<VenueModel> venues = new Collection<VenueModel>();

        /// <summary>
        /// Initializes static members of the <see cref="VenueHelper" /> class."/>
        /// </summary>
        static VenueHelper()
        {
            venues = InMemoryStorage.GetVenues();
        }

        /// <summary>
        /// Gets venue model for a certain venue name string
        /// </summary>
        /// <param name="venue">Venue to get the model for</param>
        /// <returns>Venue model</returns>
        public static VenueModel GetVenueModel(string venue)
        {
            if (venues.Any(x => x.VenueKey.ToUpper() == venue.ToUpper().Replace(' ', '_')))
            {
                return venues.FirstOrDefault(x => x.VenueKey == venue.ToUpper().Replace(' ', '_'));
            }

            InMemoryStorage.CreateMissingVenue(venue);
            return null;
        }

        /// <summary>
        /// Checks whether a certain venue is within some radius
        /// </summary>
        /// <param name="venueModel">Venue model to check</param>
        /// <param name="position">Geo coordinate position</param>
        /// <param name="metersInRadius">Radius to filter by</param>
        /// <returns>True / False</returns>
        public static bool IsVenueWithinRadius(VenueModel venueModel, GeoCoordinate position, int metersInRadius)
        {
            var distance = GeoHelpers.DistanceBetween(venueModel.Latitude, venueModel.Longitude, position.Latitude, position.Longitude);

            return distance < metersInRadius;
        }
    }
}