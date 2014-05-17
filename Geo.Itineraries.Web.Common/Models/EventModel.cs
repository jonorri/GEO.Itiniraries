// <copyright file="EventModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Models
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The event model
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Gets or sets the event id
        /// </summary>
        [JsonProperty(PropertyName = "eventId")]
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the category id
        /// </summary>
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        [JsonProperty(PropertyName = "eventName")]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the event description
        /// </summary>
        [JsonProperty(PropertyName = "eventDescription")]
        public string EventDescription { get; set; }

        /// <summary>
        /// Gets or sets the event date
        /// </summary>
        [JsonProperty(PropertyName = "eventDate")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the venue id
        /// </summary>
        [JsonProperty(PropertyName = "venueId")]
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the venue
        /// </summary>
        [JsonProperty(PropertyName = "venue")]
        public VenueModel Venue { get; set; }

        /// <summary>
        /// Gets or sets the image url for the google maps marker
        /// </summary>
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Overrides the ToString() method for EventModels for logging
        /// </summary>
        /// <returns>The string representation of the event model</returns>
        public override string ToString()
        {
            return string.Format("{0}:{1}", this.EventName, this.Venue != null ? this.Venue.VenueName : string.Empty);
        }
    }
}