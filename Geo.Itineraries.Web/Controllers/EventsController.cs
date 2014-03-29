using Geo.Itineraries.Web.Models;
using Geo.Itineraries.Web.Storage;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Geo.Itineraries.Models;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Device.Location;

namespace Geo.Itineraries.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IItineraryStorage itineraryStorage;

        public EventsController()
        {
            itineraryStorage = new ItineraryStorage();
        }

        public string Get(string position, RadiusRanges radiusRange, TimeRanges hourRange, Dictionary<object, object> categories)
        {
            // TODO: KRAPP VALIDATE INPUT

            var latitudePosition = double.Parse(position.Split(':')[0]);
            var longitudePosition = double.Parse(position.Split(':')[1]);

            IList<EventTypes> eventTypes = new List<EventTypes>();
            if (categories.Keys.Contains("Movies") && (categories["Movies"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Movies);
            }

            if (categories.Keys.Contains("Theater") && (categories["Theater"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Theater);
            }

            if (categories.Keys.Contains("Concerts") && (categories["Concerts"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Concert);
            }

            if (categories.Keys.Contains("Sports") && (categories["Sports"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Sports);
            }

            return JsonConvert.SerializeObject(this.itineraryStorage.GetEvents(new GeoCoordinate(latitudePosition, longitudePosition), hourRange, radiusRange, eventTypes));
        }
    }
}
