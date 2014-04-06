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
            itineraryStorage = new RedisStorage();
        }

        // TODO: KRAPP THIS SHOULD BY ALL MEANS NOT JUST RETURN A JSON STRING
        public string Get(GetEventModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return string.Empty; // TODO: KRAPP THIS IS NOT RIGHT. THIS SHOULD RETURN AN ERROR INSTEAD
            }

            var latitudePosition = double.Parse(model.Position.Split(':')[0]);
            var longitudePosition = double.Parse(model.Position.Split(':')[1]);

            IList<EventTypes> eventTypes = new List<EventTypes>();
            if (model.Categories.Keys.Contains("Movies") && (model.Categories["Movies"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Movies);
            }

            if (model.Categories.Keys.Contains("Theater") && (model.Categories["Theater"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Theater);
            }

            if (model.Categories.Keys.Contains("Concerts") && (model.Categories["Concerts"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Concert);
            }

            if (model.Categories.Keys.Contains("Sports") && (model.Categories["Sports"] as string[]).FirstOrDefault() == "true")
            {
                eventTypes.Add(EventTypes.Sports);
            }

            return JsonConvert.SerializeObject(this.itineraryStorage.GetEvents(new GeoCoordinate(latitudePosition, longitudePosition), model.HourRange, model.RadiusRange, eventTypes));
        }
    }
}
