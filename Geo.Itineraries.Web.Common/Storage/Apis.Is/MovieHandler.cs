﻿// <copyright file="MovieHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage.ApisIs
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Newtonsoft.Json;
    using WhatToDoInIceland.Web.Common.Helpers;
    using WhatToDoInIceland.Web.Common.Models;
    using WhatToDoInIceland.Web.Common.Models.ApisIs;

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
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept-Version", "1");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var result = client.GetAsync("http://apis.is/cinema/theaters").Result;

                    if (!result.IsSuccessStatusCode)
                    {
                        return;
                    }

                    var content = result.Content.ReadAsStringAsync().Result;
                    var content2 = JsonConvert.DeserializeObject<MovieTheaterListModel>(content);

                    updateStorage(new EventListModel { Id = (int)Categories.Movies, EventModels = content2.Results.Select(x => new EventModel { ImageUrl = "Content/movie.png", CategoryId = (int)Categories.Movies, EventName = x.Name, EventDescription = x.MoviesList(), Venue = VenueHelper.GetVenueModel(x.Name), EventDate = x.GetFirstShowTime() }).ToList() });
                }
            }
            catch (Exception)
            {
                // TODO: KRAPP LOG AND SWALLOW
            }
        }
    }
}