﻿// <copyright file="MovieTheaterListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Geo.Itineraries.Web.Models.Apis.Is;

    /// <summary>
    /// The movie theater list model
    /// </summary>
    [Serializable]
    public class MovieTheaterListModel
    {
        /// <summary>
        /// Gets or sets the results
        /// </summary>
        [DataMember(Name = "results")]
        public ICollection<MovieTheaterModel> Results { get; set; }
    }
}