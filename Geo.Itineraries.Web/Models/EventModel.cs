using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Web.Models
{
    [Serializable]
    public class EventModel
    {
        [DataMember]
        public int EventId { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public string EventDescription { get; set; }

        [DataMember]
        public DateTime EventDate { get; set; }

        [DataMember]
        public int VenueId { get; set; }

        [DataMember]
        public VenueModel Venue { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.EventName, this.Venue != null ? this.Venue.VenueName : string.Empty);
        }
    }
}