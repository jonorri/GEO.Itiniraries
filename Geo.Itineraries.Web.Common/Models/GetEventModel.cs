// <copyright file="GetEventModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The get event model
    /// </summary>
    [Serializable]
    public class GetEventModel
    {
        /// <summary>
        /// Gets or sets the position to get by 
        /// </summary>
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the radius range to get by
        /// </summary>
        [JsonProperty(PropertyName = "radiusRange")]
        public int RadiusRange { get; set; }

        /// <summary>
        /// Gets or sets the start date to get by
        /// </summary>
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date to get by
        /// </summary>
        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the categories to get by
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public string Categories { get; set; }
    }
}