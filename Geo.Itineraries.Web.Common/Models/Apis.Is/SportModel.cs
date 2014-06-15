// <copyright file="SportModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    public class SportModel
    {
        [JsonProperty(PropertyName = "counter")]
        public int Counter { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "tournament")]
        public string Tournament { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "homeTeam")]
        public string HomeTeam { get; set; }

        [JsonProperty(PropertyName = "awayTeam")]
        public string AwayTeam { get; set; }
    }
}
