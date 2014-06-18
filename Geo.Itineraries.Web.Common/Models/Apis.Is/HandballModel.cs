namespace Geo.Itineraries.Web.Common.Models.Apis.Is
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    public class HandballModel
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "tournament")]
        public string Tournament { get; set; }

        [JsonProperty(PropertyName = "venue")]
        public string Venue { get; set; }

        [JsonProperty(PropertyName = "teams")]
        public string Teams { get; set; }
    }
}
