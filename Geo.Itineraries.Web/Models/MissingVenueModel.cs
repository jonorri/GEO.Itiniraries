using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geo.Itineraries.Web.Models
{
    public class MissingVenueModel
    {
        public string VenueName { get; set; }

        public DateTime DateMissing { get; set; }
    }
}