// <copyright file="SportHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Storage.ApisIs
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Geo.Itineraries.Web.Common.Models;
    using Geo.Itineraries.Web.Common.Models.ApisIs;
    using Geo.Itineraries.Web.Common.Models.Apis.Is;
    using Newtonsoft.Json;
    using Geo.Itineraries.Web.Common.Helpers;
    
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

                    var content2 = JsonConvert.DeserializeObject<SportListModel>(content);

                    // TODO: KRAPP FIX THE DateTime here
                    updateStorage(new EventListModel { Id = (int)Categories.Sports, EventModels = content2.Results.Select(x => new EventModel { ImageUrl = "Content/sport.png", CategoryId = (int)Categories.Sports, EventName = x.HomeTeam + " vs " + x.AwayTeam, EventDescription = "KRAPP", Venue = VenueHelper.GetVenueModel(x.Location), EventDate = DateTime.UtcNow }).ToList() });
                }
            }
            catch (Exception)
            {
                // TODO: KRAPP LOG AND SWALLOW
            }
        }
    }
}