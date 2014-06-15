// <copyright file="SportListModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    public class SportListModel
    {
        [JsonProperty(PropertyName = "results")]
        public ICollection<SportModel> Results { get; set; }
    }
}
