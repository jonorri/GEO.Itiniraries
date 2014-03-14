using Geo.Itineraries.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Geo.Itineraries.Storage
{
    public interface IEventHandler
    {
        Task<IList<EventModel>> GetEvents();
    }
}
