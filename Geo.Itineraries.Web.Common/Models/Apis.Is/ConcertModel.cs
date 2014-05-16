// <copyright file="ConcertModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The concert model
    /// </summary>
    [Serializable]
    public class ConcertModel
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the info
        /// </summary>
        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }

        /// <summary>
        /// Gets or sets the date
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}