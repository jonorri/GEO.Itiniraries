﻿namespace Geo.Itineraries.Web.Storage.ApisIs
{
    using System;
    using System.Net.Http;
    using Geo.Itineraries.Models.ApisIs;
    using Geo.Itineraries.Web.Models;
    using Newtonsoft.Json;

    public class ConcertHandler : IEventHandler
    {
        /// <summary>
        /// Gets concert events from APIS.is
        /// </summary>
        /// <param name="updateStorage">Update storage action to run with the fetched events</param>
        public override async void GetEvents(Action<EventListModel> updateStorage)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept-Version", "1");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var result = await client.GetAsync("http://apis.is/concerts");
                if (result.IsSuccessStatusCode)
                {
                    // TODO: KRAPP DO SOMETHING ELSE WHEN I DON'T GET NEW INFORMATION.
                    var content = await result.Content.ReadAsStringAsync();
                    var concertListModel = JsonConvert.DeserializeObject<ConcertListModel>(content);
                }
            }
        }
    }
}