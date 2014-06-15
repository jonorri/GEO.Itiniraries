// <copyright file="SportHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Storage.ApisIs
{
    using System;
    using System.Net.Http;
    using Geo.Itineraries.Web.Common.Models;
    using Geo.Itineraries.Web.Common.Models.ApisIs;
    
    /// <summary>
    /// The sport event handler
    /// </summary>
    public class SportHandler : IEventHandler
    {
        /// <summary>
        /// Gets sports events and stores them in REDIS
        /// </summary>
        /// <param name="updateStorage">The method to call to update the storage</param>
        public override void GetEvents(Action<EventListModel> updateStorage)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept-Version", "1");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var result = client.GetAsync("http://apis.is/sports/football").Result;

                    if (!result.IsSuccessStatusCode)
                    {
                        return;
                    }

                    var content = result.Content.ReadAsStringAsync().Result;

                    // TODO: KRAPP FINISH THIS
                    // var content2 = JsonConvert.DeserializeObject<MovieTheaterListModel>(content);

                    // updateStorage(new EventListModel { Id = (int)EventTypes.Sports, EventModels = content2.Results.Select(x => new EventModel { ImageUrl = "Content/sport.png", CategoryId = (int)EventTypes.Sports, EventName = x.Name, EventDescription = x.MoviesList(), Venue = VenueHelper.GetVenueModel(x.Name), EventDate = x.GetFirstShowTime() }).ToList() });
                }
            }
            catch (Exception)
            {
                // TODO: KRAPP LOG AND SWALLOW
            }
        }
    }
}