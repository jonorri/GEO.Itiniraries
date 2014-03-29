using Geo.Itineraries.Helpers;
using Geo.Itineraries.Models;
using Geo.Itineraries.Models.Apis.Is;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Geo.Itineraries.Storage.ApisIs
{
    public class ConcertHandler : IEventHandler
    {
        public async Task<IList<EventModel>> GetEvents()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept-Version", "1");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var result = await client.GetAsync("http://apis.is/concerts");
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception("KRAPP");
                }

                var content = await result.Content.ReadAsStringAsync();
                var content2 = JsonConvert.DeserializeObject<ConcertListModel>(content);

                // TODO: KRAPP Take this out based on location.
                return null;
            }
        }
    }
}