// <copyright file="ConcertListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The concert list model
    /// </summary>
    [Serializable]
    public class ConcertListModel
    {
        /// <summary>
        /// Gets or sets the results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public ICollection<ConcertDateModel> Results { get; set; }
    }
}