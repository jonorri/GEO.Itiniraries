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
        /// Venue REDIS prefix
        /// </summary>
        private static readonly string VenueRedisPrefix = "VENUE";

        /// <summary>
        /// Missing venue REDIS prefix
        /// </summary>
        private static readonly string MissingVenueRedisPrefix = "MISSING_VENUE";

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
        public static EventListModel GetEvents(GeoCoordinate position, DateTime startDate, DateTime? endDate, int radiusRange, IList<Categories> categories)
        {
            EventListModel list = new EventListModel();
            foreach (var category in categories)
            {
                var eventListModels = GetEventModels(category) ?? new EventListModel();
                
                list.EventModels.AddRange(eventListModels.EventModels);
            }

            list.EventModels.RemoveAll(x => endDate < x.EventDate || startDate > x.EventDate);
            
            list.EventModels.RemoveAll(x => x.Venue == null);
            list.EventModels.RemoveAll(x => !VenueHelper.IsVenueWithinRadius(x.Venue, position, (int)radiusRange));

            return list;
        }

        /// <summary>
        /// Creates a new venue in REDIS
        /// </summary>
        /// <param name="venueModel">Venue model to create</param>
        public static void CreateVenue(VenueModel venueModel)
        {
            // TODO: KRAPP SEE IF THE VENUE IS MISSING IN MISSING VENUES IN REDIS THEN DELETE THAT ONE
            var key = Guid.NewGuid().ToString();
            venueModel.VenueId = key;
            cache.StringSet(RedisStorage.VenueRedisPrefix + key, JsonConvert.SerializeObject(venueModel));
            AddVenueId(venueModel.VenueId);
        }

        /// <summary>
        /// Edits a venue model in REDIS
        /// </summary>
        /// <param name="venueModel">Venue model to edit</param>
        public static void EditVenue(VenueModel venueModel)
        {
            cache.StringSet(RedisStorage.VenueRedisPrefix + venueModel.VenueId, JsonConvert.SerializeObject(venueModel));
        }

        /// <summary>
        /// Gets all venues in REDIS
        /// </summary>
        /// <returns>All venues</returns>
        public static IList<VenueModel> GetVenues()
        {
            return GetRedisListWithIdListAtKey<VenueModel>("VENUE_ID_LIST", RedisStorage.VenueRedisPrefix);
        }

        /// <summary>
        /// Maintains a list of all venues stored in REDIS
        /// </summary>
        /// <param name="venueId">Venue id to add to the list</param>
        public static void AddVenueId(string venueId)
        {
            cache.StringAppend("VENUE_ID_LIST", ":" + venueId);
        }

        /// <summary>
        /// Gets all missing venues in REDIS
        /// </summary>
        /// <returns>All missing venues</returns>
        public static IList<MissingVenueModel> GetMissingVenues()
        {
            return GetRedisListWithIdListAtKey<MissingVenueModel>("MISSING_VENUE_ID_LIST", RedisStorage.MissingVenueRedisPrefix);
        }

        /// <summary>
        /// Fetches the id list from REDIS by key
        /// And fetches all cache entries by those keys
        /// </summary>
        /// <param name="redisKey">REDIS key that the id list is stored at</param>
        /// <typeparam name="T">Type of list that the method returns</typeparam>
        /// <returns>List of T</returns>
        public static List<T> GetRedisListWithIdListAtKey<T>(string redisKey, string redisPrefix)
        {
            List<T> list = new List<T>();
            var idList = GetStringListByKey(redisKey);
            foreach (var id in idList)
            {
                // TODO: KRAPP THIS IS A SHITMIX BECAUSE THE VENUE LIST IN REDIS IS INCORRECTLY CONFIGURED
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var cacheObject = cache.StringGet(redisPrefix + id);
                    list.Add(JsonConvert.DeserializeObject<T>(cacheObject));
                }
            }

            return list;
        }

        /// <summary>
        /// Deletes an entity in REDIS
        /// </summary>
        /// <param name="redisKey">Key to delete</param>
        public static void DeleteFromRedis(string redisKey)
        {
            cache.KeyDelete(redisKey);
        }

        /// <summary>
        /// Stores a missing venue in REDIS
        /// </summary>
        /// <param name="venueName">Venue that is missing</param>
        public static void CreateMissingVenue(string venueName)
        {
            MissingVenueModel missingVenue = new MissingVenueModel { VenueName = venueName, DateMissing = DateTime.UtcNow };

            cache.StringSet(RedisStorage.MissingVenueRedisPrefix + venueName, JsonConvert.SerializeObject(missingVenue));
        }

        /// <summary>
        /// Primes the REDIS storage layer with data from APIS.is
        /// </summary>
        public static void PrimeCache()
        {
            Task.Factory.StartNew(() => new ApisIs.MovieHandler().GetEvents(UpdateEventModels));
            Task.Factory.StartNew(() => new ApisIs.SportHandler().GetEvents(UpdateEventModels));
            Task.Factory.StartNew(() => new ApisIs.ConcertHandler().GetEvents(UpdateEventModels));
            Task.Factory.StartNew(() => new ApisIs.TheaterHandler().GetEvents(UpdateEventModels));
        }

        /// <summary>
        /// Returns a list of string delimited by : from REDIS
        /// </summary>
        /// <param name="stringKey">String key that the list is stored at</param>
        /// <returns>Returns a list of string keys delimited by :</returns>
        private static IList<string> GetStringListByKey(string stringKey)
        {
            List<string> stringList = new List<string>();
            var list = cache.StringGet(stringKey).ToString();
            stringList.AddRange(list.Split(':'));
            return stringList;
        }

        /// <summary>
        /// Gets event list models by category
        /// </summary>
        /// <param name="category">Category to get by</param>
        /// <returns>An event list model</returns>
        private static EventListModel GetEventModels(Categories category)
        {
            try
            {
                return JsonConvert.DeserializeObject<EventListModel>(cache.StringGet(((int)category).ToString()));
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
        private static void UpdateEventModels(EventListModel eventModels)
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

        public static VenueModel GetVenue(Guid venueId)
        {
            return JsonConvert.DeserializeObject<VenueModel>(cache.StringGet(RedisStorage.VenueRedisPrefix + venueId.ToString()));
        }

        public static void DeleteVenue(Guid venueId)
        {
            cache.KeyDelete(RedisStorage.VenueRedisPrefix + venueId.ToString());
        }
    }
}