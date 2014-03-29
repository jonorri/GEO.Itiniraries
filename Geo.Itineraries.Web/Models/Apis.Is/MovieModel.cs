using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Models.ApisIs
{
    [Serializable]
    public class MovieModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "released")]
        public string Released { get; set; }

        [DataMember(Name = "restricted")]
        public string Restricted { get; set; }

        [DataMember(Name = "imdb")]
        public string Imdb { get; set; }

        [DataMember(Name = "imdbLink")]
        public string ImdbLink { get; set; }

        [DataMember(Name = "image")]
        public string Image { get; set; }

        [DataMember(Name = "showtimes")]
        public ICollection<ShowTimeModel> ShowTimes { get; set; }
    }
}