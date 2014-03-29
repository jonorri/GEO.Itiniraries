using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Geo.Itineraries.Models
{
    [Serializable]
    public class ShowTimeModel
    {
        [DataMember(Name = "theater")]
        public string Theater { get; set; }

        [DataMember(Name = "schedule")]
        public ICollection<string> Schedule { get; set; }
    }
}