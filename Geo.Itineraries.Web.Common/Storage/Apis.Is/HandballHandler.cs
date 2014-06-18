namespace Geo.Itineraries.Web.Common.Storage.ApisIs
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Geo.Itineraries.Web.Common.Helpers;
    using Geo.Itineraries.Web.Common.Models;
    using Geo.Itineraries.Web.Common.Models.Apis.Is;
    using Newtonsoft.Json;

    public class HandballHandler : IEventHandler
    {
        /// <summary>
        /// Gets handball events and stores them in REDIS
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
                    var result = client.GetAsync("http://apis.is/sports/handball").Result;

                    if (!result.IsSuccessStatusCode)
                    {
                        return;
                    }

                    var content = result.Content.ReadAsStringAsync().Result;

                    var content2 = JsonConvert.DeserializeObject<HandballListModel>(content);

                    var eventListModel = new EventListModel
                    {
                        Id = (int)Categories.Handball,
                        EventModels = content2.Results
                            .Select(x => new EventModel { ImageUrl = "Content/sport.png", CategoryId = (int)Categories.Handball, EventName = x.Teams, EventDescription = BuildEventDescription(x), Venue = VenueHelper.GetVenueModel(x.Venue), EventDate = ParseDateTime(x.Date, x.Time) })
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
        /// Builds up an event description based on the HandballModel
        /// </summary>
        /// <param name="model">Handball model to get description from</param>
        /// <returns>The event description</returns>
        private string BuildEventDescription(HandballModel model)
        {
            return string.Format("{0}, {1}, {2}, {3}", model.Teams, model.Time, model.Date, model.Tournament);
        }

        /// <summary>
        /// Parses the datetime from the values given by APIS.IS
        /// </summary>
        /// <param name="date">
        /// String date of the format xxx. XX.xxx.XXXX
        /// Where the first part is the icelandic shorthand for the day of week
        /// The second part is the day of month.
        /// The third part is the icelandic shorthand for the month.
        /// The fourth part is the year
        /// </param>
        /// <param name="time">Time date of the 24 hour format delimited by a dot(.)</param>
        /// <returns></returns>
        private DateTime ParseDateTime(string date, string time)
        {
            int minute, hour, month, dayOfMonth, year;
            if (!int.TryParse(time.Substring(0, 2), out hour))
            {
                // TODO: KRAPP LOG AND SWALLOW EXCEPTION
            }

            if (!int.TryParse(time.Substring(time.IndexOf('.')), out minute))
            {
                // TODO: KRAPP LOG AND SWALLOW EXCEPTION
            }

            var dateArray = date.Split(new string[] { "." }, StringSplitOptions.None);

            if (!int.TryParse(dateArray[1].Trim().Substring(0, 2), out dayOfMonth))
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
                    // TODO: KRAPP LOG AND SWALLOW EXCEPTION
                    month = -1;
                    break;
            }

            if (!int.TryParse(dateArray[2].Trim(), out year))
            {
                // TODO: KRAPP LOG AND SWALLOW EXCEPTION
            }

            DateTime dateTime = new DateTime(year, month, dayOfMonth);
            TimeSpan ts = new TimeSpan(hour, minute, 0);
            dateTime = dateTime.Date + ts;
            return dateTime;
        }
    }
}
