// <copyright file="VenueModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The venue model
    /// </summary>
    public class VenueModel
    {
        /// <summary>
        /// Gets or sets the venue id
        /// </summary>
        [JsonProperty(PropertyName = "venueId")]
        public string VenueId { get; set; }

        /// <summary>
        /// Gets or sets the venue key
        /// </summary>
        [JsonProperty(PropertyName = "venueKey")]
        public string VenueKey { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether this venue is sponsored or not
        /// </summary>
        [JsonProperty(PropertyName = "sponsored")]
        public bool Sponsored { get; set; }
    }
}