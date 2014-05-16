﻿// <copyright file="ShowTimeModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The show time model
    /// </summary>
    [Serializable]
    public class ShowTimeModel
    {
        /// <summary>
        /// Gets or sets the theater of the show time
        /// </summary>
        [JsonProperty(PropertyName = "theater")]
        public string Theater { get; set; }

        /// <summary>
        /// Gets or sets the schedule of the show time
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public ICollection<string> Schedule { get; set; }
    }
}