﻿// <copyright file="MovieTheaterListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using WhatToDoInIceland.Web.Common.Models.Apis.Is;

    /// <summary>
    /// The movie theater list model
    /// </summary>
    [Serializable]
    public class MovieTheaterListModel
    {
        /// <summary>
        /// Gets or sets the results
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public ICollection<MovieTheaterModel> Results { get; set; }
    }
}