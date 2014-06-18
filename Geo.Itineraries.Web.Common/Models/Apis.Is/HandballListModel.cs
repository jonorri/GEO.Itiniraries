// <copyright file="HandballListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A list model for handball games
    /// </summary>
    [Serializable]
    public class HandballListModel
    {
        /// <summary>
        /// Gets or sets the results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public ICollection<HandballModel> Results { get; set; }
    }
}
