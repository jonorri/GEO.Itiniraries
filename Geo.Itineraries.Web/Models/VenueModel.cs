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

        // TODO: KRAPP FIND THIS OUT BASED ON ADDRESS 
        // https://developers.google.com/maps/documentation/geocoding/#Limits
        // https://groups.google.com/forum/#!topic/tasker/E-3DnR-WbfA
        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}