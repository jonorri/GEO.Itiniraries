// <copyright file="EventsController.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Controllers
{
    using System.Collections.Generic;
    using System.Device.Location;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using Geo.Itineraries.Web.Models;
    using Geo.Itineraries.Web.Storage;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The events controller
    /// </summary>
    public class EventsController : Controller
    {
        /// <summary>
        /// The IItineraryStorage implementation to use
        /// </summary>
        private readonly IItineraryStorage itineraryStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        public EventsController()
        {
            this.itineraryStorage = new RedisStorage();
        }

        /// <summary>
        /// The get model returns a filtered list of all events that are happening
        /// </summary>
        /// <param name="model">Get event model filters out all unnecessary events</param>
        /// <returns>A JSON string</returns>
        public JObject Get(GetEventModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return new JObject();
            }

            var latitudePosition = double.Parse(model.Position.Split(':')[0], CultureInfo.InvariantCulture);
            var longitudePosition = double.Parse(model.Position.Split(':')[1], CultureInfo.InvariantCulture);

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

            return JObject.FromObject(this.itineraryStorage.GetEvents(new GeoCoordinate(latitudePosition, longitudePosition), model.HourRange, model.RadiusRange, eventTypes));
        }
    }
}
