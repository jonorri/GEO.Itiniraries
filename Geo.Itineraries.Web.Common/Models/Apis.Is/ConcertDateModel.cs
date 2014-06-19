// <copyright file="ConcertDateModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The concert date model
    /// </summary>
    [Serializable]
    public class ConcertDateModel
    {
        /// <summary>
        /// Gets or sets the date
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the concerts
        /// </summary>
        [JsonProperty(PropertyName = "concerts")]
        public ICollection<ConcertModel> Concerts { get; set; }
    }
}