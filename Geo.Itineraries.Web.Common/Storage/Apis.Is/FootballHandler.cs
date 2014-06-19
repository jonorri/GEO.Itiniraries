// <copyright file="FootballHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage.ApisIs
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using WhatToDoInIceland.Web.Common.Helpers;
    using WhatToDoInIceland.Web.Common.Models;
    using WhatToDoInIceland.Web.Common.Models.Apis.Is;
    using Newtonsoft.Json;
    
    /// <summary>
    /// The football event handler
    /// </summary>
    public class FootballHandler : IEventHandler
    {
        /// <summary>
        /// Gets football events and stores them in REDIS
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

                    var content2 = JsonConvert.DeserializeObject<FootballListModel>(content);
                    
                    var eventListModel = new EventListModel
                    {
                        Id = (int)Categories.Football,
                        EventModels = content2.Results
                            .Where(x => !x.Tournament.Contains("lið") && !x.Tournament.Contains("flokkur")) // I want to filter out the youth games.
                            .Select(x => new EventModel 
                            { 
                                ImageUrl = "Content/sport.png", 
                                CategoryId = (int)Categories.Football, 
                                EventName = x.HomeTeam + " vs " + x.AwayTeam, 
                                EventDescription = this.BuildEventDescription(x), 
                                Venue = VenueHelper.GetVenueModel(x.Location), 
                                EventDate = this.ParseDateTime(x.Date, x.Time) 
                            })
                            .ToList()
                    };
                    updateStorage(eventListModel);
                }
            }
            catch (Exception)
            {
                // TODO: KRAPP LOG AND SWALLOW
            }
        }

        /// <summary>
        /// Builds up an event description based on the FootballModel
        /// </summary>
        /// <param name="model">Sport model to get description from</param>
        /// <returns>The event description</returns>
        private string BuildEventDescription(FootballModel model)
        {
            return string.Format("{0} vs {1}, {2}, {3}, {4}", model.HomeTeam, model.AwayTeam, model.Time, model.Date, model.Tournament);
        }

        /// <summary>
        /// Parses the DateTime from the values given by APIS.IS
        /// </summary>
        /// <param name="date">
        /// String date of the format xxx. XX. xxx. 
        /// Where the first part is the icelandic shorthand for the day of week
        /// The second part is the day of month.
        /// The third part is the icelandic shorthand for the month.
        /// </param>
        /// <param name="time">Time date of the 24 hour format delimited by a colon(:)</param>
        /// <returns>The appropriate date time</returns>
        private DateTime ParseDateTime(string date, string time)
        {
            int minute, hour, month, dayOfMonth;
            if (!int.TryParse(time.Substring(0, 2), out hour))
            {
                // TODO: KRAPP LOG AND SWALLOW EXCEPTION
            }

            if (!int.TryParse(time.Substring(time.IndexOf(':')), out minute))
            { 
                // TODO: KRAPP LOG AND SWALLOW EXCEPTION
            }

            var dateArray = date.Split(new string[] { ". " }, StringSplitOptions.None);
            
            if (!int.TryParse(dateArray[1].Substring(0, 2), out dayOfMonth))
            {
                // TODO: KRAPP LOG AND SWALLOW EXCEPTION
            }

            switch (dateArray[2].Substring(0, 3))
            {
                case "jan":
                    month = 1;
                    break;
                case "feb":
                    month = 2;
                    break;
                case "mar":
                    month = 3;
                    break;
                case "apr":
                    month = 4;
                    break;
                case "maí":
                    month = 5;
                    break;
                case "jún":
                    month = 6;
                    break;
                case "júl":
                    month = 7;
                    break;
                case "ágú":
                    month = 8;
                    break;
                case "sep":
                    month = 9;
                    break;
                case "okt":
                    month = 10;
                    break;
                case "nóv":
                    month = 11;
                    break;
                case "des":
                    month = 12;
                    break;
                default:
                    month = 0;
                    break;
            }

            DateTime dateTime = new DateTime(DateTime.UtcNow.Year, month, dayOfMonth);
            TimeSpan ts = new TimeSpan(hour, minute, 0);
            dateTime = dateTime.Date + ts;
            return dateTime;
        }
    }
}