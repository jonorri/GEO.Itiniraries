// <copyright file="MovieHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Storage.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using Geo.Itineraries.Models.ApisIs;
    using Geo.Itineraries.Web.Helpers;
    using Geo.Itineraries.Web.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// The movie event handler
    /// </summary>
    public class MovieHandler : IEventHandler
    {
        /// <summary>
        /// Gets movie events and stores them in REDIS
        /// </summary>
        /// <param name="updateStorage">The method to call to update the storage</param>
        public override void GetEvents(Action<EventListModel> updateStorage)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept-Version", "1");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var result = client.GetAsync("http://apis.is/cinema").Result;

                if (!result.IsSuccessStatusCode)
                {
                    return;
                }

                var content = result.Content.ReadAsStringAsync().Result;
                var content2 = JsonConvert.DeserializeObject<MovieListModel>(content);

                var venues = this.ManuallyGetVenues(content2.Results);
                var venueShowTimes = this.ManualGetShowtimes(venues, content2.Results);

                updateStorage(new EventListModel { EventModels = venueShowTimes.Select(x => new EventModel { EventName = x.Venue, EventDescription = x.VenueDescription, Venue = VenueHelper.GetVenueModel(x.Venue), EventDate = x.ShowTimes.Min() }).ToList(), Id = (int)EventTypes.Movies });
            }
        }

        /// <summary>
        /// Manually gets show times from the response from the APIS.is web service
        /// This is a bit of a hack. Will refactor later if needed
        /// </summary>
        /// <param name="venues">Venues to find show times for</param>
        /// <param name="movieModels">Movie models</param>
        /// <returns>List of venue show times</returns>
        private IList<VenueShowTime> ManualGetShowtimes(HashSet<string> venues, ICollection<MovieModel> movieModels)
        {
            var list = new List<VenueShowTime>();
            
            foreach (var venue in venues)
            {
                StringBuilder sb = new StringBuilder();
                var showTimeList = new List<DateTime>();

                foreach (var movie in movieModels)
                {
                    foreach (var showtime in movie.ShowTimes)
                    {
                        if (showtime.Theater == venue)
                        {   
                            foreach (var singleShowTime in showtime.Schedule)
                            {
                                showTimeList.Add(DateTime.Parse(singleShowTime.Substring(0, 5)));
                                sb.Append(string.Format("{0}:{1}{2}", movie.Title, singleShowTime, Environment.NewLine));
                            }
                        }
                    }
                }

                list.Add(new VenueShowTime { Venue = venue, VenueDescription = sb.ToString(), ShowTimes = showTimeList.Distinct().ToList() });
            }

            return list;
        }

        /// <summary>
        /// This manually gets venues from the response from the APIS.is web service.
        /// This is a bit of a manual approach. Will refactor later if needed
        /// </summary>
        /// <param name="collection">Collection to find venues from</param>
        /// <returns>A hash set of venues</returns>
        private HashSet<string> ManuallyGetVenues(ICollection<MovieModel> collection)
        {
            HashSet<string> hash = new HashSet<string>();
            foreach (var movie in collection)
            {
                foreach (var showtime in movie.ShowTimes)
                {
                    if (!hash.Contains(showtime.Theater))
                    {
                        hash.Add(showtime.Theater);
                    }
                }
            }

            return hash;
        }
    }

    /// <summary>
    /// Class to keep track of venue show times
    /// </summary>
    public class VenueShowTime
    {
        /// <summary>
        /// Gets or sets the venue
        /// </summary>
        public string Venue { get; set; }

        /// <summary>
        /// Gets or sets the show times
        /// </summary>
        public IList<DateTime> ShowTimes { get; set; }

        /// <summary>
        /// Gets or sets the venue description
        /// </summary>
        public string VenueDescription { get; set; }
    }
}