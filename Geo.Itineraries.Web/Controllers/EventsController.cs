// <copyright file="EventsController.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Controllers
{
    using System.Collections.Generic;
    using System.Device.Location;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using WhatToDoInIceland.Web.Common.Models;
    using WhatToDoInIceland.Web.Common.Storage;
    using Geo.Itineraries.Web.Common.Storage;

    /// <summary>
    /// The events controller
    /// </summary>
    public class EventsController : Controller
    {
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

            double latitudePosition;
            if (!double.TryParse(model.Position.Split(':')[0], out latitudePosition))
            {
                return new JObject();
            }

            double longitudePosition;
            if (!double.TryParse(model.Position.Split(':')[1], out longitudePosition))
            {
                return new JObject();
            }

            IList<Categories> categories = new List<Categories>();
            if (model.Categories.Contains("Movies"))
            {
                categories.Add(Categories.Movies);
            }

            if (model.Categories.Contains("Theater"))
            {
                categories.Add(Categories.Theater);
            }

            if (model.Categories.Contains("Concerts"))
            {
                categories.Add(Categories.Concert);
            }

            if (model.Categories.Contains("Football"))
            {
                categories.Add(Categories.Football);
            }

            if (model.Categories.Contains("Handball"))
            {
                categories.Add(Categories.Handball);
            }

            var events = InMemoryStorage.GetEvents(new GeoCoordinate(latitudePosition, longitudePosition), model.StartDate, model.EndDate, model.RadiusRange, categories);
            return JObject.FromObject(events);
        }
    }
}
