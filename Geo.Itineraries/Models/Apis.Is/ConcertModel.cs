using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Models.Apis.Is
{
    [Serializable]
    public class ConcertModel
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Info { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}