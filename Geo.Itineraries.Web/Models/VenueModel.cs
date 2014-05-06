// <copyright file="VenueModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The venue model
    /// </summary>
    [Serializable]
    public class VenueModel
    {
        /// <summary>
        /// Gets or sets the venue id
        /// </summary>
        [DataMember]
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the venue name
        /// </summary>
        [DataMember]
        public string VenueName { get; set; }

        /// <summary>
        /// Gets or sets the latitude
        /// </summary>
        [DataMember]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        [DataMember]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [DataMember]
        public string Location { get; set; }
    }
}