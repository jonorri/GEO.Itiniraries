﻿// <copyright file="VenueHelper.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Helpers
{
    using System.Collections.Generic;
    using System.Device.Location;
    using System.Linq;
    using Geo.Itineraries.Web.Common.Models;
    using Geo.Itineraries.Web.Common.Storage;
    
    /// <summary>
    /// The venue helper provides helper methods for venues
    /// </summary>
    public static class VenueHelper
    {
        /// <summary>
        /// All venues the system keeps track of
        /// </summary>
        private static Dictionary<string, VenueModel> venues = new Dictionary<string, VenueModel>();

        /// <summary>
        /// Initializes static members of the <see cref="VenueHelper" /> class."/>
        /// </summary>
        static VenueHelper()
        {
            // TODO: KRAPP THIS SHOULD BE STORED SOMEWHERE FOR EASY UPDATE/ACCESS - First feature in the admin interface.
            venues.Add("BORGARBÍÓ", new VenueModel { VenueId = string.Empty, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672, Location = "Akureyri" });
            venues.Add("BORGARBÍÓ_AKUREYRI", new VenueModel { VenueId = string.Empty, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672, Location = "Akureyri" });
            venues.Add("SAMBÍÓ_AKUREYRI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.682879, Longitude = -18.090517, Location = "Akureyri" });
            venues.Add("SAMBÍÓIN_AKUREYRI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449, Location = "Akureyri" });
            venues.Add("SAMBÍÓIN,_AKUREYRI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449, Location = "Akureyri" });
            venues.Add("SAMBÍÓIN,AKUREYRI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449, Location = "Akureyri" });
            venues.Add("SAMBÍÓIN,SELFOSSI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 63.93615, Longitude = -21.008226, Location = "Akureyri" });
            venues.Add("SAMBÍÓIN,_SELFOSSI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 63.93615, Longitude = -21.008226, Location = "Akureyri" });
            venues.Add("KEX", new VenueModel { VenueId = string.Empty, VenueName = "KEX Hostel", Latitude = 64.145537, Longitude = -21.919487, Location = "Reykjavík" });
            venues.Add("GAMLI_GAUKUR", new VenueModel { VenueId = string.Empty, VenueName = "Gamli Gaukurinn", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add("HARLEM", new VenueModel { VenueId = string.Empty, VenueName = "Harlem", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add("LUCKY_RECORDS", new VenueModel { VenueId = string.Empty, VenueName = "Lucky records", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add("STÚDENTAKJALLARINN", new VenueModel { VenueId = string.Empty, VenueName = "Stúdentakjallarinn", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add("BÍÓ_PARADÍS", new VenueModel { VenueId = string.Empty, VenueName = "Bíó Paradís", Latitude = 64.145574, Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add("HÁSKÓLABÍÓ", new VenueModel { VenueId = string.Empty, VenueName = "Háskólabíó", Latitude = 64.148181, Longitude = -21.867099, Location = "Reykjavík" });
            venues.Add("LAUGARÁSBÍÓ", new VenueModel { VenueId = string.Empty, VenueName = "Laugarásbíó", Latitude = 64.145574, Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_EGILSHÖLL", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_EGILSHÖLL", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_KRINGLAN", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add("KRINGLUBÍÓ", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_KRINGLUNNI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_ÁLFABAKKA", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add("ÁLFABAKKI", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_ÁLFABAKKA", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_KEFLAVÍK", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453, Location = "Keflavík" });
            venues.Add("SAMBÍÓIN,_KEFLAVÍK", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453, Location = "Keflavík" });
            venues.Add("SAMBÍÓ_KEFLAVÍK", new VenueModel { VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453, Location = "Keflavík" });
            venues.Add("SMÁRABÍÓ", new VenueModel { VenueId = string.Empty, VenueName = "Smárabíó", Latitude = 64.144535, Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add("RÓSENBERG", new VenueModel { VenueId = string.Empty, VenueName = "Rósenberg", Latitude = 64.144535, Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add("DILLON", new VenueModel { VenueId = string.Empty, VenueName = "Dillon", Latitude = 64.134951, Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add("BORGARLEIKHÚSIÐ", new VenueModel { VenueId = string.Empty, VenueName = "Borgarleikhúsið", Latitude = 64.134951, Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add("ÞJÓÐLEIKHÚSIÐ", new VenueModel { VenueId = string.Empty, VenueName = "Þjóðleikhúsið", Latitude = 64.1287, Longitude = -21.896595, Location = "Reykjavík" });
            venues.Add("HARPA", new VenueModel { VenueId = string.Empty, VenueName = "Harpan", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
        }

        /// <summary>
        /// Gets venue model for a certain venue name string
        /// </summary>
        /// <param name="venue">Venue to get the model for</param>
        /// <returns>Venue model</returns>
        public static VenueModel GetVenueModel(string venue)
        {
            if (venues.Keys.Any(x => x == venue.ToUpper().Replace(' ', '_')))
            {
                return venues[venue.ToUpper().Replace(' ', '_')];
            }

            RedisStorage.CreateMissingVenue(venue);
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