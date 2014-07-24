// <copyright file="MovieHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage.ApisIs
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using log4net;
    using Newtonsoft.Json;
    using WhatToDoInIceland.Web.Common.Helpers;
    using WhatToDoInIceland.Web.Common.Models;
    using WhatToDoInIceland.Web.Common.Models.ApisIs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The movie event handler
    /// </summary>
    public class MovieHandler : IEventHandler
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(MovieHandler));

        public override EventListModel GetEvents()
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
                        return new EventListModel();
                    }

                    var content = result.Content.ReadAsStringAsync().Result;
                    var content2 = JsonConvert.DeserializeObject<MovieTheaterListModel>(content);

                    return new EventListModel { Id = (int)Categories.Movies, EventModels = content2.Results.Select(x => new EventModel { ImageUrl = "Content/movie.png", CategoryId = (int)Categories.Movies, EventName = x.Name, EventDescription = x.MoviesList(), Venue = VenueHelper.GetVenueModel(x.Name), EventDate = x.GetFirstShowTime() }).ToList() };
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured getting movie data from apis.is.", ex);
                return null;
            }
        }
    }
}