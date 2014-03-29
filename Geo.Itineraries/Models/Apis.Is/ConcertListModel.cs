using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Models.Apis.Is
{
    [Serializable]
    public class ConcertListModel
    {
        [DataMember]
        public ICollection<ConcertDateModel> Results { get; set; }
    }
}