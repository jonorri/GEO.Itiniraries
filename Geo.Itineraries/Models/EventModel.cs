using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geo.Itineraries.Models
{
    public class EventModel
    {
        public int EventId { get; set; }

        public int CategoryId { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventDate { get; set; }

        public int VenueId { get; set; }

        public VenueModel Venue { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.EventName, this.Venue != null ? this.Venue.VenueName : string.Empty);
        }
    }
}