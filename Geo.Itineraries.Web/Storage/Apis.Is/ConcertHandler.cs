using Geo.Itineraries.Models.ApisIs;
using Geo.Itineraries.Web.Helpers;
using Geo.Itineraries.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Geo.Itineraries.Web.Storage.ApisIs
{
    public class ConcertHandler : IEventHandler
    {
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
                    var content2 = JsonConvert.DeserializeObject<ConcertListModel>(content);    
                }
            }
        }
    }
}