// <copyright file="EventListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The event list model
    /// </summary>
    [Serializable]
    public class EventListModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventListModel"/> class.
        /// </summary>
        public EventListModel()
        {
            this.EventModels = new List<EventModel>();
        }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the event model list
        /// </summary>
        [JsonProperty(PropertyName = "eventModels")]
        public List<EventModel> EventModels { get; set; }
    }
}