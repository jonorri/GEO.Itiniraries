// <copyright file="MovieModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The movie model
    /// </summary>
    [Serializable]
    public class MovieModel
    {
        /// <summary>
        /// Gets or sets the title of the movie
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the schedule for the movie
        /// </summary>
        [DataMember(Name = "schedule")]
        public ICollection<string> Schedule { get; set; }
    }
}