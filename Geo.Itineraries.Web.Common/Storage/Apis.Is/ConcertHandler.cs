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
    using System.Threading.Tasks;

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
        /// <returns>The event list model</returns>
        public override EventListModel GetEvents()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept-Version", "1");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var result = client.GetAsync("http://apis.is/concerts").Result;
                    if (!result.IsSuccessStatusCode)
                    {
                        return new EventListModel();
                    }

                    var content = result.Content.ReadAsStringAsync().Result;
                    var concertListModel = JsonConvert.DeserializeObject<ConcertListModel>(content);

                    return new EventListModel(); // TODO: KRAPP FINISH THIS LATER
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured getting concert events from apis.is.", ex);
                return null;
            }
        }
    }
}