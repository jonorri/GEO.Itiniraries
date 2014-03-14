namespace Geo.Itineraries.Storage
{
    using Geo.Itineraries.Models;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Geo.Itineraries.Helpers;

    public class MovieHandler : IEventHandler
    {
        public async Task<IList<EventModel>> GetEvents()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept-Version", "1");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var result = await client.GetAsync("http://apis.is/cinema");
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception("KRAPP");
                }

                var content = await result.Content.ReadAsStringAsync();
                var content2 = JsonConvert.DeserializeObject<MovieListModel>(content);

                // TODO: KRAPP Multiply events in the collection
                // TODO: KRAPP Fix the time to datetime
                return content2.Results.Select(x => new EventModel { Venue = VenueHelper.GetVenueModel(x.ShowTimes.First().Theater), EventName = x.Title, EventDescription = x.ImdbLink }).ToList() ;
            }
        }
    }
}