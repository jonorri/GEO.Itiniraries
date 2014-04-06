using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geo.Itineraries.Web.Models
{
    public class GetEventModel
    {
        public string Position { get; set; }

        public RadiusRanges RadiusRange { get; set; }

        public TimeRanges HourRange { get; set; }

        public Dictionary<object, object> Categories { get; set; }
    }
}