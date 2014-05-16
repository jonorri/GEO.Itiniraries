// <copyright file="VenueModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

    /// <summary>
    /// The venue model
    /// </summary>
    public class VenueModel
    {
        /// <summary>
        /// Gets or sets the venue id
        /// </summary>
        [JsonProperty(PropertyName = "venueId")]
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the venue name
        /// </summary>
        [JsonProperty(PropertyName = "venueName")]
        public string VenueName { get; set; }

        /// <summary>
        /// Gets or sets the latitude
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
    }
}