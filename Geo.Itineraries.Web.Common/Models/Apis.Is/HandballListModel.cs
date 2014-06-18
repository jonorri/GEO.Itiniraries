namespace Geo.Itineraries.Web.Common.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    public class HandballListModel
    {
        [JsonProperty(PropertyName = "results")]
        public ICollection<HandballModel> Results { get; set; }
    }
}
