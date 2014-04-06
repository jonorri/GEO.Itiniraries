namespace Geo.Itineraries.Web.Storage
{
    using Geo.Itineraries.Models;
    using Geo.Itineraries.Web.Helpers;
    using Geo.Itineraries.Web.Models;
    using ServiceStack.Redis;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Device.Location;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RedisStorage : IItineraryStorage
    {
        public EventListModel GetEvents(GeoCoordinate position, TimeRanges hourRange, RadiusRanges radiusRange, IList<EventTypes> categories)
        {
            var redisClient = new RedisClient("localhost");
            var eventClient = redisClient.As<EventListModel>();

            EventListModel list = new EventListModel();
            foreach (var category in categories)
            {
                // KRAPP FIX THIS
                var eventListModels = FetchFromRedis(category);
                if (eventListModels != null)
                {
                    var krapp = eventListModels.EventModels;
                    list.EventModels.AddRange(krapp);
                }
            }

            // TODO: KRAPP SEPERATE THE STORAGE AND THE HANDLERS

            // TODO: KRAPP SAFEGURAD THIS AGAINST A REDIS FAILURE

            list.EventModels.RemoveAll(x => DateTime.UtcNow.AddHours((double)hourRange) < x.EventDate);

            // TODO: KRAPP THIS FAILS BADLY IF THERE IS NO VENUE DEFINED
            list.EventModels.RemoveAll(x => !IsVenueWithinRadius(x.Venue, position, (int)radiusRange));

            return list;
        }

        private bool IsVenueWithinRadius(VenueModel venueModel, GeoCoordinate position, int metersInRadius)
        {
            var distance = GeoHelpers.DistanceBetween(venueModel.Latitude, venueModel.Longitude, position.Latitude, position.Longitude);

            return distance < metersInRadius;
        }

        public void PrimeCache()
        {
            // TODO: KRAPP BE SURE TO HANDLE ERRORS IN THE HANDLERS
            Task.Factory.StartNew(() => new ApisIs.MovieHandler().GetEvents(UpdateRedis));
            Task.Factory.StartNew(() => new ApisIs.SportHandler().GetEvents(UpdateRedis));
            Task.Factory.StartNew(() => new ApisIs.ConcertHandler().GetEvents(UpdateRedis));
            Task.Factory.StartNew(() => new ApisIs.TheaterHandler().GetEvents(UpdateRedis));
        }

        private EventListModel FetchFromRedis(EventTypes eventType)
        {
            var redisClient = new RedisClient("localhost");
            var eventClient = redisClient.As<EventListModel>();

            return eventClient.GetById((int)eventType);
        }

        private void UpdateRedis(EventListModel eventModels)
        {
            // TODO: KRAPP THIS SHOULD BE AN UPDATE NOT A BLIND STORE

            try
            {
                var redisClient = new RedisClient("localhost");
                var eventClient = redisClient.As<EventListModel>();

                eventClient.Store(eventModels);
            }
            catch (System.Exception)
            {
                // TODO: KRAPP SWALLOW ALL EXCEPTIONS
            }

        }
    }
}