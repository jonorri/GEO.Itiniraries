// <copyright file="ConcertModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The concert model
    /// </summary>
    [Serializable]
    public class ConcertModel
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the info
        /// </summary>
        [DataMember]
        public string Info { get; set; }

        /// <summary>
        /// Gets or sets the date
        /// </summary>
        [DataMember]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [DataMember]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [DataMember]
        public string Type { get; set; }
    }
}