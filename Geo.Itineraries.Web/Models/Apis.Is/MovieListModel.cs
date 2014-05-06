// <copyright file="MovieListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The movie list model
    /// </summary>
    [Serializable]
    public class MovieListModel
    {
        /// <summary>
        /// Gets or sets the results
        /// </summary>
        [DataMember(Name = "results")]
        public ICollection<MovieModel> Results { get; set; }
    }
}