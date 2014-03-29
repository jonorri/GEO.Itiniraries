using Geo.Itineraries.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Geo.Itineraries.Storage
{
    public interface IItineraryStorage
    {
        IList<CategoryModel> GetCategories();

        Task<IList<EventModel>> GetEventsByCategory(int categoryId);

        Task<IList<EventModel>> GetEvents(int categoryId, string location);

        CategoryModel GetCategory(int id);
    }
}
