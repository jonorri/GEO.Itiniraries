namespace Geo.Itineraries.Storage.Apis.Is
{
    using Geo.Itineraries.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;

    public class SportHandler : IEventHandler
    {
        public Task<IList<EventModel>> GetEvents()
        {
            throw new NotImplementedException();
        }
    }
}