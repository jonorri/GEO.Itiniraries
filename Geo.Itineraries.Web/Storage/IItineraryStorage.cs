using Geo.Itineraries.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Geo.Itineraries.Web.Models;
using System.Device.Location;
namespace Geo.Itineraries.Web.Storage
{
    public interface IItineraryStorage
    {
        EventListModel GetEvents(GeoCoordinate position, TimeRanges hourRange, RadiusRanges radiusRange, IList<EventTypes> categories);

        void PrimeCache();
    }
}
