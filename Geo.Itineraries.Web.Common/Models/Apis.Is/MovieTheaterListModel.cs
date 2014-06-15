// <copyright file="MovieTheaterListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Geo.Itineraries.Web.Common.Models.Apis.Is;
    using Newtonsoft.Json;

    /// <summary>
    /// The movie theater list model
    /// </summary>
    [Serializable]
    public class MovieTheaterListModel
    {
        // TODO: KRAPP LOOK INTO SERIALIZATION FOR THESE ENTITIES FOR ALL ENTITIES

        /// <summary>
        /// Gets or sets the results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public ICollection<MovieTheaterModel> Results { get; set; }
    }
}