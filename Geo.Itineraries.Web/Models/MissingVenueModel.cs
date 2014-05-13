// <copyright file="MissingVenueModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    using System;

    /// <summary>
    /// A model for missing venues
    /// </summary>
    public class MissingVenueModel
    {
        /// <summary>
        /// Gets or sets the id of the missing venue model
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the venue name
        /// </summary>
        public string VenueName { get; set; }

        /// <summary>
        /// Gets or sets the date when the venue was missing.
        /// </summary>
        public DateTime DateMissing { get; set; }
    }
}