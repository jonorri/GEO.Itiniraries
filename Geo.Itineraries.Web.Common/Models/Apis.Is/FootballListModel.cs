// <copyright file="FootballListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The model to keep a list of football games
    /// </summary>
    [Serializable]
    public class FootballListModel
    {
        /// <summary>
        /// Gets or sets the results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public ICollection<FootballModel> Results { get; set; }
    }
}
