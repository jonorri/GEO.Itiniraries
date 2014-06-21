// <copyright file="VenueHelper.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Helpers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Device.Location;
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
            venues.Add(new VenueModel { VenueKey = "BORGARBÍÓ", VenueId = string.Empty, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672 });
            venues.Add(new VenueModel { VenueKey = "BORGARBÍÓ_AKUREYRI", VenueId = string.Empty, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.682879, Longitude = -18.090517 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,_AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,AKUREYRI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,SELFOSSI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 63.93615, Longitude = -21.008226 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,_SELFOSSI", VenueId = string.Empty, VenueName = "Sambíó Akureyri", Latitude = 63.93615, Longitude = -21.008226 });
            venues.Add(new VenueModel { VenueKey = "KEX", VenueId = string.Empty, VenueName = "KEX Hostel", Latitude = 64.145537, Longitude = -21.919487, Sponsored = true });
            venues.Add(new VenueModel { VenueKey = "GAMLI_GAUKUR", VenueId = string.Empty, VenueName = "Gamli Gaukurinn", Latitude = 64.149265, Longitude = -21.941615, });
            venues.Add(new VenueModel { VenueKey = "HARLEM", VenueId = string.Empty, VenueName = "Harlem", Latitude = 64.149265, Longitude = -21.941615 });
            venues.Add(new VenueModel { VenueKey = "LUCKY_RECORDS", VenueId = string.Empty, VenueName = "Lucky records", Latitude = 64.142729, Longitude = -21.914077 });
            venues.Add(new VenueModel { VenueKey = "STÚDENTAKJALLARINN", VenueId = string.Empty, VenueName = "Stúdentakjallarinn", Latitude = 64.142729, Longitude = -21.914077 });
            venues.Add(new VenueModel { VenueKey = "BÍÓ_PARADÍS", VenueId = string.Empty, VenueName = "Bíó Paradís", Latitude = 64.145574, Longitude = -21.925192 });
            venues.Add(new VenueModel { VenueKey = "HÁSKÓLABÍÓ", VenueId = string.Empty, VenueName = "Háskólabíó", Latitude = 64.148181, Longitude = -21.867099 });
            venues.Add(new VenueModel { VenueKey = "LAUGARÁSBÍÓ", VenueId = string.Empty, VenueName = "Laugarásbíó", Latitude = 64.145574, Longitude = -21.925192 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_EGILSHÖLL", VenueId = string.Empty, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_EGILSHÖLL", VenueId = string.Empty, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_KRINGLAN", VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792 });
            venues.Add(new VenueModel { VenueKey = "KRINGLUBÍÓ", VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_KRINGLUNNI", VenueId = string.Empty, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_ÁLFABAKKA", VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164 });
            venues.Add(new VenueModel { VenueKey = "ÁLFABAKKI", VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_ÁLFABAKKA", VenueId = string.Empty, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN_KEFLAVÍK", VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓIN,_KEFLAVÍK", VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453 });
            venues.Add(new VenueModel { VenueKey = "SAMBÍÓ_KEFLAVÍK", VenueId = string.Empty, VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453 });
            venues.Add(new VenueModel { VenueKey = "SMÁRABÍÓ", VenueId = string.Empty, VenueName = "Smárabíó", Latitude = 64.144535, Longitude = -21.938839 });
            venues.Add(new VenueModel { VenueKey = "RÓSENBERG", VenueId = string.Empty, VenueName = "Rósenberg", Latitude = 64.144535, Longitude = -21.938839 });
            venues.Add(new VenueModel { VenueKey = "DILLON", VenueId = string.Empty, VenueName = "Dillon", Latitude = 64.134951, Longitude = -21.872063 });
            venues.Add(new VenueModel { VenueKey = "BORGARLEIKHÚSIÐ", VenueId = string.Empty, VenueName = "Borgarleikhúsið", Latitude = 64.134951, Longitude = -21.872063 });
            venues.Add(new VenueModel { VenueKey = "ÞJÓÐLEIKHÚSIÐ", VenueId = string.Empty, VenueName = "Þjóðleikhúsið", Latitude = 64.1287, Longitude = -21.896595 });
            venues.Add(new VenueModel { VenueKey = "HARPA", VenueId = string.Empty, VenueName = "Harpan", Latitude = 64.149265, Longitude = -21.941615 });
            venues.Add(new VenueModel { VenueKey = "VODAFONEVÖLLURINN", VenueId = string.Empty, VenueName = "Vodafonevöllurinn", Latitude = 64.133086, Longitude = -21.923564 });
            venues.Add(new VenueModel { VenueKey = "FYLKISVÖLLUR", VenueId = string.Empty, VenueName = "Fylkisvöllur", Latitude = 64.113394, Longitude = -21.792884 });
            venues.Add(new VenueModel { VenueKey = "LAUGARDALSHÖLL", VenueId = string.Empty, VenueName = "Laugardalshöll", Latitude = 64.140185, Longitude = -21.876721 });
            venues.Add(new VenueModel { VenueKey = "FRAMVÖLLUR", VenueId = string.Empty, VenueName = "Framvöllur", Latitude = 64.133324, Longitude = -21.892426 });
            venues.Add(new VenueModel { VenueKey = "ÞÓRSVÖLLUR", VenueId = string.Empty, VenueName = "Þórsvöllur", Latitude = 63.438098, Longitude = -20.291716 });
            venues.Add(new VenueModel { VenueKey = "AKUREYRARVÖLLUR", VenueId = string.Empty, VenueName = "Akureyrarvöllur", Latitude = 65.68595, Longitude = -18.095601 });
            venues.Add(new VenueModel { VenueKey = "EGILSHÖLL", VenueId = string.Empty, VenueName = "Egilshöll", Latitude = 64.147048, Longitude = -21.769688 });
            venues.Add(new VenueModel { VenueKey = "FÍFAN", VenueId = string.Empty, VenueName = "Fífan", Latitude = 64.102576, Longitude = -21.899554 });
            venues.Add(new VenueModel { VenueKey = "FAGRILUNDUR", VenueId = string.Empty, VenueName = "Fagrilundur", Latitude = 64.11634, Longitude = -21.87581 });
            venues.Add(new VenueModel { VenueKey = "FJÖLNISVÖLLUR", VenueId = string.Empty, VenueName = "Fjölnisvöllur", Latitude = 64.138407, Longitude = -21.788282 });
            venues.Add(new VenueModel { VenueKey = "GRÓTTUVÖLLUR", VenueId = string.Empty, VenueName = "Gróttuvöllur", Latitude = 64.1501854, Longitude = -21.995209 });
            venues.Add(new VenueModel { VenueKey = "GRINDAVÍKURVÖLLUR", VenueId = string.Empty, VenueName = "Grindavíkurvöllur", Latitude = 63.8445255, Longitude = -22.4293667 });
            venues.Add(new VenueModel { VenueKey = "HÁSTEINSVÖLLUR", VenueId = string.Empty, VenueName = "Hásteinsvöllur", Latitude = 63.439534, Longitude = -20.287872 });
            venues.Add(new VenueModel { VenueKey = "HERTZ_VÖLLURINN", VenueId = string.Empty, VenueName = "Hertz völlurinn", Latitude = 64.103973, Longitude = -21.851172 });
            venues.Add(new VenueModel { VenueKey = "HLÍÐARENDI", VenueId = string.Empty, VenueName = "Hlíðarendi", Latitude = 64.1329294, Longitude = -21.9270319 });
            venues.Add(new VenueModel { VenueKey = "JÁVERK-VÖLLURINN", VenueId = string.Empty, VenueName = "JÁVERK-völlurinn", Latitude = 63.933033, Longitude = -20.992691 });
            venues.Add(new VenueModel { VenueKey = "KÓPAVOGSVÖLLUR", VenueId = string.Empty, VenueName = "Kópavogsvöllur", Latitude = 64.104238, Longitude = -21.896433 });
            venues.Add(new VenueModel { VenueKey = "KÓRINN_-_GERVIGRAS", VenueId = string.Empty, VenueName = "Kórinn - Gervigras", Latitude = 64.082758, Longitude = -21.826929 });
            venues.Add(new VenueModel { VenueKey = "KR-VÖLLUR", VenueId = string.Empty, VenueName = "KR-völlur", Latitude = 64.147259, Longitude = -21.968312 });
            venues.Add(new VenueModel { VenueKey = "LAUGARDALSVÖLLUR", VenueId = string.Empty, VenueName = "Laugardalsvöllur", Latitude = 64.143427, Longitude = -21.879032 });
            venues.Add(new VenueModel { VenueKey = "LEIKNISVÖLLUR", VenueId = string.Empty, VenueName = "Leiknisvöllur", Latitude = 64.102186, Longitude = -21.820445 });
            venues.Add(new VenueModel { VenueKey = "N1-VÖLLURINN", VenueId = string.Empty, VenueName = "N1-völlurinn", Latitude = 64.1696884, Longitude = -21.6881295 });
            venues.Add(new VenueModel { VenueKey = "N1-VÖLLURINN-VARMÁ", VenueId = string.Empty, VenueName = "N1-völlurinn", Latitude = 64.1696884, Longitude = -21.6881295 });
            venues.Add(new VenueModel { VenueKey = "NETTÓVÖLLURINN", VenueId = string.Empty, VenueName = "Nettóvöllurinn", Latitude = 63.9990405, Longitude = -22.5578178 });
            venues.Add(new VenueModel { VenueKey = "NORÐURÁLSVÖLLURINN", VenueId = string.Empty, VenueName = "Norðurálsvöllurinn", Latitude = 64.318452, Longitude = -22.058433 });
            venues.Add(new VenueModel { VenueKey = "SAMSUNG_VÖLLURINN", VenueId = string.Empty, VenueName = "Samsung völlurinn", Latitude = 64.0883974, Longitude = -21.9291631 });
            venues.Add(new VenueModel { VenueKey = "SAUÐÁRKRÓKSVÖLLUR", VenueId = string.Empty, VenueName = "Sauðárkróksvöllur", Latitude = 65.7450558, Longitude = -19.6460223 });
            venues.Add(new VenueModel { VenueKey = "SCHENKERVÖLLURINN", VenueId = string.Empty, VenueName = "Schenkervöllurinn", Latitude = 64.0516567, Longitude = -21.9686714 });
            venues.Add(new VenueModel { VenueKey = "VÍKINGSVÖLLUR", VenueId = string.Empty, VenueName = "Víkingsvöllur", Latitude = 64.1179884, Longitude = -21.8485997 });
            venues.Add(new VenueModel { VenueKey = "VALBJARNARVÖLLUR", VenueId = string.Empty, VenueName = "Valbjarnarvöllur", Latitude = 64.143641, Longitude = -21.876435 });
            venues.Add(new VenueModel { VenueKey = "VERSALAVÖLLUR", VenueId = string.Empty, VenueName = "Versalavöllur", Latitude = 64.092956, Longitude = -21.85679 });
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