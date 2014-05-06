// <copyright file="ConcertDateModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The concert date model
    /// </summary>
    [Serializable]
    public class ConcertDateModel
    {
        /// <summary>
        /// Gets or sets the date
        /// </summary>
        [DataMember]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the concerts
        /// </summary>
        [DataMember]
        public ICollection<ConcertModel> Concerts { get; set; }
    }
}