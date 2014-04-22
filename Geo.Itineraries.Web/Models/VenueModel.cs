using System;
using System.Runtime.Serialization;
namespace Geo.Itineraries.Web.Models
{
    [Serializable]
    public class VenueModel
    {
        [DataMember]
        public int VenueId { get; set; }

        [DataMember]
        public string VenueName { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}