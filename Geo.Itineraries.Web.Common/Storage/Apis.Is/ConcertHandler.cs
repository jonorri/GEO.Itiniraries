// <copyright file="ConcertHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage.ApisIs
{
    using System;
    using System.Net.Http;
    using log4net;
    using Newtonsoft.Json;
    using WhatToDoInIceland.Web.Common.Models;
    using WhatToDoInIceland.Web.Common.Models.ApisIs;

    /// <summary>
    /// The concert event handler
    /// </summary>
    public class ConcertHandler : IEventHandler
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConcertHandler));

        /// <summary>
        /// Gets concert events from APIS.is
        /// </summary>
        /// <param name="updateStorage">Update storage action to run with the fetched events</param>
        public override async void GetEvents(Action<EventListModel> updateStorage)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept-Version", "1");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var result = await client.GetAsync("http://apis.is/concerts");
                    if (!result.IsSuccessStatusCode)
                    {
                        return;
                    }

                    var content = await result.Content.ReadAsStringAsync();
                    var concertListModel = JsonConvert.DeserializeObject<ConcertListModel>(content);
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured getting concert events from apis.is.", ex);
            }
        }
    }
}