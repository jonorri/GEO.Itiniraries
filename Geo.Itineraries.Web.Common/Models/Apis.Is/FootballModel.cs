// <copyright file="FootballModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The model to keep track of football games
    /// </summary>
    [Serializable]
    public class FootballModel
    {
        /// <summary>
        /// Gets or sets the counter
        /// </summary>
        [JsonProperty(PropertyName = "counter")]
        public int Counter { get; set; }

        /// <summary>
        /// Gets or sets the date
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the time
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the tournament
        /// </summary>
        [JsonProperty(PropertyName = "tournament")]
        public string Tournament { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the home team
        /// </summary>
        [JsonProperty(PropertyName = "homeTeam")]
        public string HomeTeam { get; set; }

        /// <summary>
        /// Gets or sets the away team
        /// </summary>
        [JsonProperty(PropertyName = "awayTeam")]
        public string AwayTeam { get; set; }
    }
}
