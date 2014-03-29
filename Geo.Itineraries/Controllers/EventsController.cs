using Geo.Itineraries.Models;
using Geo.Itineraries.Storage;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Geo.Itineraries.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IItineraryStorage itineraryStorage;

        public EventsController()
        {
            itineraryStorage = new ItineraryStorage();
        }

        // GET api/events
        public async Task<IEnumerable<EventModel>> Get(string location)
        {
            // TODO: KRAPP RENAME TO *ASYNC
            return await this.itineraryStorage.GetEvents(1, location);
        }
    }
}
