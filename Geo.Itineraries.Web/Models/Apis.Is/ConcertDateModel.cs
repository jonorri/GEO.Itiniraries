namespace Geo.Itineraries.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public class ConcertDateModel
    {
        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public ICollection<ConcertModel> Concerts { get; set; }
    }
}