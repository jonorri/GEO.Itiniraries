namespace Geo.Itineraries.Web.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Device.Location;
    using System.Threading.Tasks;
    using Geo.Itineraries.Web.Helpers;
    using Geo.Itineraries.Web.Models;
    using ServiceStack.Redis;

    public class RedisStorage : IItineraryStorage
    {
        /// <summary>
        /// This method gets events from Redis and filters out based on parameters
        /// </summary>
        /// <param name="position">GEO coordination</param>
        /// <param name="hourRange">Hour range</param>
        /// <param name="radiusRange">Radius range</param>
        /// <param name="categories">Event categories</param>
        /// <returns>An event list model</returns>
        public EventListModel GetEvents(GeoCoordinate position, TimeRanges hourRange, RadiusRanges radiusRange, IList<EventTypes> categories)
        {
            var redisClient = new RedisClient("localhost");
            var eventClient = redisClient.As<EventListModel>();

            EventListModel list = new EventListModel();
            foreach (var category in categories)
            {
                var eventListModels = this.FetchFromRedis(category);
                list.EventModels.AddRange(eventListModels.EventModels);
            }

            // TODO: KRAPP SEPERATE THE STORAGE AND THE HANDLERS
            list.EventModels.RemoveAll(x => DateTime.UtcNow.AddHours((double)hourRange) < x.EventDate);

            // TODO: KRAPP THIS FAILS BADLY IF THERE IS NO VENUE DEFINED
            list.EventModels.RemoveAll(x => !IsVenueWithinRadius(x.Venue, position, (int)radiusRange));

            return list;
        }

        /// <summary>
        /// Checks whether a certain venue is within some radius
        /// </summary>
        /// <param name="venueModel">Venue model to check</param>
        /// <param name="position">Geo coordinate position</param>
        /// <param name="metersInRadius">Radius to filter by</param>
        /// <returns>True / False</returns>
        private bool IsVenueWithinRadius(VenueModel venueModel, GeoCoordinate position, int metersInRadius)
        {
            var distance = GeoHelpers.DistanceBetween(venueModel.Latitude, venueModel.Longitude, position.Latitude, position.Longitude);

            return distance < metersInRadius;
        }

        /// <summary>
        /// Primes the redis storage layer with data from apis.is
        /// </summary>
        public void PrimeCache()
        {
            Task.Factory.StartNew(() => new ApisIs.MovieHandler().GetEvents(UpdateRedis));
            Task.Factory.StartNew(() => new ApisIs.SportHandler().GetEvents(UpdateRedis));
            Task.Factory.StartNew(() => new ApisIs.ConcertHandler().GetEvents(UpdateRedis));
            Task.Factory.StartNew(() => new ApisIs.TheaterHandler().GetEvents(UpdateRedis));
        }

        /// <summary>
        /// Gets event list models by event type
        /// </summary>
        /// <param name="eventType">Event type to get by</param>
        /// <returns>An event list model</returns>
        private EventListModel FetchFromRedis(EventTypes eventType)
        {
            try
            {
                var redisClient = new RedisClient("localhost");
                var eventClient = redisClient.As<EventListModel>();

                return eventClient.GetById((int)eventType);
            }
            catch (Exception)
            {
                return new EventListModel();
            }
        }

        /// <summary>
        /// Updates Redis with the event list model
        /// </summary>
        /// <param name="eventModels">Event list model to update Redis with</param>
        private void UpdateRedis(EventListModel eventModels)
        {
            try
            {
                var redisClient = new RedisClient("localhost");
                var eventClient = redisClient.As<EventListModel>();

                eventClient.Store(eventModels);
            }
            catch (Exception)
            {
                // TODO: KRAPP LOG AND SWALLOW ALL EXCEPTIONS
            }

        }
    }
}