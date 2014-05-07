// <copyright file="VenueHelper.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Geo.Itineraries.Web.Models;
    
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
            // THIS SHOULD BE STORED SOMEWHERE FOR EASY UPDATE/ACCESS
            venues.Add("BORGARBÍÓ", new VenueModel { VenueId = 2, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672, Location = "Akureyri" });
            venues.Add("BORGARBÍÓ_AKUREYRI", new VenueModel { VenueId = 2, VenueName = "Borgarbíó", Latitude = 61.323728, Longitude = 135.263672, Location = "Akureyri" });

            venues.Add("SAMBÍÓ_AKUREYRI", new VenueModel { VenueId = 2, VenueName = "Sambíó Akureyri", Latitude = 65.682879, Longitude = -18.090517, Location = "Akureyri" });
            venues.Add("SAMBÍÓIN_AKUREYRI", new VenueModel { VenueId = 2, VenueName = "Sambíó Akureyri", Latitude = 65.708324, Longitude = -17.517449, Location = "Akureyri" });
            venues.Add("KEX", new VenueModel { VenueId = 1, VenueName = "KEX Hostel", Latitude = 64.145537, Longitude = -21.919487, Location = "Reykjavík" });
            venues.Add("GAMLI_GAUKUR", new VenueModel { VenueId = 2, VenueName = "Gamli Gaukurinn", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add("HARLEM", new VenueModel { VenueId = 2, VenueName = "Harlem", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add("LUCKY_RECORDS", new VenueModel { VenueId = 2, VenueName = "Lucky records", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add("STÚDENTAKJALLARINN", new VenueModel { VenueId = 2, VenueName = "Stúdentakjallarinn", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add("BÍÓ_PARADÍS", new VenueModel { VenueId = 2, VenueName = "Bíó Paradís", Latitude = 64.145574, Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add("HÁSKÓLABÍÓ", new VenueModel { VenueId = 2, VenueName = "Háskólabíó", Latitude = 64.148181, Longitude = -21.867099, Location = "Reykjavík" });
            venues.Add("LAUGARÁSBÍÓ", new VenueModel { VenueId = 2, VenueName = "Laugarásbíó", Latitude = 64.145574, Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_EGILSHÖLL", new VenueModel { VenueId = 2, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_EGILSHÖLL", new VenueModel { VenueId = 2, VenueName = "Sambíó Egilshöll", Latitude = 64.130189, Longitude = -21.893005, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_KRINGLAN", new VenueModel { VenueId = 2, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_KRINGLUNNI", new VenueModel { VenueId = 2, VenueName = "Sambíó Kringlan", Latitude = 64.108031, Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_ÁLFABAKKA", new VenueModel { VenueId = 2, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_ÁLFABAKKA", new VenueModel { VenueId = 2, VenueName = "Sambíó Álfabakka", Latitude = 64.100997, Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add("SAMBÍÓIN_KEFLAVÍK", new VenueModel { VenueName = "Sambíó Keflavík", Latitude = 64.089551, Longitude = -21.938453, Location = "Keflavík" });
            venues.Add("SMÁRABÍÓ", new VenueModel { VenueId = 2, VenueName = "Smárabíó", Latitude = 64.144535, Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add("RÓSENBERG", new VenueModel { VenueId = 2, VenueName = "Rósenberg", Latitude = 64.144535, Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add("DILLON", new VenueModel { VenueId = 2, VenueName = "Dillon", Latitude = 64.134951, Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add("BORGARLEIKHÚSIÐ", new VenueModel { VenueId = 2, VenueName = "Borgarleikhúsið", Latitude = 64.134951, Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add("ÞJÓÐLEIKHÚSIÐ", new VenueModel { VenueId = 2, VenueName = "Þjóðleikhúsið", Latitude = 64.1287, Longitude = -21.896595, Location = "Reykjavík" });
            venues.Add("HARPA", new VenueModel { VenueId = 2, VenueName = "Harpan", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
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
            
            // TODO: KRAPP NOTIFY OF A MISSING VENUE LOG TO REDIS
            return null;
        }
    }
}