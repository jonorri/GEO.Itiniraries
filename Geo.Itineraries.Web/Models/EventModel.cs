// <copyright file="EventModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The event model
    /// </summary>
    [Serializable]
    public class EventModel
    {
        /// <summary>
        /// Gets or sets the event id
        /// </summary>
        [DataMember]
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the category id
        /// </summary>
        [DataMember]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        [DataMember]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the event description
        /// </summary>
        [DataMember]
        public string EventDescription { get; set; }

        /// <summary>
        /// Gets or sets the event date
        /// </summary>
        [DataMember]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the venue id
        /// </summary>
        [DataMember]
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the venue
        /// </summary>
        [DataMember]
        public VenueModel Venue { get; set; }

        /// <summary>
        /// Gets or sets the image url for the google maps marker
        /// </summary>
        [DataMember]
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