namespace Geo.Itineraries.Web.Common.Storage
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Device.Location;
    using System.IO;
    using System.Runtime.Caching;
    using WhatToDoInIceland.Web.Common.Helpers;
    using WhatToDoInIceland.Web.Common.Models;
    using WhatToDoInIceland.Web.Common.Storage.ApisIs;

    public static class InMemoryStorage
    {
        static ObjectCache cache = MemoryCache.Default;

        static CacheItemPolicy policy = new CacheItemPolicy() { Priority = CacheItemPriority.Default, AbsoluteExpiration = DateTimeOffset.MaxValue };

        static Collection<VenueModel> venues;

        static InMemoryStorage()
        {
        }

        public static EventListModel GetEvents(GeoCoordinate position, DateTime startDate, DateTime? endDate, int radiusRange, IList<Categories> categories)
        {
            EventListModel list = new EventListModel();
            foreach (var category in categories)
            {
                var eventListModels = (EventListModel)cache.Get(category.ToString().ToUpper()) ?? new EventListModel();

                list.EventModels.AddRange(eventListModels.EventModels);
            }

            list.EventModels.RemoveAll(x => endDate < x.EventDate || startDate > x.EventDate);

            list.EventModels.RemoveAll(x => x.Venue == null);
            list.EventModels.RemoveAll(x => !VenueHelper.IsVenueWithinRadius(x.Venue, position, (int)radiusRange));

            return list;
        }

        public static void PrimeCache()
        {
            cache.Set(CacheKeys.MissingVenues, ":", policy);

            cache.Add("MOVIES", new MovieHandler().GetEvents(), policy);
            cache.Add("FOOTBALL", new FootballHandler().GetEvents(), policy);
            cache.Add("HANDBALL", new HandballHandler().GetEvents(), policy);
            cache.Add("CONCERT", new ConcertHandler().GetEvents(), policy);
            cache.Add("THEATER", new TheaterHandler().GetEvents(), policy);
        }

        public static void CreateMissingVenue(string venue)
        {
            string missingVenues = cache.Get(CacheKeys.MissingVenues).ToString();
            missingVenues += venue + ":";
            cache.Set(CacheKeys.MissingVenues, missingVenues, policy);
        }

        public static Collection<VenueModel> GetVenues()
        {
            return venues;
        }

        public static void PrimeProcessWithVenues()
        {
            string venuesString = File.ReadAllText(@"C:\storage\sc\GEO.Itiniraries\Geo.Itineraries.Web\bin\Files\venues.json");
            venues = JsonConvert.DeserializeObject<Collection<VenueModel>>(venuesString);
        }
    }
}
