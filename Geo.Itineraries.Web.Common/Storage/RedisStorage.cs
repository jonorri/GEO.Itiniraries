// <copyright file="RedisStorage.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Device.Location;
    using System.Threading.Tasks;
    using Geo.Itineraries.Web.Common.Helpers;
    using Geo.Itineraries.Web.Common.Models;
    using Newtonsoft.Json;
    using StackExchange.Redis;

    /// <summary>
    /// REDIS storage
    /// </summary>
    public static class RedisStorage
    {
        /// <summary>
        /// The REDIS connection to use
        /// </summary>
        private static ConnectionMultiplexer redisConnection;

        /// <summary>
        /// The REDIS database to connect to
        /// </summary>
        private static IDatabase cache;

        /// <summary>
        /// Initializes static members of the <see cref="RedisStorage"/> class.
        /// </summary>
        static RedisStorage()
        {
            ConfigurationOptions config = new ConfigurationOptions();
            config.Ssl = ConfigurationHelper.RedisSSL;
            config.SslHost = ConfigurationHelper.RedisSSLHost;
            config.EndPoints.Add(ConfigurationHelper.RedisLocation, ConfigurationHelper.RedisPort);
            config.Password = ConfigurationHelper.RedisPassword;

            redisConnection = ConnectionMultiplexer.Connect(config);
            cache = redisConnection.GetDatabase();
        }

        /// <summary>
        /// This method gets events from REDIS and filters out based on parameters
        /// </summary>
        /// <param name="position">GEO coordination</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="radiusRange">Radius range in meters</param>
        /// <param name="categories">Event categories</param>
        /// <returns>An event list model</returns>
        public static EventListModel GetEvents(GeoCoordinate position, DateTime startDate, DateTime? endDate, int radiusRange, IList<EventTypes> categories)
        {
            EventListModel list = new EventListModel();
            foreach (var category in categories)
            {
                var eventListModels = FetchFromRedis(category) ?? new EventListModel();
                
                list.EventModels.AddRange(eventListModels.EventModels);
            }

            list.EventModels.RemoveAll(x => endDate < x.EventDate || startDate > x.EventDate);
            
            list.EventModels.RemoveAll(x => x.Venue == null);
            list.EventModels.RemoveAll(x => !VenueHelper.IsVenueWithinRadius(x.Venue, position, (int)radiusRange));

            return list;
        }

        /// <summary>
        /// Stores a missing venue in REDIS
        /// </summary>
        /// <param name="venueName">Venue that is missing</param>
        public static void StoreMissingVenue(string venueName)
        {
            MissingVenueModel missingVenue = new MissingVenueModel { VenueName = venueName, DateMissing = DateTime.UtcNow };

            cache.StringSet("MissingVenue:" + venueName, JsonConvert.SerializeObject(missingVenue));
        }

        /// <summary>
        /// Primes the REDIS storage layer with data from APIS.is
        /// </summary>
        public static void PrimeCache()
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
        private static EventListModel FetchFromRedis(EventTypes eventType)
        {
            try
            {
                // TODO: KRAPP eventType should be renamed everywhere to categoryId and that should be a string
                return JsonConvert.DeserializeObject<EventListModel>(cache.StringGet(((int)eventType).ToString()));
            }
            catch (Exception)
            {
                return new EventListModel();
            }
        }

        /// <summary>
        /// Updates REDIS with the event list model
        /// </summary>
        /// <param name="eventModels">Event list model to update REDIS with</param>
        private static void UpdateRedis(EventListModel eventModels)
        {
            try
            {
                cache.StringSet(eventModels.Id.ToString(), JsonConvert.SerializeObject(eventModels));
            }
            catch (Exception)
            {
                // TODO: KRAPP LOG AND SWALLOW ALL EXCEPTIONS
            }
        }
    }
}