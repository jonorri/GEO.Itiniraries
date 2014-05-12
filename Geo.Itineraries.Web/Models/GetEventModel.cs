// <copyright file="GetEventModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The get event model
    /// </summary>
    public class GetEventModel
    {
        /// <summary>
        /// Gets or sets the position to get by 
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the radius range to get by
        /// </summary>
        public int RadiusRange { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the categories to get by
        /// </summary>
        public Dictionary<object, object> Categories { get; set; }
    }
}