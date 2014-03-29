using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Models.Apis.Is
{
    [Serializable]
    public class ConcertDateModel
    {
        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public ICollection<ConcertModel> Concerts { get; set; }
    }
}