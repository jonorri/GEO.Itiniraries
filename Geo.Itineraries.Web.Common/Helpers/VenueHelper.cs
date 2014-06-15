// <copyright file="VenueHelper.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Helpers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
        private static ICollection<VenueModel> venues = new Collection<VenueModel>();

        /// <summary>
        /// Initializes static members of the <see cref="VenueHelper" /> class."/>
        /// </summary>
        static VenueHelper()
        {
            venues.Add(new VenueModel { VenueKey = "BORGARBÍÓ", VenueId = string.Empty, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "BORGARBÍÓ_AKUREYRI", VenueId = string.Empty, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.682879, Longitude = -18.090517, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,_AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,SELFOSSI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 63.93615, Longitude = -21.008226, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,_SELFOSSI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 63.93615, Longitude = -21.008226, Location = "Akureyri" });
            venues.Add(new VenueModel { VenueKey = "KEX", VenueId = string.Empty, VenueName = "KEX Hostel", Latitude = 64.145537, Longitude = -21.919487, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "GAMLI_GAUKUR", VenueId = string.Empty, VenueName = "Gamli Gaukurinn", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "HARLEM", VenueId = string.Empty, VenueName = "Harlem", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "LUCKY_RECORDS", VenueId = string.Empty, VenueName = "Lucky records", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "STÚDENTAKJALLARINN", VenueId = string.Empty, VenueName = "Stúdentakjallarinn", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "BÍÓ_PARADÍS", VenueId = string.Empty, VenueName = "Bíó Paradís", Latitude = 64.145574, Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "HÁSKÓLABÍÓ", VenueId = string.Empty, VenueName = "Háskólabíó", Latitude = 64.148181, Longitude = -21.867099, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "LAUGARÁSBÍÓ", VenueId = string.Empty, VenueName = "Laugarásbíó", Latitude = 64.145574, Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_EGILSHÖLL", VenueId = string.Empty, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_EGILSHÖLL", VenueId = string.Empty, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_KRINGLAN", VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "KRINGLUBÍÓ", VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_KRINGLUNNI", VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_ÁLFABAKKA", VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "ÁLFABAKKI", VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_ÁLFABAKKA", VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_KEFLAVÍK", VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453, Location = "Keflavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,_KEFLAVÍK", VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453, Location = "Keflavík" });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_KEFLAVÍK", VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453, Location = "Keflavík" });
            venues.Add(new VenueModel { VenueKey = "SMÁRABÍÓ", VenueId = string.Empty, VenueName = "Smárabíó", Latitude = 64.144535, Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "RÓSENBERG", VenueId = string.Empty, VenueName = "Rósenberg", Latitude = 64.144535, Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "DILLON", VenueId = string.Empty, VenueName = "Dillon", Latitude = 64.134951, Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "BORGARLEIKHÚSIÐ", VenueId = string.Empty, VenueName = "Borgarleikhúsið", Latitude = 64.134951, Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "ÞJÓÐLEIKHÚSIÐ", VenueId = string.Empty, VenueName = "Þjóðleikhúsið", Latitude = 64.1287, Longitude = -21.896595, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "HARPA", VenueId = string.Empty, VenueName = "Harpan", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "VODAFONEVÖLLURINN", VenueId = string.Empty, VenueName = "Vodafonevöllurinn", Latitude = 64.133086, Longitude = -21.923564, Location = "Reykjavík" });
            venues.Add(new VenueModel { VenueKey = "FYLKISVÖLLUR", VenueId = string.Empty, VenueName = "Fylkisvöllur", Latitude = 64.113394, Longitude = -21.792884, Location = "Reykjavík" });
        }

        /// <summary>
        /// Primes the REDIS cache with all the venues in the venue helper
        /// </summary>
        public static void PrimeCacheWithVenues()
        {
            foreach (var venue in venues)
            {
                RedisStorage.CreateVenue(venue);
            }
        }

        /// <summary>
        /// Gets venue model for a certain venue name string
        /// </summary>
        /// <param name="venue">Venue to get the model for</param>
        /// <returns>Venue model</returns>
        public static VenueModel GetVenueModel(string venue)
        {
            var venues = RedisStorage.GetVenues();
            if (venues.Any(x => x.VenueKey.ToUpper() == venue.ToUpper().Replace(' ', '_')))
            {
                return venues.FirstOrDefault(x => x.VenueKey == venue.ToUpper().Replace(' ', '_'));
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