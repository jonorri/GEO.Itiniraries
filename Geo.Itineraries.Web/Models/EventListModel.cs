using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Web.Models
{
    [Serializable]
    public class EventListModel
    {
        public EventListModel()
        {
            this.EventModels = new List<EventModel>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public List<EventModel> EventModels { get; set; }
    }
}