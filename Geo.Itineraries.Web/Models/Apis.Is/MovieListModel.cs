using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Models.ApisIs
{
    [Serializable]
    public class MovieListModel
    {
        [DataMember(Name = "results")]
        public ICollection<MovieModel> Results { get; set; }
    }
}