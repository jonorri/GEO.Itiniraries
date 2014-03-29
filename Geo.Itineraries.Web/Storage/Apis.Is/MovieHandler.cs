namespace Geo.Itineraries.Web.Storage.ApisIs
{
    using Geo.Itineraries.Models;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Geo.Itineraries.Web.Helpers;
    using Geo.Itineraries.Models.ApisIs;
    using Geo.Itineraries.Web.Models;
    using ServiceStack.Redis;
    using System.Text;

    public class MovieHandler : IEventHandler
    {
        public override void GetEvents()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept-Version", "1");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var result = client.GetAsync("http://apis.is/cinema").Result;
                if (result.IsSuccessStatusCode)
                {
                    // TODO: KRAPP REVERSE THIS THROW SOME SORT OF INFORMATION OUT IF THE HTTP REQUEST FAILS
                    var content = result.Content.ReadAsStringAsync().Result;
                    var content2 = JsonConvert.DeserializeObject<MovieListModel>(content);

                    // TODO: KRAPP STOP WITH THE MANUAL APPROACH
                    var venues = ManuallyGetVenuesMAJORHACK(content2.Results);
                    var venueShowTimes = ManualGetShowtimesMAJORHACK(venues, content2.Results);

                    UpdateRedis(new EventListModel { EventModels = venueShowTimes.Select(x => new EventModel { EventName = x.Venue, EventDescription = x.VenueDescription, Venue = VenueHelper.GetVenueModel(x.Venue), EventDate = x.ShowTimes.Min() }).ToList(), Id = (int)EventTypes.Movies });
                }
            }
        }

        private IList<VenueShowTime> ManualGetShowtimesMAJORHACK(HashSet<string> venues, ICollection<MovieModel> movieModels)
        {
            var list = new List<VenueShowTime>();
            
            foreach (var venue in venues)
            {
                StringBuilder sb = new StringBuilder();
                var showTimeList = new List<DateTime>();

                foreach (var movie in movieModels)
                {
                    foreach (var showtime in movie.ShowTimes)
                    {
                        if (showtime.Theater == venue)
                        {   
                            foreach (var singleShowTime in showtime.Schedule)
                            {
                                showTimeList.Add(DateTime.Parse(singleShowTime.Substring(0, 5)));
                                sb.Append(string.Format("{0}:{1}{2}", movie.Title, singleShowTime, Environment.NewLine));
                            }
                        }
                    }
                }

                list.Add(new VenueShowTime { Venue = venue, VenueDescription = sb.ToString(), ShowTimes = showTimeList.Distinct().ToList() });
            }

            return list;
        }

        private HashSet<string> ManuallyGetVenuesMAJORHACK(ICollection<MovieModel> collection)
        {
            HashSet<string> hash = new HashSet<string>();
            foreach(var movie in collection)
            {
                foreach(var showtime in movie.ShowTimes)
                {
                    if (!hash.Contains(showtime.Theater))
                    {
                        hash.Add(showtime.Theater);
                    }
                }
            }

            return hash;
        }
    }

    class VenueShowTime
    {
        public string Venue { get; set; }

        public IList<DateTime> ShowTimes { get; set; }

        public string VenueDescription { get; set; }
    }
}