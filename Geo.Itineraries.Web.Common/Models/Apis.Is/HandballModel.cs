// <copyright file="HandballModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models.Apis.Is
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// A model for handball games
    /// </summary>
    [Serializable]
    public class HandballModel
    {
        /// <summary>
        /// Gets or sets the date of the game
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the time of the game
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the tournament for the game
        /// </summary>
        [JsonProperty(PropertyName = "tournament")]
        public string Tournament { get; set; }

        /// <summary>
        /// Gets or sets the venue of the game
        /// </summary>
        [JsonProperty(PropertyName = "venue")]
        public string Venue { get; set; }

        /// <summary>
        /// Gets or sets the teams of the game
        /// </summary>
        [JsonProperty(PropertyName = "teams")]
        public string Teams { get; set; }
    }
}
