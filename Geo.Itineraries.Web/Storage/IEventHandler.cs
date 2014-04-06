using Geo.Itineraries.Web.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geo.Itineraries.Web.Storage
{
    public abstract class IEventHandler
    {
        public abstract void GetEvents(Action<EventListModel> updateStorage);
    }
}
